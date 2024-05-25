using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TelefoneAjuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_DDD_DddId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_DddId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Telefone");

            migrationBuilder.RenameColumn(
                name: "DddId",
                table: "Telefone",
                newName: "NumeroDDD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroDDD",
                table: "Telefone",
                newName: "DddId");

            migrationBuilder.AddColumn<int>(
                name: "DDD",
                table: "Telefone",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_DddId",
                table: "Telefone",
                column: "DddId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_DDD_DddId",
                table: "Telefone",
                column: "DddId",
                principalTable: "DDD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
