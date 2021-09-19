using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Product;
using Wareship.ViewModel.Warehouse;

namespace Wareship.ViewModel.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public int IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int OptionId { get; set; }
        public OptionDTO Option { get; set; }
        public int WarehouseId { get; set; }
        public WarehouseDTO Warehouse { get; set; }
    }
}
