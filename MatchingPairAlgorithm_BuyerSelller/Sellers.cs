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
        HashSet<String> hashSet;
        public Sellers()
        {
            this.sellers = new List<NewPartyWithId>();
            this.hashSet = new HashSet<string>();
        }
        public void addChild(String uid, NewPartyWithId child)
        {
            int totalQtyTillNow = 0;
            int a = 0, range = 0;
            foreach (NewPartyWithId item in sellers)
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
            sellers.Add(child);
            child.a = a;
            child.range = range;
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
                String line = sellers[i].toString();
                Console.WriteLine(line);
            }
        }
        public void printSellers(Boolean isFileWrite, System.IO.StreamWriter file)
        {
            String line2 = "Printing Sellers:-";
            Console.WriteLine(line2);
            if (isFileWrite)
            {
                file.WriteLine(line2);
            }
            for (int i = 0; i < this.sellers.Count; i++)
            {
                String line = sellers[i].toString();
                Console.WriteLine(line);
                if (isFileWrite)
                {
                    file.WriteLine(line);
                }
            }
        }
        public void addSellers(NewPartyWithId node)
        {
            if (this.hashSet.Contains(node.userId))
            {
                this.addChild(node.userId, node);
            }
            else
            {
                this.hashSet.Add(node.userId);
                this.sellers.Add(node);
            }
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
