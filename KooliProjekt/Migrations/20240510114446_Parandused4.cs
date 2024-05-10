using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Migrations
{
    /// <inheritdoc />
    public partial class Parandused4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_AspNetUsers_user_Id",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_Events_event_Id",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_user_Id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Events_event_Id",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_event_Id",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_user_Id",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Events_user_Id",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_event_Id",
                table: "Event_Details");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_user_Id",
                table: "Event_Details");

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "Receipts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Receipts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "eventId",
                table: "Event_Details",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Event_Details",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_eventId",
                table: "Receipts",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_userId",
                table: "Receipts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_userId",
                table: "Events",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_eventId",
                table: "Event_Details",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_userId",
                table: "Event_Details",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_AspNetUsers_userId",
                table: "Event_Details",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_Events_eventId",
                table: "Event_Details",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_userId",
                table: "Events",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_userId",
                table: "Receipts",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Events_eventId",
                table: "Receipts",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_AspNetUsers_userId",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_Events_eventId",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_userId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_userId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Events_eventId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_eventId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_userId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Events_userId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_eventId",
                table: "Event_Details");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_userId",
                table: "Event_Details");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "eventId",
                table: "Event_Details");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Event_Details");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_event_Id",
                table: "Receipts",
                column: "event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_user_Id",
                table: "Receipts",
                column: "user_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_user_Id",
                table: "Events",
                column: "user_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_event_Id",
                table: "Event_Details",
                column: "event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_user_Id",
                table: "Event_Details",
                column: "user_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_AspNetUsers_user_Id",
                table: "Event_Details",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_Events_event_Id",
                table: "Event_Details",
                column: "event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_user_Id",
                table: "Events",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id",
                table: "Receipts",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Events_event_Id",
                table: "Receipts",
                column: "event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
