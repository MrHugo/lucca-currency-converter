using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuccaDevises.Classes
{
    /*
     * This class hold the values of the first line. 
     * It is contained in the RateExchange datum. 
    */
    public class Conversion
    {
        public string CurrencyFrom
        {
            get;
            set;
        }

        public string CurrencyTo
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public Conversion(string currencyFrom, string currencyTo, int amount)
        {
            this.CurrencyFrom = currencyFrom;
            this.CurrencyTo = currencyTo;
            this.Amount = amount;
        }
    }
}
