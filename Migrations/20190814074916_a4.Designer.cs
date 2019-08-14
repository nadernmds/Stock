﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Models;

namespace Stock.Migrations
{
    [DbContext(typeof(Stock_dbContext))]
    [Migration("20190814074916_a4")]
    partial class a4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stock.Models.ApproveUserPayments", b =>
                {
                    b.Property<int>("ApproveUserPaymentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("approveUserPaymentsID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("PaymentId")
                        .HasColumnName("paymentID");

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("ApproveUserPaymentsId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("ApproveUserPayments");
                });

            modelBuilder.Entity("Stock.Models.Approves", b =>
                {
                    b.Property<int>("ApproveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("approveID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApproverUserId")
                        .HasColumnName("approverUserID");

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("ApproveId");

                    b.HasIndex("ApproverUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Approves");
                });

            modelBuilder.Entity("Stock.Models.Banks", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bankID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .HasColumnName("bankName")
                        .HasMaxLength(50);

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Stock.Models.Cities", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnName("cityName")
                        .HasMaxLength(50);

                    b.Property<int?>("StateId")
                        .HasColumnName("stateID");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Stock.Models.Companies", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("companyID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnName("companyName")
                        .HasMaxLength(50);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Stock.Models.CostAndBenefits", b =>
                {
                    b.Property<int>("CostAndBenefitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("costAndBenefitID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BenefitPerUnit")
                        .HasColumnName("benefitPerUnit")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<long?>("StockAllocationId")
                        .HasColumnName("stockAllocationID");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("CostAndBenefitId");

                    b.HasIndex("StockAllocationId");

                    b.ToTable("CostAndBenefits");
                });

            modelBuilder.Entity("Stock.Models.Faqs", b =>
                {
                    b.Property<int>("FaqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("faqID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnName("answer");

                    b.Property<string>("Question")
                        .HasColumnName("question");

                    b.HasKey("FaqId");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("Stock.Models.InstalmentTemplates", b =>
                {
                    b.Property<int>("InstalmentTemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("instalmentTemplateID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("CompanyId")
                        .HasColumnName("companyID");

                    b.Property<int?>("Count")
                        .HasColumnName("count");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnName("fromDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Payday")
                        .HasColumnName("payday")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ToDate")
                        .HasColumnName("toDate")
                        .HasColumnType("datetime");

                    b.HasKey("InstalmentTemplateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("InstalmentTemplates");
                });

            modelBuilder.Entity("Stock.Models.Notifications", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("notificationID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.Property<int?>("UserGroupId")
                        .HasColumnName("userGroupID");

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Stock.Models.PaymentTypes", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("paymentTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasMaxLength(50);

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Stock.Models.Payments", b =>
                {
                    b.Property<long>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("paymentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("BillCode")
                        .HasColumnName("billCode")
                        .HasMaxLength(50);

                    b.Property<int?>("CostAndBenefitId")
                        .HasColumnName("costAndBenefitID");

                    b.Property<DateTime?>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<int?>("InstalmentTemplateId")
                        .HasColumnName("instalmentTemplateID");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnName("paymentTypeID");

                    b.Property<long?>("StockAllocationId")
                        .HasColumnName("stockAllocationID");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("PaymentId");

                    b.HasIndex("CostAndBenefitId");

                    b.HasIndex("InstalmentTemplateId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StockAllocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Stock.Models.States", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stateID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .HasColumnName("stateName")
                        .HasMaxLength(50);

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Stock.Models.StockAllocations", b =>
                {
                    b.Property<long>("StockAllocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stockAllocationID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Count")
                        .HasColumnName("count");

                    b.Property<long?>("PreviousStockAllocationId")
                        .HasColumnName("previousStockAllocationID");

                    b.Property<int?>("StockId")
                        .HasColumnName("stockID");

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("StockAllocationId");

                    b.HasIndex("PreviousStockAllocationId");

                    b.HasIndex("StockId");

                    b.HasIndex("UserId");

                    b.ToTable("StockAllocations");
                });

            modelBuilder.Entity("Stock.Models.Stocks", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stockID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnName("companyID");

                    b.Property<int?>("Count")
                        .HasColumnName("count");

                    b.Property<decimal?>("PricePerUnit")
                        .HasColumnName("pricePerUnit")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("title");

                    b.HasKey("StockId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Stock.Models.Transfers", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transferID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Count")
                        .HasColumnName("count");

                    b.Property<string>("Text")
                        .HasColumnName("text");

                    b.HasKey("TransferId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Stock.Models.UserCompanies", b =>
                {
                    b.Property<int>("UserCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userCompanyID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnName("companyID");

                    b.Property<int?>("UserId")
                        .HasColumnName("userID");

                    b.HasKey("UserCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("Stock.Models.UserGroups", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userGroupID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasColumnName("groupName")
                        .HasMaxLength(50);

                    b.HasKey("UserGroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Stock.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasMaxLength(300);

                    b.Property<string>("BankAccount")
                        .HasMaxLength(50);

                    b.Property<string>("BankBranch")
                        .HasColumnName("bankBranch")
                        .HasMaxLength(50);

                    b.Property<string>("BankBranchCode")
                        .HasColumnName("bankBranchCode")
                        .HasMaxLength(50);

                    b.Property<int?>("BankId")
                        .HasColumnName("bankID");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("birthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("BirthPlace")
                        .HasColumnName("birthPlace")
                        .HasColumnType("date");

                    b.Property<int?>("CityId")
                        .HasColumnName("cityID");

                    b.Property<string>("FatherName")
                        .HasColumnName("fatherName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnName("lastName")
                        .HasMaxLength(50);

                    b.Property<string>("Mail")
                        .HasColumnName("mail")
                        .HasMaxLength(50);

                    b.Property<string>("Mobile")
                        .HasColumnName("mobile")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("NationalCode")
                        .HasColumnName("nationalCode")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasMaxLength(50);

                    b.Property<string>("PersonnelCode")
                        .HasColumnName("personnelCode")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(100);

                    b.Property<string>("PostalCode")
                        .HasColumnName("postalCode")
                        .HasMaxLength(20);

                    b.Property<string>("Representor")
                        .HasColumnName("representor")
                        .HasMaxLength(50);

                    b.Property<string>("ShebaCode")
                        .HasColumnName("shebaCode")
                        .HasMaxLength(50);

                    b.Property<string>("ShenasNameCode")
                        .HasColumnName("shenasNameCode")
                        .HasMaxLength(20);

                    b.Property<int?>("UserGroupId")
                        .HasColumnName("userGroupID");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.HasIndex("BankId");

                    b.HasIndex("CityId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Stock.Models.ApproveUserPayments", b =>
                {
                    b.HasOne("Stock.Models.Payments", "Payment")
                        .WithMany("ApproveUserPayments")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_UserPayments_Payments")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("ApproveUserPayments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserPayments_Users");
                });

            modelBuilder.Entity("Stock.Models.Approves", b =>
                {
                    b.HasOne("Stock.Models.Users", "ApproverUser")
                        .WithMany("ApprovesApproverUser")
                        .HasForeignKey("ApproverUserId")
                        .HasConstraintName("FK_Approves_Users");

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("ApprovesUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Approves_Users1");
                });

            modelBuilder.Entity("Stock.Models.Cities", b =>
                {
                    b.HasOne("Stock.Models.States", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_Cities_States")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stock.Models.CostAndBenefits", b =>
                {
                    b.HasOne("Stock.Models.StockAllocations", "StockAllocation")
                        .WithMany("CostAndBenefits")
                        .HasForeignKey("StockAllocationId")
                        .HasConstraintName("FK_CostAndBenefits_StockAllocations")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stock.Models.InstalmentTemplates", b =>
                {
                    b.HasOne("Stock.Models.Companies", "Company")
                        .WithMany("InstalmentTemplates")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_InstalmentTemplates_Companies")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stock.Models.Notifications", b =>
                {
                    b.HasOne("Stock.Models.UserGroups", "UserGroup")
                        .WithMany("Notifications")
                        .HasForeignKey("UserGroupId")
                        .HasConstraintName("FK_Notifications_UserGroups");

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Notifications_Users");
                });

            modelBuilder.Entity("Stock.Models.Payments", b =>
                {
                    b.HasOne("Stock.Models.CostAndBenefits", "CostAndBenefit")
                        .WithMany("Payments")
                        .HasForeignKey("CostAndBenefitId")
                        .HasConstraintName("FK_Payments_CostAndBenefits");

                    b.HasOne("Stock.Models.InstalmentTemplates", "InstalmentTemplate")
                        .WithMany("Payments")
                        .HasForeignKey("InstalmentTemplateId")
                        .HasConstraintName("FK_Payments_InstalmentTemplates");

                    b.HasOne("Stock.Models.PaymentTypes", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .HasConstraintName("FK_Payments_PaymentTypes")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stock.Models.StockAllocations", "StockAllocation")
                        .WithMany("Payments")
                        .HasForeignKey("StockAllocationId")
                        .HasConstraintName("FK_Payments_StockAllocations");

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Payments_Users");
                });

            modelBuilder.Entity("Stock.Models.StockAllocations", b =>
                {
                    b.HasOne("Stock.Models.StockAllocations", "PreviousStockAllocation")
                        .WithMany("InversePreviousStockAllocation")
                        .HasForeignKey("PreviousStockAllocationId")
                        .HasConstraintName("FK_StockAllocations_StockAllocations");

                    b.HasOne("Stock.Models.Stocks", "Stock")
                        .WithMany("StockAllocations")
                        .HasForeignKey("StockId")
                        .HasConstraintName("FK_StockAllocations_Stocks")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("StockAllocations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_StockAllocations_Users");
                });

            modelBuilder.Entity("Stock.Models.Stocks", b =>
                {
                    b.HasOne("Stock.Models.Companies", "Company")
                        .WithMany("Stocks")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_Stocks_Companies")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Stock.Models.UserCompanies", b =>
                {
                    b.HasOne("Stock.Models.Companies", "Company")
                        .WithMany("UserCompanies")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_userCompanies_Companies")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Stock.Models.Users", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_userCompanies_Users");
                });

            modelBuilder.Entity("Stock.Models.Users", b =>
                {
                    b.HasOne("Stock.Models.Banks", "Bank")
                        .WithMany("Users")
                        .HasForeignKey("BankId")
                        .HasConstraintName("FK_Users_Banks");

                    b.HasOne("Stock.Models.Cities", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Users_Cities");

                    b.HasOne("Stock.Models.UserGroups", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .HasConstraintName("FK_Users_UserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
