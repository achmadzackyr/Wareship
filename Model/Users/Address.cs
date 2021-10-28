using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Transactions;

namespace Wareship.Model.Users
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string SubdistrictId { get; set; }
        public string Subdistrict { get; set; }
        public string CityId { get; set; }
        public string City { get; set; }
        public string ProvinceId { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        //Relationship
        [JsonIgnore]
        public List<UserAddress> UserAddresses { get; set; }
    }
}
