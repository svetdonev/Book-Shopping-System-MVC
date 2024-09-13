using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShoppingSystemMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookImage",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genre",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BookPrice",
                table: "Book",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Book",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genre",
                newName: "GenreName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Book",
                newName: "BookPrice");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Book",
                newName: "BookName");

            migrationBuilder.AddColumn<string>(
                name: "BookImage",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Genre_GenreId",
                table: "Book",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
