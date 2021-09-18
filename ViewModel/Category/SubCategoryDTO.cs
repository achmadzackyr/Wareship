using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Category
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
