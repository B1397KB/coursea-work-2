using System.ComponentModel.DataAnnotations;

namespace EventApp.Client.Models
{
    // Registration model used by the registration form
    public class RegisterModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}
