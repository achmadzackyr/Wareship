using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Stocks
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int VariationId { get; set; }
        public Variation Variation { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
