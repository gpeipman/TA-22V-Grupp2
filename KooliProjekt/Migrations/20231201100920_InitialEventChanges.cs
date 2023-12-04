using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialEventChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_organizers_Id",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "organizers_Id",
                table: "Events",
                newName: "user_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_organizers_Id",
                table: "Events",
                newName: "IX_Events_user_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_user_Id",
                table: "Events",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_user_Id",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "user_Id",
                table: "Events",
                newName: "organizers_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_user_Id",
                table: "Events",
                newName: "IX_Events_organizers_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_organizers_Id",
                table: "Events",
                column: "organizers_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
