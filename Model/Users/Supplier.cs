using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Authentication;
using Wareship.Model.Products;

namespace Wareship.Model.Users
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Markup { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        //relationship
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int SubCategoryId { get; set; }
        [JsonIgnore]
        public SubCategory SubCategory { get; set; }
        public string CreatedById { get; set; }
        [JsonIgnore]
        public ApplicationUser CreatedBy { get; set; }
        public int UserStatusId { get; set; }
        [JsonIgnore]
        public UserStatus UserStatus { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }

    }
}
