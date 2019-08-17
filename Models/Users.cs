using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Users
    {
        public Users()
        {
            ApproveUserPayments = new HashSet<ApproveUserPayments>();
            ApprovesApproverUser = new HashSet<Approves>();
            ApprovesUser = new HashSet<Approves>();
            Notifications = new HashSet<Notifications>();
            Payments = new HashSet<Payments>();
            StockAllocations = new HashSet<StockAllocations>();
            UserCompanies = new HashSet<UserCompanies>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string PersonnelCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Representor { get; set; }
        public string BankBranchCode { get; set; }
        public string NationalCode { get; set; }
        public string ShenasNameCode { get; set; }
        public string BankAccount { get; set; }
        public string ShebaCode { get; set; }
        public string BankBranch { get; set; }
        public string Mail { get; set; }
        public int? CityId { get; set; }
        public int? BankId { get; set; }
        public int? UserGroupId { get; set; }

        public virtual Banks Bank { get; set; }
        public virtual Cities City { get; set; }
        public virtual UserGroups UserGroup { get; set; }
        public virtual ICollection<ApproveUserPayments> ApproveUserPayments { get; set; }
        public virtual ICollection<Approves> ApprovesApproverUser { get; set; }
        public virtual ICollection<Approves> ApprovesUser { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<StockAllocations> StockAllocations { get; set; }
        public virtual ICollection<UserCompanies> UserCompanies { get; set; }
    }
}
