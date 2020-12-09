using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaServer.Migrations
{
    public partial class removeUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_USers",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "PlaylistUserList");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_UserID",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlaylistSongList",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSongList", x => new { x.PlaylistID, x.SongID });
                    table.ForeignKey(
                        name: "FK_PlaylistUserList_Playlists",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistUserList_Songs",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongList_SongID",
                table: "PlaylistSongList",
                column: "SongID");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "PlaylistSongList");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlaylistUserList",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistUserList", x => new { x.PlaylistID, x.SongID });
                    table.ForeignKey(
                        name: "FK_PlaylistUserList_Playlists",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistUserList_Songs",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserID",
                table: "Playlists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistUserList_SongID",
                table: "PlaylistUserList",
                column: "SongID");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_USers",
                table: "Playlists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
