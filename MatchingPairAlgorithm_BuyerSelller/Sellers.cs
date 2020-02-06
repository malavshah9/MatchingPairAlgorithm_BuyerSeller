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
        public void addChild(String uid, NewPartyWithId child)
        {
            int totalQtyTillNow = 0;
            foreach (NewPartyWithId item in sellers)
            {
                if (item.userId == uid)
                {
                    totalQtyTillNow += item.qty;
                    item.isChild = true;
                }
            }
            child.totalQtyTillNow += totalQtyTillNow;
            child.isChild = true;
            sellers.Add(child);
        }
        public void setSellers(List<NewPartyWithId> newSellers)
        {
            this.sellers = newSellers;
        }
        public bool contains(NewPartyWithId obj)
        {
            if (this.sellers.IndexOf(obj) != -1)
            {
                return true;
            }
            return false;
        }
        public void printSellers()
        {
            Console.WriteLine("Printing Sellers:-");
            for (int i = 0; i < this.sellers.Count; i++)
            {
                Console.WriteLine(sellers[i].toString());
            }
        }
        public void addSellers(NewPartyWithId node)
        {
            this.sellers.Add(node);
        }
        public List<NewPartyWithId> getsellers()
        {
            return this.sellers;
        }
        public List<NewPartyWithId> getCopySellers()
        {
            List<NewPartyWithId> myCopyList = new List<NewPartyWithId>();
            for (int i = 0; i < this.sellers.Count; i++)
            {
                myCopyList.Add(new NewPartyWithId(sellers[i].qty, sellers[i].a, sellers[i].range, sellers[i].userId));
            }
            return myCopyList;
        }
    }
}
