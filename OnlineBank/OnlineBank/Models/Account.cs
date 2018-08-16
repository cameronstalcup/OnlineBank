using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBank.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Display(Name = "Account Number")]
        public int AccountNumber { get; set; }
        [Display(Name = "Account Type")]
        public string Type { get; set; }
        public decimal Balance { get; set; }
        [Display(Name = "Interest Rate")]
        [Range(0.0, Double.MaxValue)]
        public decimal InterestRate { get; set; }
        [Display(Name = "Date Opened")]
        public DateTime? DateOpened { get; set; }
        [Display(Name = "Date Closed")]
        public DateTime? DateClosed { get; set; }
        public bool IsActive { get; set; }

        public virtual Customer Customer { get; set; }
    }
}