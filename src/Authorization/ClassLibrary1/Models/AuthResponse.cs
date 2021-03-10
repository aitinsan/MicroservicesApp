using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Application.Models
{
    public class AuthResponse : ResponseBase
    {
        public AuthResponse(IDictionary<string, string> errors = null)
        {
            this.Errors = errors ?? this.EmptyErros();
        }

        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
