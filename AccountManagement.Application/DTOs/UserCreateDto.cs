﻿using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.DTOs
{
    public class UserCreateDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public DateOnly? Birthday { get; set; }

        [RegularExpression(@"^\d{4} \d{6}$")]
        public string? PassportNumber { get; set; }

        [RegularExpression(@"^7\d{10}$")]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
