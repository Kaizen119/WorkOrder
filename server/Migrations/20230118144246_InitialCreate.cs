using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    TechnicianEmail = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianID);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    WONum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateAssigned = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateComplete = table.Column<DateTime>(type: "datetime", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TechnicianComments = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TechnicianID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.WONum);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Technicians_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_TechnicianID",
                table: "WorkOrders",
                column: "TechnicianID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Technicians");
        }
    }
}
