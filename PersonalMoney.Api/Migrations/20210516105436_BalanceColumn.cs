using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalMoney.Api.Migrations
{
    public partial class BalanceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE FUNCTION getTotal(
    `accountId` INT,
    `userId` INT,
    `transDate` DATETIME,
    `fromAccountId` INT,
    `toAccountId` INT
)
RETURNS decimal(10,2)
DETERMINISTIC
BEGIN

Declare _total decimal(18,2);

select
        SUM(case t2.`Type`
        when 'Withdrawal' then -1 * t2.Amount
        when 'Deposit' then t2.Amount
        when 'Transfer' then case t2.ToAccountId when accountId then t2.Amount else -1 * t2.Amount end
        else t2.Amount END) INTO _total
    from
        Transactions t2
    where
        t2.`Date` <= transDate
        and t2.UserId = userId
        and NOT (`t2`.`IsDeleted`)
        and (fromAccountId = t2.AccountId or toAccountId = t2.AccountId or fromAccountId = t2.ToAccountId);

RETURN _total;

END");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Transactions",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Transactions");

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS getTotal");
        }
    }
}