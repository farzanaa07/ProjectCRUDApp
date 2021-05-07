using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class FoodMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PictureURL = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Cuisine = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_FoodID",
                table: "Restaurants",
                column: "FoodID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Foods_FoodID",
                table: "Restaurants",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Foods_FoodID",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_FoodID",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_FoodID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Recipes");
        }
    }
}
