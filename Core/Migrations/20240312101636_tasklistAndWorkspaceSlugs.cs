using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class tasklistAndWorkspaceSlugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d8d5fdf-72e5-46c0-adc9-b346e28b7435"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("466451fc-8c3c-4288-8b44-52dfb617e9be"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2080),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1950),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "WorkSpaces",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(850),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1840),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "TaskLists",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(70),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(490),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2720), new Guid("dab19538-d15f-4ff0-a719-4fa5c1d5baa9") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2720), new Guid("a8e6646b-68bc-4787-bf24-2e7f7b91c886") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("a8e6646b-68bc-4787-bf24-2e7f7b91c886"), null, new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2660), new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2660), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, 1, new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2660), "admin" },
                    { new Guid("dab19538-d15f-4ff0-a719-4fa5c1d5baa9"), null, new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2610), new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2610), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, 1, new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2610), "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a8e6646b-68bc-4787-bf24-2e7f7b91c886"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dab19538-d15f-4ff0-a719-4fa5c1d5baa9"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "WorkSpaces");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "TaskLists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6750),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7030),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6180),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6070),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6480),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4880),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7490), new Guid("2d8d5fdf-72e5-46c0-adc9-b346e28b7435") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7490), new Guid("466451fc-8c3c-4288-8b44-52dfb617e9be") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("2d8d5fdf-72e5-46c0-adc9-b346e28b7435"), null, new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390), new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, 1, new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7390), "admin" },
                    { new Guid("466451fc-8c3c-4288-8b44-52dfb617e9be"), null, new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, 1, new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7430), "admin" }
                });
        }
    }
}
