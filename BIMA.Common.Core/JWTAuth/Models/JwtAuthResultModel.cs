using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BIMA.Common.Core.JWTAuth.Models
{
    public class JwtAuthResultModel
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
