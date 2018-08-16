using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using OnlineBank;
using OnlineBank.Models;

namespace OnlineBank.Controllers
{
    public class AccountsController : Controller
    {
        private BankContext db = new BankContext();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            account.DateOpened = DateTime.Today;
            account.IsActive = true;
            account.Balance = 0;

            if(account.Type == "Checking")
            {
                account.InterestRate = 0.06m;
            }
            else if(account.Type == "Term Deposit")
            {
                account.InterestRate = 2.55m;
                account.Balance = 5000;
            }

            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestRate")] Account account)
        {
            if (ModelState.IsValid)
            {
                if(account.Type == "Business")
                {
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var account = db.Accounts.SingleOrDefault(x => x.AccountID == id);
            account.DateClosed = DateTime.Today;
            account.IsActive = false;

            if(account.Type == "Term Deposit" && (account.DateOpened < DateTime.Today.AddDays(-180)))
            {
                account.Balance -= account.Balance;
            }
            else if(account.Type == "Checking" || account.Type == "Business")
            {
                account.Balance -= account.Balance;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Debit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Debit(int? id, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(x => x.AccountID == id);
            if(account.IsActive)
            {
                if(account.Type == "Checking" && account.Balance >= amount)
                {
                    account.Balance -= amount;
                }
                else if(account.Type == "Term Deposit" && account.DateOpened < DateTime.Today.AddDays(-180) && account.Balance >= amount)
                {
                    account.Balance -= amount;
                }
                else if(account.Type == "Business")
                {
                    account.Balance -= amount;
                }
            }
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Credit()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Credit(int? id, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(x => x.AccountID == id);
            if (account.IsActive)
            {
                account.Balance = account.Balance + amount;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        
    }
}
