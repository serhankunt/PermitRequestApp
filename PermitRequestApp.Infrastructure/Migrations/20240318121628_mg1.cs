using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PermitRequestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADUser_ADUser_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ADUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CumulativeLeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumulativeLeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CumulativeLeaveRequests_ADUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ADUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUser_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "ADUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ADUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUser_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "ADUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CumulativeLeaveRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_ADUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ADUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_CumulativeLeaveRequests_CumulativeLeaveRequestId",
                        column: x => x.CumulativeLeaveRequestId,
                        principalTable: "CumulativeLeaveRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ADUser",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ManagerId", "UserType" },
                values: new object[,]
                {
                    { new Guid("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1"), "ozgetoksoz@gmail.com", "Özge", "Toksöz", null, 30 },
                    { new Guid("88204738-994b-4999-b752-78e071ba9d1f"), "serhankunt@gmail.com", "H. Serhan", "Kunt", new Guid("9a000b64-a2c8-4102-b243-4c5bd4d5a9c1"), 10 },
                    { new Guid("2a2e822c-b1cf-422f-a8ae-6307e0f03a77"), "betulkunt@gmail.com", "Betül", "Kunt", new Guid("88204738-994b-4999-b752-78e071ba9d1f"), 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADUser_ManagerId",
                table: "ADUser",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CumulativeLeaveRequests_UserId",
                table: "CumulativeLeaveRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_AssignedUserId",
                table: "LeaveRequests",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_CreatedById",
                table: "LeaveRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LastModifiedById",
                table: "LeaveRequests",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CumulativeLeaveRequestId",
                table: "Notifications",
                column: "CumulativeLeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "CumulativeLeaveRequests");

            migrationBuilder.DropTable(
                name: "ADUser");
        }
    }
}
