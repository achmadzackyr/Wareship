using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Auth
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Email { get; set; }
        public double Markup { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtString { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int SubdistrictId { get; set; }
        public string Subdistrict { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        public int AddressId { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public int UserStatusId { get; set; }
        public string UserStatusName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

    }
}
