using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class UserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2cc31d87-e6e5-4809-9052-7daa3a98dcbc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa71dcef-d0c5-42a7-99fa-df1885402089"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoginCodeExpiredAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "LoginCode",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6060),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5900),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(4820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(6690));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b3bda00-0b06-4589-851a-8727c0f05aaf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ddc1686-5559-4e6c-8e3b-d6c0025e4e67"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LoginCodeExpiredAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LoginCode",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7530),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7850),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(6960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(7240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(6690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 3, 9, 12, 23, 56, 162, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8330), new Guid("2cc31d87-e6e5-4809-9052-7daa3a98dcbc") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8330), new Guid("fa71dcef-d0c5-42a7-99fa-df1885402089") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "CreatedAt", "DeletedAt", "Email", "Fullname", "Gender", "IsVerified", "LoginCode", "LoginCodeExpiredAt", "MobilePhone", "Modified", "RowStatus", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { new Guid("2cc31d87-e6e5-4809-9052-7daa3a98dcbc"), null, new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8250), new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8250), null, "mehmett76ers@gmail.com", "Mehmet Emin Yavaş", 1, true, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5054443322", null, 1, new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8250), "admin" },
                    { new Guid("fa71dcef-d0c5-42a7-99fa-df1885402089"), null, new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8290), new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8290), null, "emre.cunlu@gmail.com", "Emrecan Ünlü", 1, true, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5554443322", null, 1, new DateTime(2024, 3, 9, 11, 36, 54, 95, DateTimeKind.Local).AddTicks(8290), "admin" }
                });
        }
    }
}
