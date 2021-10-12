using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Authentication;

namespace Wareship.Model.Users
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string Role { get; set; }

        //Relationship
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        public int AddressId { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }

    }
}
