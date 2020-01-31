using MatchingPairAlgorithm_BuyerSelller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_sellerselller
{
    public class Sellers
    {
        List<NewPartyWithId> sellers;
        public Sellers()
        {
            this.sellers = new List<NewPartyWithId>();
        }
        public void addSeller(NewPartyWithId seller)
        {
            this.sellers.Add(seller);
        }
        public void printSellers()
        {
            for (int i = 0; i < this.sellers.Count; i++)
            {
                Console.WriteLine(sellers[i].toString());
            }
        }
        public List<NewPartyWithId> getsellers()
        {
            return this.sellers;
        }
    }
}
