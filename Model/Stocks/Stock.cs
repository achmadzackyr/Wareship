using System;
using System.Collections.Generic;
using System.Linq;
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
        public int IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Relationship
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public List<Order> Orders { get; set; }
    }
}
