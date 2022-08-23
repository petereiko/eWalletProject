using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWallet.Models
{
    public class TransactionViewModel
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}