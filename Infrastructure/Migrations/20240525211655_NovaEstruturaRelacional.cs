using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NovaEstruturaRelacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DDD_Estado_EstadoId",
                table: "DDD");

            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Regiao_RegiaoId",
                table: "Estado");

            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Regiao_RegiaoId1",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_RegiaoId",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_RegiaoId1",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "RegiaoId1",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "CodigoDDD",
                table: "DDD");

            migrationBuilder.RenameColumn(
                name: "NumeroDDD",
                table: "Telefone",
                newName: "DDDId");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "DDD",
                newName: "RegiaoId");

            migrationBuilder.RenameIndex(
                name: "IX_DDD_EstadoId",
                table: "DDD",
                newName: "IX_DDD_RegiaoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Regiao",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Regiao",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estado",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "DDD",
                type: "VARCHAR(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_DDDId",
                table: "Telefone",
                column: "DDDId");

            migrationBuilder.CreateIndex(
                name: "IX_Regiao_EstadoId",
                table: "Regiao",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DDD_Regiao_RegiaoId",
                table: "DDD",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regiao_Estado_EstadoId",
                table: "Regiao",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_DDD_DDDId",
                table: "Telefone",
                column: "DDDId",
                principalTable: "DDD",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DDD_Regiao_RegiaoId",
                table: "DDD");

            migrationBuilder.DropForeignKey(
                name: "FK_Regiao_Estado_EstadoId",
                table: "Regiao");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_DDD_DDDId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_DDDId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Regiao_EstadoId",
                table: "Regiao");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Regiao");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "DDD");

            migrationBuilder.RenameColumn(
                name: "DDDId",
                table: "Telefone",
                newName: "NumeroDDD");

            migrationBuilder.RenameColumn(
                name: "RegiaoId",
                table: "DDD",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_DDD_RegiaoId",
                table: "DDD",
                newName: "IX_DDD_EstadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Regiao",
                type: "VARCHAR(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estado",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AddColumn<int>(
                name: "RegiaoId",
                table: "Estado",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegiaoId1",
                table: "Estado",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoDDD",
                table: "DDD",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_RegiaoId",
                table: "Estado",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_RegiaoId1",
                table: "Estado",
                column: "RegiaoId1",
                unique: true,
                filter: "[RegiaoId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DDD_Estado_EstadoId",
                table: "DDD",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Regiao_RegiaoId",
                table: "Estado",
                column: "RegiaoId",
                principalTable: "Regiao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Regiao_RegiaoId1",
                table: "Estado",
                column: "RegiaoId1",
                principalTable: "Regiao",
                principalColumn: "Id");
        }
    }
}
