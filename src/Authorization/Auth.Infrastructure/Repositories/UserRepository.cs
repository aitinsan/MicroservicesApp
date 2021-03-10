using Auth.Core.Entities;
using Auth.Core.Repositories;
using Auth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AuthContext authContext) : base(authContext)
        {
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            return await this.authContext.Users.FirstOrDefaultAsync(_ => _.Email.Equals(email) && _.Password.Equals(password));
        }
    }
}
