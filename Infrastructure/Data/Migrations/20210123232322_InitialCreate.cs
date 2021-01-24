using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transcript_school",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Address = table.Column<string>(maxLength: 180, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transcript_school", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transcript_faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transcript_faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transcript_faculty_transcript_school_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "transcript_school",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transcript_department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    SchoolFacultyId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transcript_department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transcript_department_transcript_faculty_SchoolFacultyId",
                        column: x => x.SchoolFacultyId,
                        principalTable: "transcript_faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transcript_department_transcript_school_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "transcript_school",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transcript_department_SchoolFacultyId",
                table: "transcript_department",
                column: "SchoolFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_transcript_department_SchoolId",
                table: "transcript_department",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_transcript_faculty_SchoolId",
                table: "transcript_faculty",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transcript_department");

            migrationBuilder.DropTable(
                name: "transcript_faculty");

            migrationBuilder.DropTable(
                name: "transcript_school");
        }
    }
}
