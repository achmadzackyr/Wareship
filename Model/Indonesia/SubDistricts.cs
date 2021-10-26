using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wareship.Model.Indonesia
{
    public class SubDistricts
    {
        public string Id { get; set; }
        public string RegencyId { get; set; }
        [JsonIgnore]
        public Regencies Regency { get; set; }
        public string Name { get; set; }
    }
}
