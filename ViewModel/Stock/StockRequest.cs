using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Stock
{
    public class StockRequest
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public int IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ProductId { get; set; }
        public int OptionId { get; set; }
        public int WarehouseId { get; set; }
    }
}
