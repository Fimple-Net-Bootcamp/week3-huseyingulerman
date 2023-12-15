using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace week3_huseyingulerman.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_AppUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AppUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AppUserId1",
                table: "Pets",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_AppUserId1",
                table: "Pets",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_AppUserId1",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AppUserId1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AppUserId",
                table: "Pets",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_AppUserId",
                table: "Pets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
