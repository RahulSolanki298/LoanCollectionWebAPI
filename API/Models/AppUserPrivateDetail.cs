using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AppUserPrivateDetail
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string AadharCardNo { get; set; }
        public string AadharCardImagePath { get; set; }
        public string PancardNo { get; set; }
        public string PancardImagePath { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string Ifscode { get; set; }
        public string PassBookImgPath { get; set; }
        public string CheckBooKimgPath { get; set; }
        public string ProfileImgPath { get; set; }
    }
}
