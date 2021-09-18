using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Product
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double ChargeableWeight { get; set; }
        public string UserId { get; set; }
        public int ProductStatusId { get; set; }
        public int SubCategoryId { get; set; }
        public List<string> ImageUrl { get; set; }
    }
}
