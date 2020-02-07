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
        HashSet<String> hashSet;
        public Buyers()
        {
            this.buyers = new List<NewPartyWithId>();
            this.hashSet = new HashSet<string>();
        }
        public void addChild(String uid, NewPartyWithId child)
        {
            int totalQtyTillNow = 0;
            int a=0, range=0;
            foreach (NewPartyWithId item in buyers)
            {
                if (item.userId == uid)
                {
                    totalQtyTillNow += item.qty;
                    item.isChild = true;
                    a = item.a;
                    range = item.range;
                }
            }
            child.totalQtyTillNow += totalQtyTillNow;
            child.isChild = true;
            buyers.Add(child);
            child.a = a;
            child.range = range;
        }
        public void setBuyers(List<NewPartyWithId> newBuyers)
        {
            this.buyers = newBuyers;
        }
        public void addBuyers(NewPartyWithId node)
        {
            if (this.hashSet.Contains(node.userId))
            {
                this.addChild(node.userId, node);
            }
            else
            {
                this.hashSet.Add(node.userId);
                this.buyers.Add(node);
            }
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
                String line = buyers[i].toString();
                Console.WriteLine(line);
            }
        }
        public void printBuyers(Boolean isFileWrite, System.IO.StreamWriter file)
        {
            String line2 = "Printing Buyers:-";
            Console.WriteLine(line2);
            if (isFileWrite)
            {
                file.WriteLine(line2);
            }
            for (int i = 0; i < this.buyers.Count; i++)
            {
                String line = buyers[i].toString();
                Console.WriteLine(line);
                if (isFileWrite)
                {
                    file.WriteLine(line);
                }
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
