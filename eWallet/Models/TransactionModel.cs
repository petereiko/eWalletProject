using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWallet.Models
{
    public class TransactionModel
    {
        public long Id { get; set; }
        public int InitiatorUserId { get; set; }
        public decimal Amount { get; set; }
        public int? BuyerUserId { get; set; }
        public string Evidence { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}