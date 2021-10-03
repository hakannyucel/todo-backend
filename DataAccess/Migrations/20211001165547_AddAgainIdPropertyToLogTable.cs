using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
  public partial class AddAgainIdPropertyToLogTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<Guid>(
          name: "id",
          table: "logs",
          type: "uniqueidentifier",
          nullable: false,
          defaultValue: Guid.NewGuid());

      migrationBuilder.AddPrimaryKey(
          name: "PK_logs",
          table: "logs",
          column: "id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropPrimaryKey(
          name: "PK_logs",
          table: "logs");

      migrationBuilder.DropColumn(
          name: "id",
          table: "logs");
    }
  }
}
