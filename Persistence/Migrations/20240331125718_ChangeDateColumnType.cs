using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Activities",
                type: "text",
                nullable: false, // Если дата может быть null, установите true, иначе false
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Activities",
                type: "timestamp with time zone",
                nullable: false, // Установите то же значение nullability, что было до изменения
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
