using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMultiUser.Web.Migrations
{
    /// <inheritdoc />
    public partial class UserCountAndTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCounts_AspNetUsers_UserId",
                table: "UserCounts");

            migrationBuilder.DropIndex(
                name: "IX_UserCounts_UserId",
                table: "UserCounts");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UserCounts",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TasksToDo",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Groups",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AspNetUsers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_UserCounts_UserId",
                table: "UserCounts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCounts_AspNetUsers_UserId",
                table: "UserCounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCounts_AspNetUsers_UserId",
                table: "UserCounts");

            migrationBuilder.DropIndex(
                name: "IX_UserCounts_UserId",
                table: "UserCounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserCounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TasksToDo");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_UserCounts_UserId",
                table: "UserCounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCounts_AspNetUsers_UserId",
                table: "UserCounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
