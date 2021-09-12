using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.Authentication;

namespace Wareship.Model.Transactions
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Airwaybill { get; set; }
        public double TotalPrice { get; set; }
        public double TotalShipping { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalVolume { get; set; }
        public double TotalTax { get; set; }
        public double TotalFee { get; set; }
        public int TotalItem { get; set; }
        public int IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }


        //Relationship
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TransactionStatusId { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int DeliveryServiceId { get; set; }
        public DeliveryService DeliveryService { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public int ConsigneeId { get; set; }
        public Consignee Consignee { get; set; }

        public List<Order> Orders { get; set; }
    }
}
