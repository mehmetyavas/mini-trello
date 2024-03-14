using Core.Data;
using Core.Data.Enum;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.TaskList.Request;
using WebAPI.Business.TaskList.Response;

namespace WebAPI.Business.TaskList.Handler.Command;

public class CreateTaskListHandler : IRequestHandler<CreateTaskListRequest, IResult<TaskListResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public CreateTaskListHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<TaskListResponse>> Handle(CreateTaskListRequest request,
        CancellationToken cancellationToken)
    {
        // validasyonlar

        await _unitOfWork.TaskLists.CheckSlug(request.Title);


        var generateRowOrder = await _unitOfWork.TaskLists.GenerateRowOrder(cancellationToken);

        var newTaskList = new Core.Data.Entity.TaskList
        {
            Title = request.Title,
            WorkSpaceId = request.WorkSpaceId,
            Order = (byte)generateRowOrder
        };


        _unitOfWork.TaskLists.Add(newTaskList);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult<TaskListResponse>();
    }
}