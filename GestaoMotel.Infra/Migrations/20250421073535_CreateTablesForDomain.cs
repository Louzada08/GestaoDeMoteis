using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoMotel.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesForDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Acronym = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypePrice = table.Column<int>(type: "int", nullable: false),
                    ToleranceTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    HasSunday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasMonday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasTuesday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasWednesday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasThursday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasFriday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    HasSaturday = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    PeriodStartTimes = table.Column<TimeOnly>(type: "time", nullable: false),
                    PeriodEndTimes = table.Column<TimeOnly>(type: "time", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    InitialPromotionPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalPromotionPeriod = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCommand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpeningDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserInspectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CleaningUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCommand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DownloadedFrom = table.Column<int>(type: "int", nullable: true),
                    StateSuite = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTableTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MinimumUsageTime = table.Column<string>(type: "varchar(11)", nullable: false),
                    MaximumUsageTime = table.Column<string>(type: "varchar(11)", nullable: false),
                    Schedule_TimeForAdditionalCalculation = table.Column<TimeOnly>(type: "time", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PriceAdditional = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTableTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTableTime_PriceTable_PriceTableId",
                        column: x => x.PriceTableId,
                        principalTable: "PriceTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceTable_CategoryId",
                table: "PriceTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTableTime_PriceTableId",
                table: "PriceTableTime",
                column: "PriceTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCommand_CleaningUserId",
                table: "ServiceCommand",
                column: "CleaningUserId",
                unique: true,
                filter: "[CleaningUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCommand_SuiteId",
                table: "ServiceCommand",
                column: "SuiteId",
                unique: true,
                filter: "[SuiteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCommand_UserId",
                table: "ServiceCommand",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCommand_UserInspectionId",
                table: "ServiceCommand",
                column: "UserInspectionId",
                unique: true,
                filter: "[UserInspectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Suite_CategoryId",
                table: "Suite",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "PriceTableTime");

            migrationBuilder.DropTable(
                name: "ServiceCommand");

            migrationBuilder.DropTable(
                name: "Suite");

            migrationBuilder.DropTable(
                name: "PriceTable");
        }
    }
}
