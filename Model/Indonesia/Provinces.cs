using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wareship.Model.Indonesia
{
    public class Provinces
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Regencies> Regencies { get; set; }
    }
}
