using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Core.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
