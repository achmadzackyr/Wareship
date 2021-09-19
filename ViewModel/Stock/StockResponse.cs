using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Stock
{
    public class StockListResponse
    {
        public Status Status { get; set; }
        public List<StockDTO> Result { get; set; }
    }

    public class StockResponse
    {
        public Status Status { get; set; }
        public StockDTO Result { get; set; }
    }
}
