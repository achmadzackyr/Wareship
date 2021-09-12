using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Stocks
{
    public class Variation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Option> Options { get; set; }
    }
}
