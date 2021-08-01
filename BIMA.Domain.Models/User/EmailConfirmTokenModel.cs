using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace BIMA.Domain.Models.User
{
    public class EmailConfirmTokenModel
    {
        [JsonPropertyName("emailToken")]
        public string EmailToken { get; set; }

        [JsonPropertyName("email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
