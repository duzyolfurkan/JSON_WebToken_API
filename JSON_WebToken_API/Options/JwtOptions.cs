﻿namespace JSON_WebToken_API.Options
{
    public class JwtOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public TimeSpan ExpiredTime { get; set; }
    }
}
