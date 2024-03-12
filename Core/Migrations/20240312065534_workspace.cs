using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class workspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3bda00-0b06-4589-851a-8727c0f05aaf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ddc1686-5559-4e6c-8e3b-d6c0025e4e67"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8520),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(7820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.CreateTable(
                name: "WorkSpace",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9330)),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSpace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSpace_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSpaceMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkSpaceId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberStatus = table.Column<int>(type: "integer", nullable: false),
                    RowStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9580)),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSpaceMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSpaceMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSpaceMember_WorkSpace_WorkSpaceId",
                        column: x => x.WorkSpaceId,
                        principalTable: "WorkSpace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(40), new Guid("13cef9f5-b6c0-4c7a-9642-c76385dac125") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(40), new Guid("05285270-a010-49f2-8082-72114d830dd4") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "Modified", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("05285270-a010-49f2-8082-72114d830dd4"), null, new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9990), new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9990), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, null, 1, new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9990), "admin" },
                    { new Guid("13cef9f5-b6c0-4c7a-9642-c76385dac125"), null, new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9940), new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9950), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, null, 1, new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9950), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSpace_UserId",
                table: "WorkSpace",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSpaceMember_UserId",
                table: "WorkSpaceMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSpaceMember_WorkSpaceId",
                table: "WorkSpaceMember",
                column: "WorkSpaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSpaceMember");

            migrationBuilder.DropTable(
                name: "WorkSpace");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05285270-a010-49f2-8082-72114d830dd4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13cef9f5-b6c0-4c7a-9642-c76385dac125"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6060),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5900),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(4820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6420), new Guid("5b3bda00-0b06-4589-851a-8727c0f05aaf") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6430), new Guid("7ddc1686-5559-4e6c-8e3b-d6c0025e4e67") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "Modified", "PasswordHash", "PasswordSalt", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("5b3bda00-0b06-4589-851a-8727c0f05aaf"), null, new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6320), new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6330), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, null, null, "5054443322", null, null, null, 1, new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6330), "admin" },
                    { new Guid("7ddc1686-5559-4e6c-8e3b-d6c0025e4e67"), null, new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6370), new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6370), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, null, null, "5554443322", null, null, null, 1, new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6370), "admin" }
                });
        }
    }
}
