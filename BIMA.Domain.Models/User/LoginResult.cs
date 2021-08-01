using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace BIMA.Domain.Models.User
{
    public class LoginResult
    {
        [JsonPropertyName("username")]
        [EmailAddress]
        public string UserName { get; set; }

        [JsonPropertyName("roles")]
        public IList<string> Roles { get; set; }

        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("userAvatar")]
        public string UserAvatar { get; set; }
    }
}
