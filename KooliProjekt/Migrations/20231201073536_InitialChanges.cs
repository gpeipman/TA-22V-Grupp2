using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_Id",
                table: "Receipts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "event_Id",
                table: "Event_Details",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_user_Id",
                table: "Receipts",
                column: "user_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_event_Id",
                table: "Event_Details",
                column: "event_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_Events_event_Id",
                table: "Event_Details",
                column: "event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id",
                table: "Receipts",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_Events_event_Id",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_user_Id",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_event_Id",
                table: "Event_Details");

            migrationBuilder.DropColumn(
                name: "user_Id",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "event_Id",
                table: "Event_Details");
        }
    }
}
