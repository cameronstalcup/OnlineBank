﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBank.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue)]
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