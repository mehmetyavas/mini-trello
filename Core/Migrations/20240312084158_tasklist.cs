using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class tasklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7f10563-4a17-4bb5-b997-66b3c626ca38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ffea832d-1efe-4c5a-8ee7-33b571b1e16e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6750),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7030),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6180),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6070),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4880),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5180),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5000),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.CreateTable(
                name: "TaskLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: false),
                    WorkSpaceId = table.Column<long>(type: "bigint", nullable: false),
                    RowStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6480)),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6620)),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskLists_WorkSpaces_WorkSpaceId",
                        column: x => x.WorkSpaceId,
                        principalTable: "WorkSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TaskLists_WorkSpaceId",
                table: "TaskLists",
                column: "WorkSpaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskLists");

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
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9930),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9460),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8930),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8260),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 11, 41, 58, 151, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(520), new Guid("c7f10563-4a17-4bb5-b997-66b3c626ca38") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(520), new Guid("ffea832d-1efe-4c5a-8ee7-33b571b1e16e") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("c7f10563-4a17-4bb5-b997-66b3c626ca38"), null, new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(400), new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(410), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, 1, new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(410), "admin" },
                    { new Guid("ffea832d-1efe-4c5a-8ee7-33b571b1e16e"), null, new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(460), new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(460), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, 1, new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(460), "admin" }
                });
        }
    }
}
