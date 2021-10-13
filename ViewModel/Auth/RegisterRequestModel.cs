using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Wareship.Authentication;

namespace Wareship.ViewModel.Auth
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Name { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime Dob { get; set; }

        public string Street { get; set; }
        
        public string Subdistrict { get; set; }
        
        [Required(ErrorMessage = "City Id is required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Province Id is required")]
        public int ProvinceId { get; set; }
        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public List<string> RoleNames { get; set; }
        public int UserStatusId { get; set; }
        public int UserTierId { get; set; }
    }
}
