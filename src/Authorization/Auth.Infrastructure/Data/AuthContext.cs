using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Infrastructure.Data
{
    public class AuthContext : DbContext, IAuthContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
