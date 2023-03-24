using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CustomerLoanCard
    {
        public int Id { get; set; }
        public string LoanAccNo { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public decimal? InstAmount { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Intrest { get; set; }
        public decimal? OsPricipal { get; set; }
        public string PaiderName { get; set; }
        public decimal? AmountCollected { get; set; }
        public bool? PaidStatus { get; set; }
    }
}
