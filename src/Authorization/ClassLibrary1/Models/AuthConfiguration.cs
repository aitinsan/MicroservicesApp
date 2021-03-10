using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Application.Models
{
    public class AuthConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
