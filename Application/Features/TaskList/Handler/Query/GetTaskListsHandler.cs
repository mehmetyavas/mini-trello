using Application.Features.TaskList.Request;
using Application.Features.TaskList.Response;
using Core.Data;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TaskList.Handler.Query;

public class GetTaskListsHandler:IRequestHandler<GetTaskListsRequest,IResult<List<TaskListResponse>>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetTaskListsHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<TaskListResponse>>> Handle(GetTaskListsRequest request, CancellationToken cancellationToken)
    {

        var taskLists = await _unitOfWork.TaskLists
            .IncludeWorkSpace()
            .Where(x => x.WorkSpaceId == request.WorkSpaceId)
            .Select(s=>new TaskListResponse
            {
                WorkSpaceId = s.WorkSpaceId,
                Title = s.Title,
                Order = s.Order,

            })
            .ToListAsync(cancellationToken);


        return new SuccessResult<List<TaskListResponse>>(taskLists);
    }
}