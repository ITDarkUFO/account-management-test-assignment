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

        [Required]
        public required string PassportNumber { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
