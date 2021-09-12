using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Model.Stocks;

namespace Wareship.Model.Transactions
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
