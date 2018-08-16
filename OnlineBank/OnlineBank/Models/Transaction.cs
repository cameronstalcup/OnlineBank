using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBank.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }
        [Display(Name = "Transaction Amount")]
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }

        public virtual Account Account { get; set; }
        public virtual Loan Loan { get; set; }

        public void LogTransaction(Loan loan, string transactionType, decimal amount)
        {
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                TransactionType = transactionType,
                TransactionAmount = amount,
                Balance = loan.Balance
            };
        }
        
        public void LogTransaction(Account account, string transactionType, decimal amount)
        {
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                TransactionType = transactionType,
                TransactionAmount = amount,
                Balance = account.Balance
            };
        }
    }
}