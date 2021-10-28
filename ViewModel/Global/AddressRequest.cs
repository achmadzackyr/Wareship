using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Global
{
    public class AddressRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string SubdistrictId { get; set; }
        public string CityId { get; set; }
        public string ProvinceId { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}
