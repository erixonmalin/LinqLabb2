using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqLabb2.Migrations
{
    /// <inheritdoc />
    public partial class fiFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_FK_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FK_ClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "ClassesClassId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassesClassId",
                table: "Students",
                column: "ClassesClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassesClassId",
                table: "Students",
                column: "ClassesClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassesClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassesClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassesClassId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FK_ClassId",
                table: "Students",
                column: "FK_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_FK_ClassId",
                table: "Students",
                column: "FK_ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
