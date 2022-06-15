using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCoreAPI.Migrations
{
    public partial class updatetb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_StatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "User",
                newName: "StatusUserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_StatusId",
                table: "User",
                newName: "IX_User_StatusUserId");

            migrationBuilder.CreateTable(
                name: "StatusUser",
                columns: table => new
                {
                    StatusUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUser", x => x.StatusUserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_User_StatusUser_StatusUserId",
                table: "User",
                column: "StatusUserId",
                principalTable: "StatusUser",
                principalColumn: "StatusUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StatusUser_StatusUserId",
                table: "User");

            migrationBuilder.DropTable(
                name: "StatusUser");

            migrationBuilder.RenameColumn(
                name: "StatusUserId",
                table: "User",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_User_StatusUserId",
                table: "User",
                newName: "IX_User_StatusId");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Status_StatusId",
                table: "User",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }
    }
}
