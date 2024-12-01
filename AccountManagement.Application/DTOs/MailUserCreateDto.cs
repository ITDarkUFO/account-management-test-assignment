using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class MailUserCreateDto
    {
        [Required]
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public DateOnly? Birthday { get; set; }

        public string? PassportNumber { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public string? Address { get; set; }
    }
}
