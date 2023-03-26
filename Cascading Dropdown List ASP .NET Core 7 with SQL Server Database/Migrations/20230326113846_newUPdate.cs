using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Migrations
{
    /// <inheritdoc />
    public partial class newUPdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "country",
                table: "Countries",
                newName: "countryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "CityName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "countryName",
                table: "Countries",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Cities",
                newName: "Name");
        }
    }
}
