using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class workspaceNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpace_Users_UserId",
                table: "WorkSpace");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpaceMember_Users_UserId",
                table: "WorkSpaceMember");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpaceMember_WorkSpace_WorkSpaceId",
                table: "WorkSpaceMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSpaceMember",
                table: "WorkSpaceMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSpace",
                table: "WorkSpace");

            migrationBuilder.DropIndex(
                name: "IX_WorkSpace_UserId",
                table: "WorkSpace");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05285270-a010-49f2-8082-72114d830dd4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13cef9f5-b6c0-4c7a-9642-c76385dac125"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkSpace");

            migrationBuilder.RenameTable(
                name: "WorkSpaceMember",
                newName: "WorkSpaceMembers");

            migrationBuilder.RenameTable(
                name: "WorkSpace",
                newName: "WorkSpaces");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSpaceMember_WorkSpaceId",
                table: "WorkSpaceMembers",
                newName: "IX_WorkSpaceMembers_WorkSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSpaceMember_UserId",
                table: "WorkSpaceMembers",
                newName: "IX_WorkSpaceMembers_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8710),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9460),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8930),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8260),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7960),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMembers",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9930),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaces",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9330));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSpaceMembers",
                table: "WorkSpaceMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSpaces",
                table: "WorkSpaces",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkSpaces_CreatorUserId",
                table: "WorkSpaces",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpaceMembers_Users_UserId",
                table: "WorkSpaceMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpaceMembers_WorkSpaces_WorkSpaceId",
                table: "WorkSpaceMembers",
                column: "WorkSpaceId",
                principalTable: "WorkSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpaces_Users_CreatorUserId",
                table: "WorkSpaces",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpaceMembers_Users_UserId",
                table: "WorkSpaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpaceMembers_WorkSpaces_WorkSpaceId",
                table: "WorkSpaceMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSpaces_Users_CreatorUserId",
                table: "WorkSpaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSpaces",
                table: "WorkSpaces");

            migrationBuilder.DropIndex(
                name: "IX_WorkSpaces_CreatorUserId",
                table: "WorkSpaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSpaceMembers",
                table: "WorkSpaceMembers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7f10563-4a17-4bb5-b997-66b3c626ca38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ffea832d-1efe-4c5a-8ee7-33b571b1e16e"));

            migrationBuilder.RenameTable(
                name: "WorkSpaces",
                newName: "WorkSpace");

            migrationBuilder.RenameTable(
                name: "WorkSpaceMembers",
                newName: "WorkSpaceMember");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSpaceMembers_WorkSpaceId",
                table: "WorkSpaceMember",
                newName: "IX_WorkSpaceMember_WorkSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkSpaceMembers_UserId",
                table: "WorkSpaceMember",
                newName: "IX_WorkSpaceMember_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8520),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserRoles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9090),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8740),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RolePermissions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(8300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actions",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(7820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpace",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpace",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9330),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 817, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "WorkSpace",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "WorkSpaceMember",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkSpaceMember",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 3, 12, 9, 55, 34, 272, DateTimeKind.Local).AddTicks(9580),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 3, 12, 10, 56, 2, 818, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSpace",
                table: "WorkSpace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSpaceMember",
                table: "WorkSpaceMember",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Modified" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Modified" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Modified" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(20), null });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Modified", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(40), null, new Guid("13cef9f5-b6c0-4c7a-9642-c76385dac125") });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Modified", "UserId" },
                values: new object[] { new DateTime(2024, 3, 12, 9, 55, 34, 273, DateTimeKind.Local).AddTicks(40), null, new Guid("05285270-a010-49f2-8082-72114d830dd4") });

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpace_Users_UserId",
                table: "WorkSpace",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpaceMember_Users_UserId",
                table: "WorkSpaceMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSpaceMember_WorkSpace_WorkSpaceId",
                table: "WorkSpaceMember",
                column: "WorkSpaceId",
                principalTable: "WorkSpace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
