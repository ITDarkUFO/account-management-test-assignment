using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class UserCreateDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? MiddleName { get; set; }

        [Required]
        public DateOnly? Birthday { get; set; }

        [Required]
        public string? PassportNumber { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
