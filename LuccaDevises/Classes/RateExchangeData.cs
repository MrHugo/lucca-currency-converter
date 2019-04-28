using System;
using System.Collections.Generic;
using System.Linq;

using LuccaDevises.Helpers;

namespace LuccaDevises.Classes
{
    /* 
     * This class is responsible for holding the datum given in the
     * file specified by user.
    */
    public class RateExchangeData
    {
        // Hold the initial currency, the amount to convert, and the target currency.
        public Conversion GivenConversion; 
        public List<RateExchangeLink> rateExchangeNodeList = new List<RateExchangeLink>();
        public List<string> currenciesList = new List<string>();

        public RateExchangeData()
        {            
            var lines = FileHelper.ReadFromFile("hey.txt");
            this.GivenConversion = FileHelper.SplitFirstLine(lines.First());

            /*
             * We add the from currency as the first node as Dijkstra algorithm 
             * always starts by first index.
            */
            this.AddCurrency(this.GivenConversion.CurrencyFrom);

            /* 
             * We skip the first couple of lines as the first one has already been
             * handledwhile the second giving the number of connexions is not
             * mandatory for the algorithm to work.
            */
            foreach (var line in lines.Skip(2))
            {
                RateExchangeLink nodeLine = FileHelper.SplitLine(line);

                this.rateExchangeNodeList.Add(nodeLine);
                this.AddCurrency(nodeLine.CurrencyFrom);
                this.AddCurrency(nodeLine.CurrencyTo);
            }
        }

        public int getCurrencyIndex(string curr)
        {
            // Increment index as graph node index starts at position 1.
            return this.currenciesList.IndexOf(curr) + 1;
        }

        public string getCurrencyByIndex(int index)
        {
            // Get element at index - 1 as graph node index stars at position 1 
            return this.currenciesList.ElementAt(index -1);
        }

        private void AddCurrency(string currency)
        {
            if (!this.currenciesList.Contains(currency))
            {
                this.currenciesList.Add(currency);
            }
        }
    }

    /* 
     * This class represents a link between two currencies.
     * It can be filled by consuming one of the N lines
     * starting fro mthe third line
    */
    public class RateExchangeLink
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

        public double Rate
        {
            get;
            set;
        }

        public RateExchangeLink(string currencyFrom, string currencyTo, double rate)
        {
            this.CurrencyFrom = currencyFrom;
            this.CurrencyTo = currencyTo;
            this.Rate = rate;
        }        
    }
}
