using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Auth;
using Wareship.ViewModel.Category;
using Wareship.ViewModel.Stock;

namespace Wareship.ViewModel.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PriceString { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double ChargeableWeight { get; set; }
        public string UserId { get; set; }
        public int ProductStatusId { get; set; }
        public string ProductStatusName { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }
        public List<StockDTO> Stocks { get; set; }
        public UserDTO User { get; set; }
        public SupplierProductDTO Supplier { get; set; }

    }

    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }

        public int ProductId { get; set; }
    }

    public class SupplierProductDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Markup { get; set; }
    }
}
