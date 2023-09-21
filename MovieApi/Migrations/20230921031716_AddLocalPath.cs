using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "image_path", "updated_at" },
                values: new object[] { new DateTime(2023, 9, 21, 10, 17, 16, 256, DateTimeKind.Local).AddTicks(8883), null, new DateTime(2023, 9, 21, 10, 17, 16, 256, DateTimeKind.Local).AddTicks(8893) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "created_at", "description", "image", "image_path", "rating", "title", "updated_at" },
                values: new object[] { 2, new DateTime(2023, 9, 21, 10, 17, 16, 256, DateTimeKind.Local).AddTicks(8896), "Film Horor tahun2022", "", null, 8f, "Pengabdi Setan 1", new DateTime(2023, 9, 21, 10, 17, 16, 256, DateTimeKind.Local).AddTicks(8897) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "image_path",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
