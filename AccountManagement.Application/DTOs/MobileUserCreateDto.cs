using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class MobileUserCreateDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public DateOnly? Birthday { get; set; }

        public string? PassportNumber { get; set; }

        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
