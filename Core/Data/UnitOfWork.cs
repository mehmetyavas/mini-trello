using System.Data;
using Core.Data.Repository;
using Core.Data.Repository.Default;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Data;

public class UnitOfWork: IDisposable
{
    public Guid UserId { get; set; }
    private readonly AppDbContext _context;

    private readonly UserRepository _userRepository;
    private readonly UserLoginRepository _userLoginRepository;
    private readonly RoleRepository _roleRepository;
    private readonly UserRolesRepository _userRolesRepository;
    private readonly ActionRepository _actionRepository;
    private readonly RolePermissionRepository _rolePermissionRepository;
    private readonly UserPermissionRepository _userPermissionRepository;

    private readonly WorkSpaceRepository? _workSpaceRepository;
    private readonly WorkSpaceMembersRepository? _workSpaceMembersRepository;

    private readonly TaskListRepository? _taskListRepository;
    private readonly TaskCardRepository? _taskCardRepository;

    //TODO: buraya çözüm bul üstteki private kodları incele

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        UserId = context.UserId;
    }


    public void Dispose()
    {
        _context?.Dispose();
    }


    public async Task<IDbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
      var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
      return transaction.GetDbTransaction();
    }


    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }


    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }


    public UserRepository Users => _userRepository ?? new UserRepository(_context);
    public UserLoginRepository UserLogins => _userLoginRepository ?? new(_context);

    public RoleRepository Roles => _roleRepository ?? new(_context);

    public UserRolesRepository UserRoles => _userRolesRepository ?? new(_context);

    public ActionRepository Actions => _actionRepository ?? new(_context);

    public RolePermissionRepository RolePermissions => _rolePermissionRepository ?? new(_context);

    public UserPermissionRepository UserPermissions => _userPermissionRepository ?? new(_context);

    public WorkSpaceRepository WorkSpaces => _workSpaceRepository ?? new(_context);

    public WorkSpaceMembersRepository WorkSpaceMembers => _workSpaceMembersRepository ?? new(_context);
    public TaskListRepository TaskLists => _taskListRepository ?? new(_context);
    public TaskCardRepository TaskCards => _taskCardRepository ?? new(_context);
}