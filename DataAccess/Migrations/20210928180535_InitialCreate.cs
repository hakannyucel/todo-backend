using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    todo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    todo_task = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    todo_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    todo_created_date = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValueSql: "GetDate()"),
                    todo_due_date = table.Column<DateTime>(type: "Datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.todo_id);
                });

            migrationBuilder.CreateTable(
                name: "todo_tag",
                columns: table => new
                {
                    todo_tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    todo_tag_todo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    todo_tag_tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo_tag", x => x.todo_tag_id);
                    table.ForeignKey(
                        name: "FK_todo_tag_tags_todo_tag_tag_id",
                        column: x => x.todo_tag_tag_id,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_todo_tag_todos_todo_tag_todo_id",
                        column: x => x.todo_tag_todo_id,
                        principalTable: "todos",
                        principalColumn: "todo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_todo_tag_todo_tag_tag_id",
                table: "todo_tag",
                column: "todo_tag_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_todo_tag_todo_tag_todo_id",
                table: "todo_tag",
                column: "todo_tag_todo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo_tag");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "todos");
        }
    }
}
