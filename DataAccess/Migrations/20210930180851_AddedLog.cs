using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_tag_tags_todo_tag_tag_id",
                table: "todo_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_todo_tag_todos_todo_tag_todo_id",
                table: "todo_tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todo_tag",
                table: "todo_tag");

            migrationBuilder.RenameTable(
                name: "todo_tag",
                newName: "todo_tags");

            migrationBuilder.RenameIndex(
                name: "IX_todo_tag_todo_tag_todo_id",
                table: "todo_tags",
                newName: "IX_todo_tags_todo_tag_todo_id");

            migrationBuilder.RenameIndex(
                name: "IX_todo_tag_todo_tag_tag_id",
                table: "todo_tags",
                newName: "IX_todo_tags_todo_tag_tag_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo_tags",
                table: "todo_tags",
                column: "todo_tag_id");

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    audit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_todo_tags_tags_todo_tag_tag_id",
                table: "todo_tags",
                column: "todo_tag_tag_id",
                principalTable: "tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_todo_tags_todos_todo_tag_todo_id",
                table: "todo_tags",
                column: "todo_tag_todo_id",
                principalTable: "todos",
                principalColumn: "todo_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_tags_tags_todo_tag_tag_id",
                table: "todo_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_todo_tags_todos_todo_tag_todo_id",
                table: "todo_tags");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todo_tags",
                table: "todo_tags");

            migrationBuilder.RenameTable(
                name: "todo_tags",
                newName: "todo_tag");

            migrationBuilder.RenameIndex(
                name: "IX_todo_tags_todo_tag_todo_id",
                table: "todo_tag",
                newName: "IX_todo_tag_todo_tag_todo_id");

            migrationBuilder.RenameIndex(
                name: "IX_todo_tags_todo_tag_tag_id",
                table: "todo_tag",
                newName: "IX_todo_tag_todo_tag_tag_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo_tag",
                table: "todo_tag",
                column: "todo_tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_tag_tags_todo_tag_tag_id",
                table: "todo_tag",
                column: "todo_tag_tag_id",
                principalTable: "tags",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_todo_tag_todos_todo_tag_todo_id",
                table: "todo_tag",
                column: "todo_tag_todo_id",
                principalTable: "todos",
                principalColumn: "todo_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
