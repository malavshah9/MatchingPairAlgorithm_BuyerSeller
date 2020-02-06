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
        public void addChild(String uid, NewPartyWithId child)
        {
            int totalQtyTillNow = 0;
            foreach (NewPartyWithId item in buyers)
            {
                if (item.userId == uid)
                {
                    totalQtyTillNow += item.qty;
                    item.isChild = true;
                }
            }
            child.totalQtyTillNow += totalQtyTillNow;
            child.isChild = true;
            buyers.Add(child);
        }
        public void setBuyers(List<NewPartyWithId> newBuyers)
        {
            this.buyers = newBuyers;
        }
        public void addBuyers(NewPartyWithId node)
        {
            this.buyers.Add(node);
        }
        public bool contains(NewPartyWithId obj)
        {
            if (this.buyers.IndexOf(obj) != -1)
            {
                return true;
            }
            return false;
        }
        public void printBuyers()
        {
            Console.WriteLine("Printing Buyers:-");
            for (int i = 0; i < this.buyers.Count; i++)
            {
                Console.WriteLine(buyers[i].toString());
            }
        }
        public List<NewPartyWithId> getBuyers()
        {
            return this.buyers;
        }
        public List<NewPartyWithId> getCopyBuyers()
        {
            List<NewPartyWithId> myCopyList = new List<NewPartyWithId>();
            for(int i = 0; i < this.buyers.Count; i++)
            {
                myCopyList.Add(new NewPartyWithId(buyers[i].qty, buyers[i].a, buyers[i].range, buyers[i].userId));
            }
            return myCopyList;
        }
    }
}
