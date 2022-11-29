using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sticker_Id",
                table: "Messages",
                newName: "StickerId");

            migrationBuilder.RenameColumn(
                name: "Gif_Id",
                table: "Messages",
                newName: "GifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StickerId",
                table: "Messages",
                newName: "Sticker_Id");

            migrationBuilder.RenameColumn(
                name: "GifId",
                table: "Messages",
                newName: "Gif_Id");
        }
    }
}
