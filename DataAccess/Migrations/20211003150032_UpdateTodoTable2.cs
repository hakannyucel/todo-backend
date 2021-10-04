using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
  public partial class UpdateTodoTable2 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
          name: "IsComplete",
          table: "todos",
          newName: "todo_is_complete");

      migrationBuilder.AlterColumn<bool>(
          name: "todo_is_complete",
          table: "todos",
          type: "bit",
          nullable: false,
          defaultValue: false,
          oldClrType: typeof(bool),
          oldType: "bit");

    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<bool>(
          name: "IsComplete",
          table: "todos",
          type: "bit",
          nullable: false,
          oldClrType: typeof(bool),
          oldType: "bit",
          oldDefaultValue: false);

    }
  }
}
