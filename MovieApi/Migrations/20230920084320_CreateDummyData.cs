using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "created_at", "description", "image", "rating", "title", "updated_at" },
                values: new object[] { 1, new DateTime(2023, 9, 20, 15, 43, 20, 115, DateTimeKind.Local).AddTicks(5301), "Film Horor tahun2022", "", 7f, "Pengabdi Setan 2", new DateTime(2023, 9, 20, 15, 43, 20, 115, DateTimeKind.Local).AddTicks(5315) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
