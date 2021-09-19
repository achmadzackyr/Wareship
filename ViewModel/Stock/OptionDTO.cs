using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.ViewModel.Stock
{
    public class OptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VariationDTO Variation { get; set; }
    }
}
