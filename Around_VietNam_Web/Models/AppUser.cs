using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Around_VietNam_Web.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
    }
}
