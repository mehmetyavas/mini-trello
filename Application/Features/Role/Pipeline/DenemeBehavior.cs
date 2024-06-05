using System.Reflection;
using Core.Data;
using Core.Utilities.Helpers;
using Core.Utilities.Middleware;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Features.Role.Pipeline;

public class DenemeBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;
    private UnitOfWork _unitOfWork;

    public DenemeBehavior(IRequestHandler<TRequest, TResponse> requestHandler, UnitOfWork unitOfWork)
    {
        _handler = requestHandler;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // IRequestHandler<,> arayüzünün implementasyonlarını al
        // var handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
        //     .Where(t => t is { IsAbstract: false, IsInterface: false } &&
        //                 typeof(IRequestHandler<TRequest, TResponse>).IsAssignableFrom(t)
        //                 );

        var handlerType = _handler.GetType();

        var attributes = handlerType.GetCustomAttribute<DenemeAttribute>(true);

        if ( attributes is not null )
        {
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var response = await next();
                transaction.Commit();

                return response;
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                transaction.Rollback();
                throw;
            }
        }
        else
        {
            var response = await next();
            return response;
        }
    }
}