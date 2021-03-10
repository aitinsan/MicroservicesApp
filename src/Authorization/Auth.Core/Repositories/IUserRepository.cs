using Auth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}
