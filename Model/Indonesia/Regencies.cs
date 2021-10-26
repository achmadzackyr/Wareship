using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wareship.Model.Indonesia
{
    public class Regencies
    {
        public string Id { get; set; }
        public string ProvinceId { get; set; }
        [JsonIgnore]
        public Provinces Province { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<SubDistricts> SubDistricts { get; set; }
    }
}
