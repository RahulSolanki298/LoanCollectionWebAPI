namespace API.Dtos
{
    public class CustomerLoanDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BranchId { get; set; }
        public DateTime? LoanApplyAmountDate { get; set; }
        public decimal? LoanApplyAmount { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsNoOfDays { get; set; }
        public bool? IsNoOfWeeks { get; set; }
        public bool? IsNoOfMonths { get; set; }
        public bool? IsNoOfYear { get; set; }
        public string? NoOfDays { get; set; }
        public string? NoOfWeeks { get; set; }
        public string? NoOfMonths { get; set; }
        public string? NoOfYears { get; set; }
        public decimal? LoanIntrest { get; set; }
        public string? LoanAccNo { get; set; }
        public DateTime? LoanDate { get; set; }
        public string CurrentStage { get; set; }

    }
}
