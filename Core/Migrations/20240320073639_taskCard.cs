using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class taskCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a8e6646b-68bc-4787-bf24-2e7f7b91c886"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dab19538-d15f-4ff0-a719-4fa5c1d5baa9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9560),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9810),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8040),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8810),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8550),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8260),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9460),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7480),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7900),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.CreateTable(
                name: "TaskCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaskListId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: false),
                    Priority = table.Column<byte>(type: "smallint", nullable: false),
                    RowStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9070)),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9220)),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskCards_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(270), new Guid("cb44a8f6-37fe-42b2-a472-3ecf97962eea") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(270), new Guid("ec6f00a9-52f0-4bc1-9112-f24a37ff40d0") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("cb44a8f6-37fe-42b2-a472-3ecf97962eea"), null, new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160), new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, 1, new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(160), "admin" },
                    { new Guid("ec6f00a9-52f0-4bc1-9112-f24a37ff40d0"), null, new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210), new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, 1, new DateTime(2024, 3, 20, 10, 36, 39, 658, DateTimeKind.Local).AddTicks(210), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskCards_TaskListId",
                table: "TaskCards",
                column: "TaskListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskCards");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb44a8f6-37fe-42b2-a472-3ecf97962eea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec6f00a9-52f0-4bc1-9112-f24a37ff40d0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2080),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1950),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(2210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(850),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1840),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskLists",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(1690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(220),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(70),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(490),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 838, DateTimeKind.Local).AddTicks(330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 13, 16, 36, 837, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 20, 10, 36, 39, 657, DateTimeKind.Local).AddTicks(7090));

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
    }
}
