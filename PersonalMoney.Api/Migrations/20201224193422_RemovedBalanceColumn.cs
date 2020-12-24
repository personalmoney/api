using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalMoney.Api.Migrations
{
    public partial class RemovedBalanceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.AlterColumn<decimal>(
                name: "InitialBalance",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InitialBalance",
                table: "Accounts",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Accounts",
                type: "double",
                nullable: true);
        }
    }
}
