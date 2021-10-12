using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Users;

namespace Wareship.Model.Transactions
{
    public class Consignee
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }


        public int AddressId { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        [JsonIgnore]
        public List<Transaction> Transactions { get; set; }
    }
}
