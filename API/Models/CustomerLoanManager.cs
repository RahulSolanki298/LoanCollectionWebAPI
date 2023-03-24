using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CustomerLoanManager
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BranchId { get; set; }
        public DateTime? LoanApplyAmountDate { get; set; }
        public decimal? LoanApplyAmount { get; set; }
        public DateTime? SectionAmountDate { get; set; }
        public decimal? SectionAmount { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedById { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsNoOfDays { get; set; }
        public bool? IsNoOfWeeks { get; set; }
        public bool? IsNoOfMonths { get; set; }
        public bool? IsNoOfYear { get; set; }
        public string NoOfDays { get; set; }
        public string NoOfWeeks { get; set; }
        public string NoOfMonths { get; set; }
        public string NoOfYears { get; set; }
        public decimal? LoanIntrest { get; set; }
        public string LoanAccNo { get; set; }
        public DateTime? LoanDate { get; set; }
    }
}
