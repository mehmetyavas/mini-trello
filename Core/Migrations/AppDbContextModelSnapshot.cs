﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Data.Entity.Default.Action", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7090));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7320));

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7480));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<bool>("IsStrict")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7630));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(240),
                            Description = "All Permission",
                            IsStrict = true,
                            Name = "Admin",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(250),
                            IsStrict = true,
                            Name = "Staff",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(250),
                            IsStrict = true,
                            Name = "User",
                            RowStatus = 1
                        });
                });

            modelBuilder.Entity("Core.Data.Entity.Default.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7740));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7900));

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8040));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<long?>("LoginCode")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LoginCodeExpiredAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8160));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("VerifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("VerifyToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MobilePhone")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb44a8f6-37fe-42b2-a472-3ecf97962eea"),
                            BirthDate = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160),
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160),
                            Email = "mehmett76ers@gmail.com",
                            Fullname = "Mehmet Emin Yavaş",
                            Gender = 1,
                            IsVerified = true,
                            MobilePhone = "5054443322",
                            RowStatus = 1,
                            VerifiedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160),
                            VerifyToken = "admin"
                        },
                        new
                        {
                            Id = new Guid("ec6f00a9-52f0-4bc1-9112-f24a37ff40d0"),
                            BirthDate = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210),
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210),
                            Email = "emre.cunlu@gmail.com",
                            Fullname = "Emrecan Ünlü",
                            Gender = 1,
                            IsVerified = true,
                            MobilePhone = "5554443322",
                            RowStatus = 1,
                            VerifiedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210),
                            VerifyToken = "admin"
                        });
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserLogin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("AccessTokenExpiresOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8260));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LoginProvider")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8450));

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiresOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserPermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ActionName")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8550));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8690));

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8810));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8960));

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(270),
                            RoleId = 1L,
                            RowStatus = 1,
                            UserId = new Guid("cb44a8f6-37fe-42b2-a472-3ecf97962eea")
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(270),
                            RoleId = 1L,
                            RowStatus = 1,
                            UserId = new Guid("ec6f00a9-52f0-4bc1-9112-f24a37ff40d0")
                        });
                });

            modelBuilder.Entity("Core.Data.Entity.TaskCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9070));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Image")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9220));

                    b.Property<byte>("Order")
                        .HasColumnType("smallint");

                    b.Property<byte>("Priority")
                        .HasColumnType("smallint");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long>("TaskListId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("TaskListId");

                    b.ToTable("TaskCards");
                });

            modelBuilder.Entity("Core.Data.Entity.TaskList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9320));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9460));

                    b.Property<byte>("Order")
                        .HasColumnType("smallint");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<long>("WorkSpaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkSpaceId");

                    b.ToTable("TaskLists");
                });

            modelBuilder.Entity("Core.Data.Entity.WorkSpace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9560));

                    b.Property<Guid>("CreatorUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9710));

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("WorkSpaces");
                });

            modelBuilder.Entity("Core.Data.Entity.WorkSpaceMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9810));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MemberStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9960));

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<long>("WorkSpaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkSpaceId");

                    b.ToTable("WorkSpaceMembers");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.RolePermission", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.Action", "Action")
                        .WithMany("ActionClaims")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Data.Entity.Default.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserLogin", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.User", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserPermission", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.UserRole", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Data.Entity.Default.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Data.Entity.TaskCard", b =>
                {
                    b.HasOne("Core.Data.Entity.TaskList", "TaskList")
                        .WithMany("TaskCards")
                        .HasForeignKey("TaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("Core.Data.Entity.TaskList", b =>
                {
                    b.HasOne("Core.Data.Entity.WorkSpace", "WorkSpace")
                        .WithMany("TaskLists")
                        .HasForeignKey("WorkSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkSpace");
                });

            modelBuilder.Entity("Core.Data.Entity.WorkSpace", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.User", "CreatorUser")
                        .WithMany("WorkSpaces")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("Core.Data.Entity.WorkSpaceMember", b =>
                {
                    b.HasOne("Core.Data.Entity.Default.User", "User")
                        .WithMany("WorkSpaceMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Data.Entity.WorkSpace", "WorkSpace")
                        .WithMany("Members")
                        .HasForeignKey("WorkSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkSpace");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.Action", b =>
                {
                    b.Navigation("ActionClaims");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Core.Data.Entity.Default.User", b =>
                {
                    b.Navigation("UserLogins");

                    b.Navigation("UserPermissions");

                    b.Navigation("UserRoles");

                    b.Navigation("WorkSpaceMembers");

                    b.Navigation("WorkSpaces");
                });

            modelBuilder.Entity("Core.Data.Entity.TaskList", b =>
                {
                    b.Navigation("TaskCards");
                });

            modelBuilder.Entity("Core.Data.Entity.WorkSpace", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("TaskLists");
                });
#pragma warning restore 612, 618
        }
    }
}
