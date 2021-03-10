using Auth.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateAsync(string email, string password);
    }
}

