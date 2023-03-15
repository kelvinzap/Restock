using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restock.Data.Migrations
{
    /// <inheritdoc />
    public partial class Removed_UserId_ForeignKey_From_CartsTablec : Migration
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

 

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
