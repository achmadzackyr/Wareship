using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Indonesia
{
    public partial class ProvinceResponse
    {
        public Status Status { get; set; }
        public ProvinceListResponse Result { get; set; }
    }

    public partial class ProvinceListResponse
    {
        public List<Provinsi> Provinsi { get; set; }
    }

    public partial class Provinsi
    {
        public long Id { get; set; }
        public string Nama { get; set; }
    }


    public partial class CityResponse
    {
        public Status Status { get; set; }
        public CityListResponse Result { get; set; }
    }

    public partial class CityListResponse
    {
        public List<KotaKabupaten> Kota_Kabupaten { get; set; }
    }

    public partial class KotaKabupaten
    {
        public long Id { get; set; }
        public long Id_Provinsi { get; set; }
        public string Nama { get; set; }
    }
}
