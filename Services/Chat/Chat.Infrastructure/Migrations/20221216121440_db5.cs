using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_JoinGroup_JoinGroupId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinGroup",
                table: "JoinGroup");

            migrationBuilder.RenameTable(
                name: "JoinGroup",
                newName: "JoinGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinGroups",
                table: "JoinGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_JoinGroups_JoinGroupId",
                table: "Messages",
                column: "JoinGroupId",
                principalTable: "JoinGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_JoinGroups_JoinGroupId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JoinGroups",
                table: "JoinGroups");

            migrationBuilder.RenameTable(
                name: "JoinGroups",
                newName: "JoinGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JoinGroup",
                table: "JoinGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_JoinGroup_JoinGroupId",
                table: "Messages",
                column: "JoinGroupId",
                principalTable: "JoinGroup",
                principalColumn: "Id");
        }
    }
}
