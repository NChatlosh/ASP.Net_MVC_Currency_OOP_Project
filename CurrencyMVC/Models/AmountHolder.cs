using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyMVC.Models
{
    public class AmountHolder
    {
        public string Amount { get; set; }
        public AmountHolder()
        {
            Amount = "0";
        }
    }
}