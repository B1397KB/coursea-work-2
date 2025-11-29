using System.ComponentModel.DataAnnotations;

namespace UserManageAPI.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }
    }
}
