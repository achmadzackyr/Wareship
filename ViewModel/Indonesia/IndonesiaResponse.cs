using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Model.Indonesia;
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
        public List<Provinces> Provinces { get; set; }
    }

    public partial class CityResponse
    {
        public Status Status { get; set; }
        public CityListResponse Result { get; set; }
    }

    public partial class CityListResponse
    {
        public List<Regencies> Cities { get; set; }
    }

    
    public partial class SubDistrictResponse
    {
        public Status Status { get; set; }
        public SubDistrictListResponse Result { get; set; }
    }

    public partial class SubDistrictListResponse
    {
        public List<SubDistricts> SubDistricts { get; set; }
    }
}
