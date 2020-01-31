using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    public class Buyers
    {
        List<NewPartyWithId> buyers;
        public Buyers()
        {
            this.buyers = new List<NewPartyWithId>();
        }
        public void addBuyer(NewPartyWithId buyer)
        {
            this.buyers.Add(buyer);
        }
        public void printBuyers()
        {
            for (int i = 0; i < this.buyers.Count; i++)
            {
                Console.WriteLine(buyers[i].toString());
            }
        }
        public List<NewPartyWithId> getBuyers()
        {
            return this.buyers;
        }
    }
}
