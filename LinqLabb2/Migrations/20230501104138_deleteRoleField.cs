using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqLabb2.Migrations
{
    /// <inheritdoc />
    public partial class deleteRoleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TRole",
                table: "Teachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TRole",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
