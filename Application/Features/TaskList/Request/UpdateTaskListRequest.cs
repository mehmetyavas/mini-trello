using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Features.TaskList.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Request;

public class UpdateTaskListRequest : IRequest<IResult<TaskListResponse>>
{
    public long Id { get; set; }

    [Required, MinLength(3), MaxLength(25)]
    public string Title { get; set; } = null!;


    public byte? Order { get; set; }
}