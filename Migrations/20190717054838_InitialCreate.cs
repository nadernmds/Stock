using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    bankID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bankName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.bankID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyID);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    faqID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    answer = table.Column<string>(nullable: true),
                    question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.faqID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    paymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.paymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    stateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    stateName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.stateID);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    transferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(nullable: true),
                    count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.transferID);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    userGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    groupName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.userGroupID);
                });

            migrationBuilder.CreateTable(
                name: "InstalmentTemplates",
                columns: table => new
                {
                    instalmentTemplateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    fromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    toDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    count = table.Column<int>(nullable: true),
                    payday = table.Column<string>(maxLength: 50, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    companyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalmentTemplates", x => x.instalmentTemplateID);
                    table.ForeignKey(
                        name: "FK_InstalmentTemplates_Companies",
                        column: x => x.companyID,
                        principalTable: "Companies",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    stockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pricePerUnit = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    count = table.Column<int>(nullable: true),
                    companyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.stockID);
                    table.ForeignKey(
                        name: "FK_Stocks_Companies",
                        column: x => x.companyID,
                        principalTable: "Companies",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    cityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cityName = table.Column<string>(maxLength: 50, nullable: true),
                    stateID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.cityID);
                    table.ForeignKey(
                        name: "FK_Cities_States",
                        column: x => x.stateID,
                        principalTable: "States",
                        principalColumn: "stateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    lastName = table.Column<string>(maxLength: 50, nullable: true),
                    fatherName = table.Column<string>(maxLength: 50, nullable: true),
                    personnelCode = table.Column<string>(maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    phone = table.Column<string>(maxLength: 100, nullable: true),
                    address = table.Column<string>(maxLength: 300, nullable: true),
                    postalCode = table.Column<string>(maxLength: 20, nullable: true),
                    birthDate = table.Column<DateTime>(type: "date", nullable: true),
                    birthPlace = table.Column<DateTime>(type: "date", nullable: true),
                    representor = table.Column<string>(maxLength: 50, nullable: true),
                    bankBranchCode = table.Column<string>(maxLength: 50, nullable: true),
                    nationalCode = table.Column<string>(maxLength: 50, nullable: true),
                    shenasNameCode = table.Column<string>(maxLength: 20, nullable: true),
                    BankAccount = table.Column<string>(maxLength: 50, nullable: true),
                    shebaCode = table.Column<string>(maxLength: 50, nullable: true),
                    bankBranch = table.Column<string>(maxLength: 50, nullable: true),
                    mail = table.Column<string>(maxLength: 50, nullable: true),
                    cityID = table.Column<int>(nullable: true),
                    bankID = table.Column<int>(nullable: true),
                    userGroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Users_Banks",
                        column: x => x.bankID,
                        principalTable: "Banks",
                        principalColumn: "bankID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Cities",
                        column: x => x.cityID,
                        principalTable: "Cities",
                        principalColumn: "cityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups",
                        column: x => x.userGroupID,
                        principalTable: "UserGroups",
                        principalColumn: "userGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Approves",
                columns: table => new
                {
                    approveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    approverUserID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approves", x => x.approveID);
                    table.ForeignKey(
                        name: "FK_Approves_Users",
                        column: x => x.approverUserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approves_Users1",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    userGroupID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.notificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_UserGroups",
                        column: x => x.userGroupID,
                        principalTable: "UserGroups",
                        principalColumn: "userGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockAllocations",
                columns: table => new
                {
                    stockAllocationID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    count = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true),
                    stockID = table.Column<int>(nullable: true),
                    previousStockAllocationID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAllocations", x => x.stockAllocationID);
                    table.ForeignKey(
                        name: "FK_StockAllocations_StockAllocations",
                        column: x => x.previousStockAllocationID,
                        principalTable: "StockAllocations",
                        principalColumn: "stockAllocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAllocations_Stocks",
                        column: x => x.stockID,
                        principalTable: "Stocks",
                        principalColumn: "stockID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAllocations_Users",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanies",
                columns: table => new
                {
                    userCompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    companyID = table.Column<int>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanies", x => x.userCompanyID);
                    table.ForeignKey(
                        name: "FK_userCompanies_Companies",
                        column: x => x.companyID,
                        principalTable: "Companies",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userCompanies_Users",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostAndBenefits",
                columns: table => new
                {
                    costAndBenefitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    benefitPerUnit = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    userID = table.Column<int>(nullable: true),
                    stockAllocationID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAndBenefits", x => x.costAndBenefitID);
                    table.ForeignKey(
                        name: "FK_CostAndBenefits_StockAllocations",
                        column: x => x.stockAllocationID,
                        principalTable: "StockAllocations",
                        principalColumn: "stockAllocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    paymentID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    billCode = table.Column<string>(maxLength: 50, nullable: true),
                    userID = table.Column<int>(nullable: true),
                    costAndBenefitID = table.Column<int>(nullable: true),
                    instalmentTemplateID = table.Column<int>(nullable: true),
                    stockAllocationID = table.Column<long>(nullable: true),
                    paymentTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.paymentID);
                    table.ForeignKey(
                        name: "FK_Payments_CostAndBenefits",
                        column: x => x.costAndBenefitID,
                        principalTable: "CostAndBenefits",
                        principalColumn: "costAndBenefitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_InstalmentTemplates",
                        column: x => x.instalmentTemplateID,
                        principalTable: "InstalmentTemplates",
                        principalColumn: "instalmentTemplateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes",
                        column: x => x.paymentTypeID,
                        principalTable: "PaymentTypes",
                        principalColumn: "paymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_StockAllocations",
                        column: x => x.stockAllocationID,
                        principalTable: "StockAllocations",
                        principalColumn: "stockAllocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApproveUserPayments",
                columns: table => new
                {
                    approveUserPaymentsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<int>(nullable: true),
                    paymentID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproveUserPayments", x => x.approveUserPaymentsID);
                    table.ForeignKey(
                        name: "FK_UserPayments_Payments",
                        column: x => x.paymentID,
                        principalTable: "Payments",
                        principalColumn: "paymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayments_Users",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approves_approverUserID",
                table: "Approves",
                column: "approverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_userID",
                table: "Approves",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_ApproveUserPayments_paymentID",
                table: "ApproveUserPayments",
                column: "paymentID");

            migrationBuilder.CreateIndex(
                name: "IX_ApproveUserPayments_userID",
                table: "ApproveUserPayments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_stateID",
                table: "Cities",
                column: "stateID");

            migrationBuilder.CreateIndex(
                name: "IX_CostAndBenefits_stockAllocationID",
                table: "CostAndBenefits",
                column: "stockAllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_InstalmentTemplates_companyID",
                table: "InstalmentTemplates",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userGroupID",
                table: "Notifications",
                column: "userGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userID",
                table: "Notifications",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_costAndBenefitID",
                table: "Payments",
                column: "costAndBenefitID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_instalmentTemplateID",
                table: "Payments",
                column: "instalmentTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_paymentTypeID",
                table: "Payments",
                column: "paymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_stockAllocationID",
                table: "Payments",
                column: "stockAllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_userID",
                table: "Payments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_StockAllocations_previousStockAllocationID",
                table: "StockAllocations",
                column: "previousStockAllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_StockAllocations_stockID",
                table: "StockAllocations",
                column: "stockID");

            migrationBuilder.CreateIndex(
                name: "IX_StockAllocations_userID",
                table: "StockAllocations",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_companyID",
                table: "Stocks",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_companyID",
                table: "UserCompanies",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_userID",
                table: "UserCompanies",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_bankID",
                table: "Users",
                column: "bankID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_cityID",
                table: "Users",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userGroupID",
                table: "Users",
                column: "userGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approves");

            migrationBuilder.DropTable(
                name: "ApproveUserPayments");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "UserCompanies");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "CostAndBenefits");

            migrationBuilder.DropTable(
                name: "InstalmentTemplates");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "StockAllocations");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
