using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciadorTime.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TimeIdIsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeId",
                table: "Jogadores",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeId",
                table: "Jogadores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
