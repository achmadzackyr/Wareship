using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Auth
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Subdistrict { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime JoinDate { get; set; }
        public string JoinDateString { get; set; }
        public int UserStatusId { get; set; }
        public int UserTierId { get; set; }
    }
}
