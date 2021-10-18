using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Auth
{
    public class SupplierListResponse
    {
        public Status Status { get; set; }
        public List<SupplierDTO> Result { get; set; }
    }

    public class SupplierResponse
    {
        public Status Status { get; set; }
        public SupplierDTO Result { get; set; }
    }
}
