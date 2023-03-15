using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restock.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_CartItems_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItemModel_Carts_CartId",
                table: "CartItemModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItemModel",
                table: "CartItemModel");

            migrationBuilder.RenameTable(
                name: "CartItemModel",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItemModel_CartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItemModel");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItemModel",
                newName: "IX_CartItemModel_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItemModel",
                table: "CartItemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemModel_Carts_CartId",
                table: "CartItemModel",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
