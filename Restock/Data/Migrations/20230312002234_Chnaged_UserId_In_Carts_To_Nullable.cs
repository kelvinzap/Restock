using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restock.Data.Migrations
{
    /// <inheritdoc />
    public partial class Chnaged_UserId_In_Carts_To_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdTemp",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);
            migrationBuilder.Sql(@"UPDATE dbo.Carts SET UserIdTemp = UserId");
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");
            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserIdTemp",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
