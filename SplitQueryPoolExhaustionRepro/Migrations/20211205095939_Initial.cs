using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitQueryPoolExhaustionRepro.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Margherita" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Marinara" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Calzone " });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 1, "Cheese", 1, 1 },
                    { 2, "Tomato", 2, 2 },
                    { 3, "Oregano", 3, 3 },
                    { 4, "Cheese", 1, 3 },
                    { 5, "Tomato", 2, 4 },
                    { 6, "Oregano", 3, 5 },
                    { 7, "Cheese", 1, 6 },
                    { 8, "Tomato", 2, 7 },
                    { 9, "Oregano", 3, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
