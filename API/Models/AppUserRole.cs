using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class AppUserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
