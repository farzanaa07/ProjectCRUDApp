using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCRUDApp.Migrations
{
    public partial class UpdateMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Recipes_RecipeID",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_RecipeID",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RecipeID",
                table: "Restaurants",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Recipes_RecipeID",
                table: "Restaurants",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
