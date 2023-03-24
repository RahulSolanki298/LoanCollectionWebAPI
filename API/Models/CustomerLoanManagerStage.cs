using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class CustomerLoanManagerStage
    {
        public int Id { get; set; }
        public int? CustomerLoanManagerId { get; set; }
        public int? LoanStagesId { get; set; }
    }
}
