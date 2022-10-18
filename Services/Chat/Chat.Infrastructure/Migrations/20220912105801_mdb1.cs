using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Migrations
{
    public partial class mdb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JoinGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvitedBy = table.Column<long>(type: "bigint", nullable: false),
                    InviteByLink = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupBanUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupBanUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupBanUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupProfiles_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleOfJoinSetting = table.Column<int>(type: "int", nullable: false),
                    SendMessage = table.Column<bool>(type: "bit", nullable: false),
                    SendMedia = table.Column<bool>(type: "bit", nullable: false),
                    SendSticker = table.Column<bool>(type: "bit", nullable: false),
                    SendGif = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joins_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    ToUser_Id = table.Column<long>(type: "bigint", nullable: true),
                    ReplyMessageId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sticker_Id = table.Column<long>(type: "bigint", nullable: false),
                    JoinGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Gif_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_JoinGroup_JoinGroupId",
                        column: x => x.JoinGroupId,
                        principalTable: "JoinGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Messages_ReplyMessageId",
                        column: x => x.ReplyMessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_MessageId",
                table: "Files",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupBanUsers_GroupId",
                table: "GroupBanUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProfiles_GroupId",
                table: "GroupProfiles",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Joins_GroupId",
                table: "Joins",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_JoinGroupId",
                table: "Messages",
                column: "JoinGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReplyMessageId",
                table: "Messages",
                column: "ReplyMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "GroupBanUsers");

            migrationBuilder.DropTable(
                name: "GroupProfiles");

            migrationBuilder.DropTable(
                name: "Joins");

            migrationBuilder.DropTable(
                name: "Seens");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "JoinGroup");
        }
    }
}
