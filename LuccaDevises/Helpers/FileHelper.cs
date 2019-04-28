using System;
using System.Collections.Generic;
using System.IO;

using LuccaDevises.Classes;

namespace LuccaDevises.Helpers
{
    public static class FileHelper
    {
        public static IEnumerable<string> ReadFromFile(string fileName)
        {
            string line;
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static Conversion SplitFirstLine(string line)
        {
            var lineSplitArray = line.Split(new char[] {';', '\n'} );

            string moneyFrom = lineSplitArray[0];
            int amount = int.Parse(lineSplitArray[1]);
            string moneyTo = lineSplitArray[2];

            return new Conversion(moneyFrom, moneyTo, amount);
        }

        public static RateExchangeLink SplitLine(string line)
        {
            var lineSplitArray = line.Split(new char[] { ';', '\n' });

            string moneyFrom = lineSplitArray[0];
            string moneyTo = lineSplitArray[1];            
            double rate = double.Parse(lineSplitArray[2]);

            return new RateExchangeLink(moneyFrom, moneyTo, rate);
        }
    }
}
