using Core.Data;
using Core.Data.Entity;
using Core.Data.Enum;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class SeedConfiguration
{
    public static void Seed(this ModelBuilder builder)
    {
        var user1 = Guid.NewGuid();
        var user2 = Guid.NewGuid();

        UserSeed(builder, user1, user2);
        RoleSeed(builder);


        RoleClaimsSeed(builder, user1, user2);
    }


    public static async Task ActionData(this IApplicationBuilder app)
    {
        await using var provider = ServiceTool.ServiceProvider!.CreateAsyncScope();
        var unit = provider.ServiceProvider.GetService<UnitOfWork>()!;

        await unit.Actions.CreateBasePermission();
    }


    #region Seeds

    private static void UserSeed(ModelBuilder builder, Guid u1, Guid u2)
    {
        builder.Entity<User>()
            .HasData(new User
            {
                Id = u1,
                RowStatus = RowStatus.Active,
                Fullname = "Mehmet Emin Yavaş",
                Email = "mehmett76ers@gmail.com",
                MobilePhone = "5054443322",
                Gender = Gender.Male,
                AvatarUrl = null,
                BirthDate = DateTime.Now,
                IsVerified = true,
                VerifyToken = "admin",
                VerifiedAt = DateTime.Now,
                CreatedAt = DateTime.Now
            });

        builder.Entity<User>()
            .HasData(new User
            {
                Id = u2,
                RowStatus = RowStatus.Active,
                Fullname = "Emrecan Ünlü",
                Email = "emre.cunlu@gmail.com",
                MobilePhone = "5554443322",
                Gender = Gender.Male,
                AvatarUrl = null,
                BirthDate = DateTime.Now,
                IsVerified = true,
                VerifyToken = "admin",
                VerifiedAt = DateTime.Now,
                CreatedAt = DateTime.Now
            });
    }

    private static void RoleSeed(ModelBuilder builder)
    {
        var entity = builder.Entity<Role>();

        entity.HasData(new List<Role>
        {
            new()
            {
                Id = 1,
                Name = Roles.Admin.ToString(),
                Description = "All Permission",
                IsStrict = true,
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id = 2,
                Name = Roles.Staff.ToString(),
                Description = null,
                CreatedAt = DateTime.Now,
                IsStrict = true
            },
            new()
            {
                Id = 3,
                Name = Roles.User.ToString(),
                Description = null,
                CreatedAt = DateTime.Now,
                IsStrict = true
            }
        });
    }


    private static void RoleClaimsSeed(ModelBuilder builder, Guid u1, Guid u2)
    {
        var entity = builder.Entity<UserRole>();

        entity.HasData(new List<UserRole>
        {
            new()
            {
                Id = 1,
                RoleId = (long)Roles.Admin,
                UserId = u1,
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id = 2,
                RoleId = (long)Roles.Admin,
                UserId = u2,
                CreatedAt = DateTime.Now
            }
        });
    }

    #endregion
}