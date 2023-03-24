using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public int? UserId { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeSalary { get; set; }
    }
}
