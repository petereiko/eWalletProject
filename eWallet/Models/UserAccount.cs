using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWallet.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}