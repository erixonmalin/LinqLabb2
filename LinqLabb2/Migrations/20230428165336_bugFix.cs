using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqLabb2.Migrations
{
    /// <inheritdoc />
    public partial class bugFix : Migration
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
                name: "Role",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FK_StudentId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Teachers",
                newName: "TRole");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Teachers",
                newName: "TLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Teachers",
                newName: "TFirstName");

            migrationBuilder.AddColumn<int>(
                name: "FK_ClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_FK_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FK_ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FK_ClassId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "TRole",
                table: "Teachers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "TLastName",
                table: "Teachers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "TFirstName",
                table: "Teachers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

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
