using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCoreAPI.Migrations
{
    public partial class updatetb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "SubProduct");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "SubProduct");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "SubProduct");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "SubProduct");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "SubProduct");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "ImageSecon");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                maxLength: 20000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Product",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "Product",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMain",
                table: "Product",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusOrderId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusOrder",
                columns: table => new
                {
                    StatusOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrder", x => x.StatusOrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusOrderId",
                table: "Order",
                column: "StatusOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_StatusOrder_StatusOrderId",
                table: "Order",
                column: "StatusOrderId",
                principalTable: "StatusOrder",
                principalColumn: "StatusOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_StatusOrder_StatusOrderId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "StatusOrder");

            migrationBuilder.DropIndex(
                name: "IX_Order_StatusOrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageMain",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StatusOrderId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ImageSecon",
                table: "Product",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "SubProduct",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "SubProduct",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "SubProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "SubProduct",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "SubProduct",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 20000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId");
        }
    }
}
