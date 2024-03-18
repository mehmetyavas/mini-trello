using Application.Features.TaskList.Request;
using Core.Data;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Handler.Command;

public class DeleteTaskListHandler : IRequestHandler<DeleteTaskListRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public DeleteTaskListHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(DeleteTaskListRequest request, CancellationToken cancellationToken)
    {
        var taskList = await _unitOfWork.TaskLists.GetAsync(x => x.Id == request.Id, cancellationToken);

        if (taskList is null)
        {
            throw new NotFoundException();
        }


        await _unitOfWork.TaskLists.SoftDelete(taskList, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult();
    }
}