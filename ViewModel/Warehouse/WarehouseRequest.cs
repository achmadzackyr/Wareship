using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Warehouse
{
    public class WarehouseRequest : AddressRequest
    {
        public new int Id { get; set; }
    }
}
