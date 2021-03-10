using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Infrastructure.Data
{
    public interface IAuthContext
    {
        DbSet<User> Users { get; set; }
    }
}
