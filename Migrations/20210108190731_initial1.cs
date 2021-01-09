using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CordFortPersonalNoteManager.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "note",
                columns: new[] { "NoteId", "Content", "DateCreated", "DocumentPath", "IsArchived", "Title", "UserID" },
                values: new object[] { 1L, "TestContent1", new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Test1", 1L });

            migrationBuilder.InsertData(
                table: "note",
                columns: new[] { "NoteId", "Content", "DateCreated", "DocumentPath", "IsArchived", "Title", "UserID" },
                values: new object[] { 2L, "TestContent2", new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Test2", 2L });

            migrationBuilder.InsertData(
                table: "note",
                columns: new[] { "NoteId", "Content", "DateCreated", "DocumentPath", "IsArchived", "Title", "UserID" },
                values: new object[] { 3L, "TestContent2", new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Test3", 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "note",
                keyColumn: "NoteId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "note",
                keyColumn: "NoteId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "note",
                keyColumn: "NoteId",
                keyValue: 3L);
        }
    }
}
