using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqLabb2.Migrations
{
    /// <inheritdoc />
    public partial class undoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Students_FK_StudentId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_FK_StudentId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FK_StudentId",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FK_StudentId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FK_StudentId",
                table: "Classes",
                column: "FK_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Students_FK_StudentId",
                table: "Classes",
                column: "FK_StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
