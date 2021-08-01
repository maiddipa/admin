using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIMA.Domain.Models.User
{
    public class UserEmailConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
