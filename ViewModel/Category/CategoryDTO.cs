using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<SubCategoryDTO> SubCategories { get; set; }
        //public CategoryDTO(int id, string name, string thumbnailUrl, List<SubCategoryDTO> subCategories)
        //{
        //    Id = id;
        //    Name = name;
        //    ThumbnailUrl = thumbnailUrl;
        //    SubCategories = subCategories;
        //}
    }
}
