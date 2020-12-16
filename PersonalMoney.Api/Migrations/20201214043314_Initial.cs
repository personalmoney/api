using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PersonalMoney.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Icon = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    ToAccountId = table.Column<int>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: true),
                    PayeeId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ToAmount = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: true),
                    Notes = table.Column<string>(maxLength: 500, nullable: true),
                    Number = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    AccountTypeId = table.Column<int>(nullable: false),
                    Balance = table.Column<double>(nullable: true),
                    InitialBalance = table.Column<double>(nullable: false),
                    MinimumBalance = table.Column<double>(nullable: false),
                    CreditLimit = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<int>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    IncludeInBalance = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ExcludeFromDashboard = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    TagId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTags_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true),
                    UpdatedTime = table.Column<DateTime>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    PayeeId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTransactions_Payees_PayeeId",
                        column: x => x.PayeeId,
                        principalTable: "Payees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubTransactions_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubTransactions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_PayeeId",
                table: "SubTransactions",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_SubCategoryId",
                table: "SubTransactions",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_TransactionId",
                table: "SubTransactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTags_TagId",
                table: "TransactionTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTags_TransactionId",
                table: "TransactionTags",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SubTransactions");

            migrationBuilder.DropTable(
                name: "TransactionTags");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Payees");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
