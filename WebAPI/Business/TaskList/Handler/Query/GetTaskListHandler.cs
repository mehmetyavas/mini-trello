using Core.Data;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.TaskList.Request;
using WebAPI.Business.TaskList.Response;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.TaskList.Handler.Query;

public class GetTaskListHandler:IRequestHandler<GetTaskListRequest,IResult<TaskListResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetTaskListHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<TaskListResponse>> Handle(GetTaskListRequest request, CancellationToken cancellationToken)
    {

        var taskList = await _unitOfWork.TaskLists
            .IncludeWorkSpace()
            .Where(x => x.Id == request.Id)
            .Select(s => new TaskListResponse
                {
                    Title = s.Title,
                    Order = s.Order,
                   WorkSpaceId = s.WorkSpaceId
                }
            ).SingleOrDefaultAsync(cancellationToken);

        if (taskList is null)
        {
            throw new NotFoundException();
        }

        return new SuccessResult<TaskListResponse>(taskList);
    }
}