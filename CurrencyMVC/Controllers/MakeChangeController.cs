using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyLibrary;
using CurrencyLibrary.USCurrency;
using CurrencyMVC.Models;

namespace CurrencyMVC.Models
{
    
    public class MakeChangeController : Controller
    {
        public static AmountHolder holder { get; set; }
        private static ICurrencyRepo repo;
        public ICurrencyRepo Repo
        {
            get { return repo; }
            set { repo = value; }
        }

        public MakeChangeController()
        {
            if(repo == null)
            {
                repo = new CurrencyRepo();
                holder = new AmountHolder();
            }
            
            this.ViewData.Model = holder;
        }
        // GET: MakeChange
        public ActionResult Index()
        {
            this.ViewData.Model = holder;
            return View();
        }

        [HttpPost]
        public ActionResult MakeChange(AmountHolder h)
        {

            double amt = 0;
            if(Double.TryParse(h.Amount, out amt))
            {
                repo.MakeChange(amt);
            }
            this.ViewData.Model = repo.Coins;
            return View();
        }
    }
}