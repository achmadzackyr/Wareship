using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Product
{
    public class ProductPaginationModel
    {
        public PagingParameterModel Paging { get; set; }
        public ProductParameter Parameter { get; set; }
    }

    public class ProductParameter
    {
        public ProductFilter Filter { get; set; }
        public ProductSort Sort { get; set; }

    }

    public class ProductFilter
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductStatusId { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
    }

    public class ProductSort
    {
        public string Price { get; set; }
        public string CreatedAt { get; set; }
    }
}

