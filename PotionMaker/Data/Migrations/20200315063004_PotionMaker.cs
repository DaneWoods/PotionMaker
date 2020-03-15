﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PotionMaker.Data.Migrations
{
    public partial class PotionMaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngName = table.Column<string>(nullable: true),
                    IngDescription = table.Column<string>(nullable: true),
                    IngStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngID);
                });

            migrationBuilder.CreateTable(
                name: "Potions",
                columns: table => new
                {
                    PotionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PotionName = table.Column<string>(nullable: true),
                    PotionDescription = table.Column<string>(nullable: true),
                    PotionStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potions", x => x.PotionID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RPotionName = table.Column<string>(nullable: true),
                    RIng1IngID = table.Column<int>(nullable: true),
                    RIng2IngID = table.Column<int>(nullable: true),
                    RIng3IngID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingredients_RIng1IngID",
                        column: x => x.RIng1IngID,
                        principalTable: "Ingredients",
                        principalColumn: "IngID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingredients_RIng2IngID",
                        column: x => x.RIng2IngID,
                        principalTable: "Ingredients",
                        principalColumn: "IngID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingredients_RIng3IngID",
                        column: x => x.RIng3IngID,
                        principalTable: "Ingredients",
                        principalColumn: "IngID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RIng1IngID",
                table: "Recipes",
                column: "RIng1IngID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RIng2IngID",
                table: "Recipes",
                column: "RIng2IngID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RIng3IngID",
                table: "Recipes",
                column: "RIng3IngID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Potions");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
