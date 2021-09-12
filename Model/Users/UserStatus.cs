using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Authentication;

namespace Wareship.Model.Users
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
