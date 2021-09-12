using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Transactions
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DeliveryService> DeliveryServices { get; set; }
    }
}
