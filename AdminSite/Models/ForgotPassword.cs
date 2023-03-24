namespace AdminSite.Models
{
	public class ForgotPassword
	{
		public int EmailId { get; set; }
	}

    public class ChangePassword
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
