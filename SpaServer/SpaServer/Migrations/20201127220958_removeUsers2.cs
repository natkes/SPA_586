using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaServer.Migrations
{
    public partial class removeUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Playlists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SongId",
                table: "Playlists",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Songs_SongId",
                table: "Playlists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
