using System;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Ario_Hcm.Database.Models
{
    public class User : DatabaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Roles Role { get; set; }
    }
}
