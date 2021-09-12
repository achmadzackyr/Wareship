using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Products
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public int IsTrash { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
