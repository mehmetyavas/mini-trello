using Application.Features.TaskList.Request;
using Application.Features.TaskList.Response;
using Core.Data;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.TaskList.Handler.Command;

public class UpdateTaskListHandler : IRequestHandler<UpdateTaskListRequest, IResult<TaskListResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public UpdateTaskListHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<TaskListResponse>> Handle(UpdateTaskListRequest request, CancellationToken cancellationToken)
    {

        await _unitOfWork.TaskLists.CheckSlug(request.Title);


        var taskList = await _unitOfWork.TaskLists.Query()
            .Where(x => x.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (taskList is null)
        {
            throw new NotFoundException();
        }

        taskList.Title = request.Title;
        taskList.Order = request.Order??taskList.Order;

        if (request.Order.HasValue)
        {
            await _unitOfWork.TaskLists.UpdateOrderNos((byte)request.Order, request.Id);
        }
        
        
        //TODO: order update 
        _unitOfWork.TaskLists.Update(taskList);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<TaskListResponse>(new TaskListResponse
        {
            Id = taskList.Id,
            Title = taskList.Title,
            Order = taskList.Order,
            WorkSpaceId = taskList.WorkSpaceId
        });
        
    }
}