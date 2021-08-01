using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BIMA.Domain.Models.User
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
