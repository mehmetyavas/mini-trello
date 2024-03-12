using Core.Data;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.WorkSpace.Request;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.WorkSpace.Handler.Query;

public class GetWorkSpaceHandler : IRequestHandler<GetWorkSpaceRequest, IResult<WorkSpaceResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetWorkSpaceHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<WorkSpaceResponse>> Handle(GetWorkSpaceRequest request,
        CancellationToken cancellationToken)
    {
        var workSpace = await _unitOfWork.WorkSpaces
            .IncludeCreator()
            .Where(x => x.Id == request.Id)
            .Select(s => new WorkSpaceResponse
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                CreatorUser = new UserDto
                {
                    Id = s.CreatorUserId,
                    Email = s.CreatorUser.Email,
                    Fullname = s.CreatorUser.Fullname,
                    AvatarUrl = s.CreatorUser.AvatarUrl
                }
            }).SingleOrDefaultAsync(cancellationToken);

        if (workSpace is null)
        {
            throw new NotFoundException();
        }


        return new SuccessResult<WorkSpaceResponse>(workSpace);
    }
}