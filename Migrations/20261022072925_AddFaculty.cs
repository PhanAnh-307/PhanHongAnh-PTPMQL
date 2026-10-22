using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Major",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Students",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentYear",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainingType",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FacultyName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "FacultyName" },
                values: new object[,]
                {
                    { "01", "Dầu khí" },
                    { "02", "Mỏ" },
                    { "03", "Địa chất & Khoa học Trái đất" },
                    { "04", "Kinh tế & Quản trị kinh doanh" },
                    { "05", "Công nghệ thông tin" },
                    { "06", "Trắc địa - Bản đồ và Quản lý đất đai" },
                    { "07", "Cơ - Điện" },
                    { "08", "Môi trường" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacultyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TrainingType",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }
    }
}
