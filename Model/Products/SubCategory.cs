using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wareship.Model.Users;

namespace Wareship.Model.Products
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public int IsTrash { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
