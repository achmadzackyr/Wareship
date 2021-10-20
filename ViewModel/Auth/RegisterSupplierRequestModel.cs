using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Auth
{
    public class RegisterSupplierRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Markup is required")]
        public double Markup { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Address
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Subdistrict is required")]
        public string Subdistrict { get; set; }
        [Required(ErrorMessage = "Subdistrict Id is required")]
        public int SubdistrictId { get; set; }
        [Required(ErrorMessage = "City Id is required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Province Id is required")]
        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Zip Code is required")]
        public string ZipCode { get; set; }

        //Relation
        [Required(ErrorMessage = "User Status Id is required")]
        public int UserStatusId { get; set; }
        [Required(ErrorMessage = "SubCategory Id is required")]
        public int SubCategoryId { get; set; }
        public string CreatedById { get; set; }
    }
}
