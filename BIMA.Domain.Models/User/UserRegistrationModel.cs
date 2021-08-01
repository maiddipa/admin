using BIMA.Common.Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BIMA.Domain.Models
{
    public class UserRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUniqueStamp { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public string CountryCode { get; set; }
        public int CityId { get; set; }
        public GenderEnum? Gender { get; set; }
        public string Employment { get; set; }
        public int? LanguageId { get; set; }
    }
}
