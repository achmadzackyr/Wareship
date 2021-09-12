using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Authentication;
using Wareship.Model.Stocks;

namespace Wareship.Model.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }

        //Relationship
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public List<Stock> Stocks { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
