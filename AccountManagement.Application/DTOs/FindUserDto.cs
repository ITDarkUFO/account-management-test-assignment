using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class FindUserDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        [RegularExpression(@"^7\d{10}$")]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
