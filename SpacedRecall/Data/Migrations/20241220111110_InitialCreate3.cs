using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpacedRecall.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Back",
                table: "CardType");

            migrationBuilder.DropColumn(
                name: "Front",
                table: "CardType");

            migrationBuilder.AddColumn<int>(
                name: "cardFieldsId",
                table: "CardType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CardField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardField", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardType_cardFieldsId",
                table: "CardType",
                column: "cardFieldsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardType_CardField_cardFieldsId",
                table: "CardType",
                column: "cardFieldsId",
                principalTable: "CardField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardType_CardField_cardFieldsId",
                table: "CardType");

            migrationBuilder.DropTable(
                name: "CardField");

            migrationBuilder.DropIndex(
                name: "IX_CardType_cardFieldsId",
                table: "CardType");

            migrationBuilder.DropColumn(
                name: "cardFieldsId",
                table: "CardType");

            migrationBuilder.AddColumn<string>(
                name: "Back",
                table: "CardType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Front",
                table: "CardType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
