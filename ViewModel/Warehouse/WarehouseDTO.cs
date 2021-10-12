using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Stock;

namespace Wareship.ViewModel.Warehouse
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
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
        //public List<StockDTO> Stocks { get; set; }
    }
}
