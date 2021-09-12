using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wareship.Model.Products;
using Wareship.Model.Users;
using Wareship.Model.Transactions;

namespace Wareship.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Street { get; set; }
        public string Subdistrict { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }


        //relationship
        public int UserTierId { get; set; }
        public UserTier UserTier { get; set; }

        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public List<Product> Products { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
