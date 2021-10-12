using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Authentication;

namespace Wareship.Model.Users
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Relationship
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public List<CartDetail> CartDetails { get; set; }
    }
}
