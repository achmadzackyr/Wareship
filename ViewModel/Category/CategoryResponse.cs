using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Category
{
    public class CategoryListResponse
    {
        public Status Status { get; set; }
        public List<CategoryDTO> Result { get; set; }
    }

    public class CategoryResponse
    {
        public Status Status { get; set; }
        public CategoryDTO Result { get; set; }
    }
}
