using Core.Data;
using Core.Data.Dto.User;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.WorkSpace.Request;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.WorkSpace.Handler.Query;

public class GetUserWorkSpacesHandler:IRequestHandler<GetUserWorkSpacesRequest,IResult<List<WorkSpaceResponse>>>
{

    private readonly UnitOfWork _unitOfWork;

    public GetUserWorkSpacesHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<WorkSpaceResponse>>> Handle(GetUserWorkSpacesRequest request, CancellationToken cancellationToken)
    {

        var workSpaces =await _unitOfWork.WorkSpaces
            .IncludeCreator()
            .Where(x=>x.CreatorUserId==request.UserId)
            .Select(s=>new WorkSpaceResponse
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                CreatorUser = new UserDto
                {
                    Id = s.CreatorUser.Id,
                    Email = s.CreatorUser.Email,
                    Fullname = s.CreatorUser.Fullname,
                    AvatarUrl = s.CreatorUser.AvatarUrl
                }
            })
            .ToListAsync(cancellationToken);



        return new SuccessResult<List<WorkSpaceResponse>>(workSpaces);
    }
}