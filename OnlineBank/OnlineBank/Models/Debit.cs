using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBank.Models
{
    public class Debit
    {
        public Account Account { get; set; }
        public decimal DebitAmount { get; set; }
    }
}