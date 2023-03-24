using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class EmployeeSalaryManager
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? SalaryDate { get; set; }
        public string NoOfDays { get; set; }
        public string PresentDays { get; set; }
        public string Salary { get; set; }
        public string SalaryStatus { get; set; }
    }
}
