using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Category
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
