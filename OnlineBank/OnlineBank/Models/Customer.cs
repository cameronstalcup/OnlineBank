using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBank.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}