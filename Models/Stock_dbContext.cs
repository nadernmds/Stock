using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stock.Models
{
    public partial class Stock_dbContext : DbContext
    {
        public Stock_dbContext()
        {
        }

        public Stock_dbContext(DbContextOptions<Stock_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApproveUserPayments> ApproveUserPayments { get; set; }
        public virtual DbSet<Approves> Approves { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CostAndBenefits> CostAndBenefits { get; set; }
        public virtual DbSet<Faqs> Faqs { get; set; }
        public virtual DbSet<InstalmentTemplates> InstalmentTemplates { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StockAllocations> StockAllocations { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<UserCompanies> UserCompanies { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLazyLoadingProxies(false)
                                     //.UseSqlServer("Data Source=.;Initial Catalog=stock_db;Persist Security Info=True;User ID=sa;Password=1371");
                                                                 .UseSqlServer("Data Source=192.168.1.213;Initial Catalog=stock_db;Persist Security Info=True;User ID=sa;Password=rzk123");

                //.UseSqlServer("Data Source=185.165.116.34,1436;Initial Catalog=Stock;Persist Security Info=True;User ID=stock;Password=rzk123!@#");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ApproveUserPayments>(entity =>
            {
                entity.Property(e => e.ApproveUserPaymentsId).HasColumnName("approveUserPaymentsID");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.ApproveUserPayments)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserPayments_Payments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApproveUserPayments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPayments_Users");
            });

            modelBuilder.Entity<Approves>(entity =>
            {
                entity.HasKey(e => e.ApproveId);

                entity.Property(e => e.ApproveId).HasColumnName("approveID");

                entity.Property(e => e.ApproverUserId).HasColumnName("approverUserID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.ApproverUser)
                    .WithMany(p => p.ApprovesApproverUser)
                    .HasForeignKey(d => d.ApproverUserId)
                    .HasConstraintName("FK_Approves_Users");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApprovesUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Approves_Users1");
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.Property(e => e.BankId).HasColumnName("bankID");

                entity.Property(e => e.BankName)
                    .HasColumnName("bankName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.CityName)
                    .HasColumnName("cityName")
                    .HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CostAndBenefits>(entity =>
            {
                entity.HasKey(e => e.CostAndBenefitId);

                entity.Property(e => e.CostAndBenefitId).HasColumnName("costAndBenefitID");

                entity.Property(e => e.BenefitPerUnit)
                    .HasColumnName("benefitPerUnit")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StockAllocationId).HasColumnName("stockAllocationID");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.StockAllocation)
                    .WithMany(p => p.CostAndBenefits)
                    .HasForeignKey(d => d.StockAllocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CostAndBenefits_StockAllocations");
            });

            modelBuilder.Entity<Faqs>(entity =>
            {
                entity.HasKey(e => e.FaqId);

                entity.Property(e => e.FaqId).HasColumnName("faqID");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.Question).HasColumnName("question");
            });

            modelBuilder.Entity<InstalmentTemplates>(entity =>
            {
                entity.HasKey(e => e.InstalmentTemplateId);

                entity.Property(e => e.InstalmentTemplateId).HasColumnName("instalmentTemplateID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Payday)
                    .HasColumnName("payday")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InstalmentTemplates)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_InstalmentTemplates_Companies");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.Property(e => e.NotificationId).HasColumnName("notificationID");

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_Notifications_UserGroups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notifications_Users");
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);

                entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeID");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BillCode)
                    .HasColumnName("billCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CostAndBenefitId).HasColumnName("costAndBenefitID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstalmentTemplateId).HasColumnName("instalmentTemplateID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeID");

                entity.Property(e => e.StockAllocationId).HasColumnName("stockAllocationID");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.CostAndBenefit)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CostAndBenefitId)
                    .HasConstraintName("FK_Payments_CostAndBenefits");

                entity.HasOne(d => d.InstalmentTemplate)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.InstalmentTemplateId)
                    .HasConstraintName("FK_Payments_InstalmentTemplates");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Payments_PaymentTypes");

                entity.HasOne(d => d.StockAllocation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StockAllocationId)
                    .HasConstraintName("FK_Payments_StockAllocations");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Payments_Users");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.Property(e => e.StateName)
                    .HasColumnName("stateName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StockAllocations>(entity =>
            {
                entity.HasKey(e => e.StockAllocationId);

                entity.Property(e => e.StockAllocationId).HasColumnName("stockAllocationID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.PreviousStockAllocationId).HasColumnName("previousStockAllocationID");

                entity.Property(e => e.StockId).HasColumnName("stockID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.PreviousStockAllocation)
                    .WithMany(p => p.InversePreviousStockAllocation)
                    .HasForeignKey(d => d.PreviousStockAllocationId)
                    .HasConstraintName("FK_StockAllocations_StockAllocations");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockAllocations)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StockAllocations_Stocks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StockAllocations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_StockAllocations_Users");
            });

            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(e => e.StockId);

                entity.Property(e => e.StockId).HasColumnName("stockID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.PricePerUnit)
                    .HasColumnName("pricePerUnit")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Stocks_Companies");
            });

            modelBuilder.Entity<Transfers>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.Property(e => e.TransferId).HasColumnName("transferID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<UserCompanies>(entity =>
            {
                entity.HasKey(e => e.UserCompanyId);

                entity.Property(e => e.UserCompanyId).HasColumnName("userCompanyID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_userCompanies_Companies");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_userCompanies_Users");
            });

            modelBuilder.Entity<UserGroups>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupID");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.BankAccount).HasMaxLength(50);

                entity.Property(e => e.BankBranch)
                    .HasColumnName("bankBranch")
                    .HasMaxLength(50);

                entity.Property(e => e.BankBranchCode)
                    .HasColumnName("bankBranchCode")
                    .HasMaxLength(50);

                entity.Property(e => e.BankId).HasColumnName("bankID");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasColumnType("date");

                entity.Property(e => e.BirthPlace)
                    .HasColumnName("birthPlace")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.CityId).HasColumnName("cityID");

                entity.Property(e => e.FatherName)
                    .HasColumnName("fatherName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NationalCode)
                    .HasColumnName("nationalCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PersonnelCode)
                    .HasColumnName("personnelCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postalCode")
                    .HasMaxLength(20);

                entity.Property(e => e.Representor)
                    .HasColumnName("representor")
                    .HasMaxLength(50);

                entity.Property(e => e.ShebaCode)
                    .HasColumnName("shebaCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ShenasNameCode)
                    .HasColumnName("shenasNameCode")
                    .HasMaxLength(20);

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupID");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Users_Banks");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Users_Cities");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_Users_UserGroups");
            });
        }
    }
}
