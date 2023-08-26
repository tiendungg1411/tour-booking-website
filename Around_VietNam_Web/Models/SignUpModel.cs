using System.ComponentModel.DataAnnotations;

namespace Around_VietNam_Web.Models
{
    public class SignUpModel
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime Dob { get; set; }
    }
}
