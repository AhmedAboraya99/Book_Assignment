using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class hh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authors_NationalityId",
                table: "authors",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_authors_nationality_NationalityId",
                table: "authors",
                column: "NationalityId",
                principalTable: "nationality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authors_nationality_NationalityId",
                table: "authors");

            migrationBuilder.DropTable(
                name: "nationality");

            migrationBuilder.DropIndex(
                name: "IX_authors_NationalityId",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "authors");
        }
    }
}
