using System.Linq.Expressions;
using Core.Data;
using Core.Data.Dto.Pagination;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.User.Request;
using WebAPI.Business.User.Response;

namespace WebAPI.Business.User.Handler.Query;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IResult<PagingResponse<List<UserResponse>>>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetUsersQueryHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<PagingResponse<List<UserResponse>>>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        Expression<Func<Core.Data.Entity.User, bool>>? expression = null;

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            expression = x => x.Email.Contains(request.Search) || x.Fullname.Contains(request.Search);
        }

        var query = expression == null
            ? _unitOfWork.Users
                .IgnoreFilterAndInclude()
            : _unitOfWork.Users
                .IgnoreFilterAndInclude()
                .Where(expression);

        var pagingDto = await _unitOfWork.Users.PagingListAsync(request, query, cancellationToken);

        var userResponses = pagingDto.List
            .Select(x => new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Fullname = x.Fullname,
                AvatarUrl = x.AvatarUrl,
                MobilePhone = x.MobilePhone
            }).ToList();


        var pagingResponse = new PagingResponse<List<UserResponse>>(
            data: userResponses,
            request.Page,
            userResponses.Count,
            pagingDto.count);


        return new SuccessResult<PagingResponse<List<UserResponse>>>(pagingResponse);
    }
}