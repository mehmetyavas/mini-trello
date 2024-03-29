﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240312084158_tasklist")]
    partial class tasklist
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4330));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4590));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4740));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4880));

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
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470),
                            Description = "All Permission",
                            IsStrict = true,
                            Name = "Admin",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470),
                            IsStrict = true,
                            Name = "Staff",
                            RowStatus = 1
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470),
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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5000));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5180));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5300));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5450));

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
                            Id = new Guid("2d8d5fdf-72e5-46c0-adc9-b346e28b7435"),
                            BirthDate = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390),
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390),
                            Email = "mehmett76ers@gmail.com",
                            Fullname = "Mehmet Emin Yavaş",
                            Gender = 1,
                            IsVerified = true,
                            MobilePhone = "5054443322",
                            RowStatus = 1,
                            VerifiedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390),
                            VerifyToken = "admin"
                        },
                        new
                        {
                            Id = new Guid("466451fc-8c3c-4288-8b44-52dfb617e9be"),
                            BirthDate = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430),
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430),
                            Email = "emre.cunlu@gmail.com",
                            Fullname = "Emrecan Ünlü",
                            Gender = 1,
                            IsVerified = true,
                            MobilePhone = "5554443322",
                            RowStatus = 1,
                            VerifiedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430),
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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5550));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LoginProvider")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5700));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5910));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6070));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6180));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6330));

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
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7490),
                            RoleId = 1L,
                            RowStatus = 1,
                            UserId = new Guid("2d8d5fdf-72e5-46c0-adc9-b346e28b7435")
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7490),
                            RoleId = 1L,
                            RowStatus = 1,
                            UserId = new Guid("466451fc-8c3c-4288-8b44-52dfb617e9be")
                        });
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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6480));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6620));

                    b.Property<byte>("Order")
                        .HasColumnType("smallint");

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6750));

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6910));

                    b.Property<int>("RowStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

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
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7030));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MemberStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Modified")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7190));

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

            modelBuilder.Entity("Core.Data.Entity.WorkSpace", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("TaskLists");
                });
#pragma warning restore 612, 618
        }
    }
}
