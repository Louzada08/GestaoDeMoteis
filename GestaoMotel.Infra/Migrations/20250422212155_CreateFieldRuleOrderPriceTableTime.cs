using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoMotel.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateFieldRuleOrderPriceTableTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RuleOrder",
                table: "PriceTableTime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RuleOrder",
                table: "PriceTableTime");
        }
    }
}
