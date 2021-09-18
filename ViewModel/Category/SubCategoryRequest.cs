using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Category
{
    public class SubCategoryRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryId { get; set; }
    }
}
