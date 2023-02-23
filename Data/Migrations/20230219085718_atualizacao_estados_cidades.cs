using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao_estados_cidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Cidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Estados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Estados",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Estados",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Cidades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cidades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Cidades",
                type: "datetime2",
                nullable: true);
        }
    }
}
