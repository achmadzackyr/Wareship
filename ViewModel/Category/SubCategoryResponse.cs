using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Category
{
    public class SubCategoryListResponse
    {
        public Status Status { get; set; }
        public List<SubCategoryDTO> Result { get; set; }
    }

    public class SubCategoryResponse
    {
        public Status Status { get; set; }
        public SubCategoryDTO Result { get; set; }
    }
}
