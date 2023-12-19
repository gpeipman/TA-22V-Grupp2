using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_AspNetUsers_user_Id",
                table: "Event_Details");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_user_Id",
                table: "Event_Details");

            migrationBuilder.AddColumn<int>(
                name: "user_Id",
                table: "Receipts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "user_Id1",
                table: "Receipts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_Id",
                table: "Event_Details",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_Id1",
                table: "Event_Details",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_user_Id1",
                table: "Receipts",
                column: "user_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Details_user_Id1",
                table: "Event_Details",
                column: "user_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Details_AspNetUsers_user_Id1",
                table: "Event_Details",
                column: "user_Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id1",
                table: "Receipts",
                column: "user_Id1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Details_AspNetUsers_user_Id1",
                table: "Event_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_user_Id1",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_user_Id1",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Event_Details_user_Id1",
                table: "Event_Details");

            migrationBuilder.DropColumn(
                name: "user_Id",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "user_Id1",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "user_Id1",
                table: "Event_Details");

            migrationBuilder.AlterColumn<string>(
                name: "user_Id",
                table: "Event_Details",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
        }
    }
}
