﻿using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.UserRoleAndPermission.Request;

public record RemovePermissionsFromUserRequest : IRequest<IResult>
{
    public required Guid UserId { get; set; }
    public required IEnumerable<int> PermissionIds { get; set; } = new List<int>();
}