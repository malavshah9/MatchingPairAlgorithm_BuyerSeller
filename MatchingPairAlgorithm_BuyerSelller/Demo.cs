using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    public class NewParty
    {
        public int qty;
        public int a;
        public int range;
        public NewParty(int q,int allOrNone,int r)
        {
            this.qty = q;
            this.a = allOrNone;
            this.range = r;
        }
        public String toString()
        {
            return $"Quantity is {qty} , AllOrNone{a} and {range}";
        }
    }
    class Demo
    {
        List<NewParty> buyers = new List<NewParty>();
        List<NewParty> sellers = new List<NewParty>();
        public void updateQty(NewParty partyA,NewParty partyB,int trade)
        {
            partyA.qty -= trade;
            partyB.qty -= trade;
        }
        
        public int isCompatibleGivesTrade(NewParty party1,NewParty party2)
        {
            int newQty = -1;
            // Checks the condition of both party
            // Returns the new quantity from party iff they are compatible
            if (party1.qty == 0 || party2.qty == 0)
                return newQty;
            if(party1.a==0 && party2.a==0 && party1.range==0 && party2.range == 0)
            {
                newQty=Math.Min(party1.qty, party2.qty);
            }
            else if(party1.a == 0 && party1.range == 0 && party2.a != 0 && party2.range == 0)
            {
                if (party1.qty >= party2.qty)
                {
                    newQty=party2.qty;
                }
            }
            else if (party1.a != 0 && party1.range == 0 && party2.a == 0 && party2.range == 0)
            {
                if (party2.qty >= party1.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if(party1.a != 0 && party1.range == 0 && party2.a != 0 && party2.range == 0)
            {
                if (party1.qty == party2.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if (party1.a == 0 && party1.range != 0 && party2.a == 0 && party2.range != 0)
            {
                if (party1.qty == party2.qty)
                {
                    newQty = party1.qty;
                }
                else if(party1.range<=party2.range && party1.qty > party2.qty)
                {
                    newQty= party2.qty;
                }
                else if(party2.range<=party1.range && party2.qty > party1.qty)
                {
                    newQty= party1.qty;
                }
                else if (party1.range<=party2.range && party2.qty>party1.qty)
                {
                    newQty= party1.qty;
                }
                else if (party2.range <= party1.range && party1.qty > party2.qty)
                {
                    newQty= party2.qty;
                }
                else if (party1.qty<party2.qty)
                {
                    newQty= party1.qty;
                }
                else
                {
                    newQty= party2.qty;
                }
            }
            else if (party1.a == 0 && party1.range == 0 && party2.a == 0 && party2.range != 0)
            {
               if(party1.qty>=party2.range && party1.qty <= party2.qty)
                {
                    newQty=party1.qty;
                }
               else if (party1.qty >= party2.qty)
                {
                    newQty=party2.qty;
                }
            }
            else if (party2.a == 0 && party2.range == 0 && party1.a == 0 && party1.range != 0)
            {
                if (party2.qty >= party1.range && party2.qty <= party1.qty)
                {
                    newQty = party2.qty;
                }
                else if (party2.qty >= party1.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if(party1.a != 0 && party1.range == 0 && party2.a == 0 && party2.range != 0)
            {
                if(party1.qty>=party2.range && party1.qty<=party2.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if (party2.a != 0 && party2.range == 0 && party1.a == 0 && party1.range != 0)
            {
                if (party2.qty >= party1.range && party2.qty <= party1.qty)
                {
                    newQty = party2.qty;
                }
            }
            else if (party1.a != 0 && party1.range == 0 && party2.a != 0 && party2.range != 0)
            {
                if(party1.qty==party2.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if (party2.a != 0 && party2.range == 0 && party1.a != 0 && party1.range != 0)
            {
                if (party1.qty == party2.qty)
                {
                    newQty = party2.qty;
                }
            }
            else if (party1.a == 0 && party1.range == 0 && party2.a != 0 && party2.range != 0)
            {
                if (party1.qty >= party2.qty)
                    newQty = party2.qty;
            }
            else if (party2.a == 0 && party2.range == 0 && party1.a != 0 && party1.range != 0)
            {
                if (party2.qty >= party1.qty)
                    newQty = party1.qty;
            }
            else if (party1.a != 0 && party1.range != 0 && party2.a == 0 && party2.range != 0)
            {
                if (party1.qty == party2.qty)
                {
                    newQty = party2.qty;
                }
                else if(party1.qty ==party2.range)
                {
                    newQty = party1.qty;
                }
            }
            else if (party2.a != 0 && party2.range != 0 && party1.a == 0 && party1.range != 0)
            {
                if (party2.qty == party1.qty)
                {
                    newQty = party1.qty;
                }
                else if (party2.qty == party1.range)
                {
                    newQty = party2.qty;
                }
            }
            else
            {
                if (party1.qty == party2.qty)
                {
                    newQty = party1.qty;
                }
            }
            return newQty;
        }
        public void loopThrough(List<NewParty> source,List<NewParty> destination)
        {
            for (int i=0; i < source.Count; i++)
            {
                for(int j = 0; j < destination.Count; j++)
                {
                    int trade = isCompatibleGivesTrade(source[i], destination[j]);
                    if (trade != -1)
                    {
                        Console.WriteLine($"Trade between {source[i].qty} and {destination[j].qty} with trade {trade}");
                        updateQty(source[i], destination[j], trade);
                    }
                }
            }
        }
        public void clean(List<NewParty> list,int index)
        {
            if (index < list.Count)
            {
                if (list[index].qty == 0)
                {
                    list.RemoveAt(index);
                    clean(list, index);
                }
                else
                {
                    clean(list, index + 1);
                }
            }
        }
        public void solve()
        {
            loopThrough(sellers, buyers);
            clean(buyers,0);
            clean(sellers,0);
            loopThrough(buyers, sellers);
            clean(buyers, 0);
            clean(sellers, 0);
            Console.WriteLine(" Reamining Sellers ");
            for(int i = 0; i < buyers.Count; i++)
            {
                Console.WriteLine(buyers[i].toString());
            }
            Console.WriteLine(" Reamining Buyers ");
            for (int i = 0; i < sellers.Count; i++)
            {
                Console.WriteLine(sellers[i].toString());
            }
        }
        static void Main(string[] args)
        {
           
            int input = default(int);
            int qty = 0;
            int a = 0;
            int r = 0;
            Demo d = new Demo();
            Console.WriteLine("Enter -999 to Stop");
            Console.WriteLine("Buyers:");
            while (input!=-999)
            {
                Console.WriteLine("Enter Qty");
                qty =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Ticket Size");
                r = Int32.Parse(Console.ReadLine());
                d.buyers.Add(new NewParty(qty, a, r));
                Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                input = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Sellers:");
            input = 0;
            while (input != -999)
            {
                Console.WriteLine("Enter Qty");
                qty = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Ticket Size");
                r = Int32.Parse(Console.ReadLine());
                d.sellers.Add(new NewParty(qty, a, r));
                Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                input = Int32.Parse(Console.ReadLine());
            }
            d.solve();
            Console.ReadLine();
        }
    }
}
