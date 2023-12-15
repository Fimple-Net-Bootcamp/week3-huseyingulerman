using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace week3_huseyingulerman.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodPet");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "MyProperty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MyProperty_PetId",
                table: "MyProperty",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Pets_PetId",
                table: "MyProperty",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Pets_PetId",
                table: "MyProperty");

            migrationBuilder.DropIndex(
                name: "IX_MyProperty_PetId",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "MyProperty");

            migrationBuilder.CreateTable(
                name: "FoodPet",
                columns: table => new
                {
                    FoodsId = table.Column<int>(type: "int", nullable: false),
                    PetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPet", x => new { x.FoodsId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_FoodPet_MyProperty_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodPet_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPet_PetsId",
                table: "FoodPet",
                column: "PetsId");
        }
    }
}
