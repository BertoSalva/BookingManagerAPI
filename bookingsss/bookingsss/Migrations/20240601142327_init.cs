using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookingsss.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ChildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ChildID);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentID);
                });

            migrationBuilder.CreateTable(
                name: "Psychologist",
                columns: table => new
                {
                    PsychologistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologist", x => x.PsychologistID);
                });

            migrationBuilder.CreateTable(
                name: "BookingRequest",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    ChildID = table.Column<int>(type: "int", nullable: false),
                    PsychologistID = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequest", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_BookingRequest_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRequest_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRequest_Psychologist_PsychologistID",
                        column: x => x.PsychologistID,
                        principalTable: "Psychologist",
                        principalColumn: "PsychologistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Child",
                columns: new[] { "ChildID", "ChildName", "EmailAddress" },
                values: new object[,]
                {
                    { 1, "Child 1", null },
                    { 2, "Child 2", null }
                });

            migrationBuilder.InsertData(
                table: "Parent",
                columns: new[] { "ParentID", "EmailAddress", "ParentName" },
                values: new object[,]
                {
                    { 1, null, "Parent 1" },
                    { 2, null, "Parent 2" }
                });

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: new[] { "PsychologistID", "EmailAddress", "PsychologistName" },
                values: new object[,]
                {
                    { 1, null, "Psychologist 1" },
                    { 2, null, "Psychologist 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_ChildID",
                table: "BookingRequest",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_ParentID",
                table: "BookingRequest",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_PsychologistID",
                table: "BookingRequest",
                column: "PsychologistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRequest");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Psychologist");
        }
    }
}
