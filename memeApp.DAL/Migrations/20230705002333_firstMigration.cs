using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace memeApp.DAL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userRoleRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_userRoleRoleId",
                        column: x => x.userRoleRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadMeme",
                columns: table => new
                {
                    UploadID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    fileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadMeme", x => x.UploadID);
                    table.ForeignKey(
                        name: "FK_UploadMeme_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadMeme",
                columns: table => new
                {
                    DownloadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadsUploadID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadMeme", x => x.DownloadId);
                    table.ForeignKey(
                        name: "FK_DownloadMeme_UploadMeme_UploadsUploadID",
                        column: x => x.UploadsUploadID,
                        principalTable: "UploadMeme",
                        principalColumn: "UploadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemeTemplateDownloadUser",
                columns: table => new
                {
                    memeTemplateDownloadsDownloadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemeTemplateDownloadUser", x => new { x.memeTemplateDownloadsDownloadId, x.usersId });
                    table.ForeignKey(
                        name: "FK_MemeTemplateDownloadUser_DownloadMeme_memeTemplateDownloadsDownloadId",
                        column: x => x.memeTemplateDownloadsDownloadId,
                        principalTable: "DownloadMeme",
                        principalColumn: "DownloadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemeTemplateDownloadUser_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadMeme_UploadsUploadID",
                table: "DownloadMeme",
                column: "UploadsUploadID");

            migrationBuilder.CreateIndex(
                name: "IX_MemeTemplateDownloadUser_usersId",
                table: "MemeTemplateDownloadUser",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadMeme_UsersId",
                table: "UploadMeme",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userRoleRoleId",
                table: "Users",
                column: "userRoleRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemeTemplateDownloadUser");

            migrationBuilder.DropTable(
                name: "DownloadMeme");

            migrationBuilder.DropTable(
                name: "UploadMeme");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
