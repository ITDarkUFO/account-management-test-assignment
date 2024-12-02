using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class WebUserCreateDto
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string MiddleName { get; set; }

        [Required]
        public required DateOnly Birthday { get; set; }

        [Required, RegularExpression(@"^\d{4} \d{6}$")]
        public required string PassportNumber { get; set; }

        [Required]
        [RegularExpression("^7\\d{10}$")]
        public required string PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
