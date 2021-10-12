using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Products;
using Wareship.Model.Transactions;

namespace Wareship.Model.Stocks
{
    public class Stock
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Relationship
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int OptionId { get; set; }
        [JsonIgnore]
        public Option Option { get; set; }
        public int WarehouseId { get; set; }
        [JsonIgnore]
        public Warehouse Warehouse { get; set; }

        public List<Order> Orders { get; set; }
    }
}
