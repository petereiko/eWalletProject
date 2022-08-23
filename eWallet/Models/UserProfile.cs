using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWallet.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int StateId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}