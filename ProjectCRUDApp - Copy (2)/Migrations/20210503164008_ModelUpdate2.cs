using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCRUDApp.Migrations
{
    public partial class ModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_FoodID",
                table: "Recipes",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Foods_FoodID",
                table: "Recipes",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Foods_FoodID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_FoodID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Recipes");
        }
    }
}
