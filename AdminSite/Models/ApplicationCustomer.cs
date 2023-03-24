using Microsoft.Build.Framework;

namespace AdminSite.Models
{
    public partial class ApplicationCustomer
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Gender { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string WhatsAppNo { get; set; }

        [Required]
        public string EmailId { get; set; }

        public int? CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? BranchId { get; set; }

        public string BranchName { get; set; }

        public bool? IsActive { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string LoanAppAccountNo { get; set; }
    }
}
