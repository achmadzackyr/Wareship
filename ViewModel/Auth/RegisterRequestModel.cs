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
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Subdistrict is required")]
        public string Subdistrict { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        
        [Required(ErrorMessage = "Role Name is required")]
        public List<string> RoleNames { get; set; }
        
        [Required(ErrorMessage = "UserStatusId is required")]
        public int UserStatusId { get; set; }

        [Required(ErrorMessage = "UserTierId is required")]
        public int UserTierId { get; set; }
    }
}
