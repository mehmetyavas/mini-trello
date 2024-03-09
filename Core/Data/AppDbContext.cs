using System.Linq.Expressions;
using Core.Configuration;
using Core.Data.Entity;
using Core.Data.Entity.Base;
using Core.Data.Enum;
using Core.Services;
using Core.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;
using Action = Core.Data.Entity.Action;

namespace Core.Data;

public class AppDbContext : DbContext
{
    public Guid UserId { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        UserResolverServices userResolver)
        : base(options)
    {
        UserId = userResolver.UserId;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Action> Actions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        base.OnConfiguring(optionsBuilder.UseNpgsql(AppConfig.ConnectionString));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var entities = builder.Model
            .GetEntityTypes()
            .Where(e => e.ClrType.GetInterface(nameof(IEntity)) != null)
            .Select(e => e.ClrType);


        foreach (var entity in entities)
        {
            var parameter = Expression.Parameter(entity, "x");
            var property = Expression.Property(parameter, nameof(RowStatus));
            var constant = Expression.Constant(RowStatus.Active);
            var body = Expression.Equal(property, constant);
            var lambda = Expression.Lambda(body, parameter);


            builder.Entity(entity).Property(nameof(IEntity.CreatedAt)).HasDefaultValue(DateTime.Now);

            builder.Entity(entity).Property(nameof(IEntity.RowStatus)).HasDefaultValue(RowStatus.Active);


            builder.Entity(entity).HasQueryFilter(lambda);
        }

        builder.Seed();
        builder.SetAutoIncludes();

        // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}