namespace API.Dtos
{
    public class CompanyBranchDetails
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Certificate { get; set; }
        public string? CompanyLogo { get; set; }
        public DateTime? CompanyRegisterDate { get; set; }
        public bool? IsActivated { get; set; }
    }
}
