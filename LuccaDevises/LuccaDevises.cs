using System;
using System.Collections.Generic;
using System.Linq;

using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

using LuccaDevises.Classes;
using LuccaDevises.Helpers;

namespace LuccaDevises
{    
    class LuccaDevises
    {
        private static RateExchangeData rateExchangeData;
        private static Graph<int, string> graph;

        static void Main(string[] args)
        {            
            if (!CheckArgs(args))
            {
                return;
            }

            graph = new Graph<int, string>();
            rateExchangeData = new RateExchangeData();            

            GraphHelper.FillGraph(graph, rateExchangeData.currenciesList.Count);           
            
            foreach (var reNode in rateExchangeData.rateExchangeNodeList)
            {
                var uIntFromNode = Convert.ToUInt32(rateExchangeData.getCurrencyIndex(reNode.CurrencyFrom));
                var uIntToNode = Convert.ToUInt32(rateExchangeData.getCurrencyIndex(reNode.CurrencyTo));                
                
                GraphHelper.AddGraphLink(graph, uIntFromNode, uIntToNode);                
            }

            var datum = rateExchangeData.GivenConversion;

            ShortestPathResult pathResult = graph.Dijkstra(
                Convert.ToUInt32(rateExchangeData.getCurrencyIndex(datum.CurrencyFrom)), 
                Convert.ToUInt32(rateExchangeData.getCurrencyIndex(datum.CurrencyTo))
            );                        
            
            double result = ComputeResult(datum.Amount, rateExchangeData.rateExchangeNodeList, pathResult.GetPath());

            Console.Write((int)result);
            Console.ReadKey();
        }


        private static bool CheckArgs(string[] args)
        {
            // Human check :-)
            if (args.Length.Equals(1) && !string.IsNullOrEmpty(args[0]))
            {
                return true;
            }

            Console.WriteLine("Usage :");
            Console.WriteLine("LuccaDevises <file path>");
            Console.ReadKey();

            return false;
        }        

        private static double ComputeResult(int initialAmount, List<RateExchangeLink> reLinks, IEnumerable<uint> pathIndex)
        {
            double amount = initialAmount;
            uint precNodeIndex = 0;

            foreach (var nodeIndex in pathIndex)
            {
                if (precNodeIndex != 0)
                {
                    reLinks.ForEach(reNode =>
                    {
                        if (reNode.CurrencyFrom.Equals(rateExchangeData.getCurrencyByIndex((int)precNodeIndex)) && reNode.CurrencyTo.Equals(rateExchangeData.getCurrencyByIndex((int)nodeIndex)))
                        {                                                           
                            // /* FOR DEBUG */ Console.Write(amount + " * " + Math.Round(reNode.Rate, 4));                                                                                    
                            amount *= Math.Round(reNode.Rate, 4);                            
                        }
                        else if (reNode.CurrencyFrom.Equals(rateExchangeData.getCurrencyByIndex((int)nodeIndex)) && reNode.CurrencyTo.Equals(rateExchangeData.getCurrencyByIndex((int)precNodeIndex)))
                        {
                            // /* FOR DEBUG */ Console.Write(amount + " * ( 1 / " + Math.Round(reNode.Rate, 4) + ") ");
                            amount *= 1 / Math.Round(reNode.Rate, 4);                            
                        }
                    });
                    
                    amount = Math.Round(amount, 4);
                    // /* FOR DEBUG */ Console.WriteLine(" = " + amount);
                }

                precNodeIndex = nodeIndex;
            }

            return amount;
        }

    }
}
