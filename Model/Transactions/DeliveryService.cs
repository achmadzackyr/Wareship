using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wareship.Model.Transactions
{
    public class DeliveryService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
