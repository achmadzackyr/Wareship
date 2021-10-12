using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Stocks;

namespace Wareship.Model.Users
{
    public class CartDetail
    {
        public int Id { get; set; }
        public double SubtotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        //Relationship
        public int CartId { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
        public int StockId { get; set; }
        [JsonIgnore]
        public Stock Stock { get; set; }
    }
}
