using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Stocks
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Jalan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Provinsi { get; set; }
        public string Phone { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
