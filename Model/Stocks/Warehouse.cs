using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Users;

namespace Wareship.Model.Stocks
{
    public class Warehouse
    {
        public int Id { get; set; }

        [JsonIgnore]
        public List<Stock> Stocks { get; set; }
        public int AddressId { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
    }
}
