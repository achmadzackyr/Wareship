using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Product
{
    public class ProductListResponse
    {
        public Status Status { get; set; }
        public List<ProductDTO> Result { get; set; }
    }

    public class ProductResponse
    {
        public Status Status { get; set; }
        public ProductDTO Result { get; set; }
    }

    public class ProductPagingResponse
    {
        public Status Status { get; set; }
        public List<ProductDTO> Result { get; set; }
        public PagingResponse Paging { get; set; }
    }
}
