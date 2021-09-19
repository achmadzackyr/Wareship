using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Warehouse
{
    public class WarehouseListResponse
    {
        public Status Status { get; set; }
        public List<WarehouseDTO> Result { get; set; }
    }

    public class WarehouseResponse
    {
        public Status Status { get; set; }
        public WarehouseDTO Result { get; set; }
    }
}
