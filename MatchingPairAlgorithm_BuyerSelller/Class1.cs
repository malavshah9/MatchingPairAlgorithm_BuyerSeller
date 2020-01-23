using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    public class NewPartyWithId
    {
        public int qty;
        public int a;
        public int range;
        public NewPartyWithId(int q, int allOrNone, int r)
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
    class NewDemo
    {
        public List<NewPartyWithId> buyers = new List<NewPartyWithId>();
        public List<NewPartyWithId> sellers = new List<NewPartyWithId>();
        public void backTrack(NewPartyWithId source,List<NewPartyWithId> list,int length)
        {
            int sum = 0;
            List<NewPartyWithId> updationList = new List<NewPartyWithId>();
            Console.WriteLine(" Inside backTrack ");
            for(int i = 0; i <= length; i++)
            {
                if (list[i].a == 0 && list[i].range == 0)
                {
                    if (source.range == 0 || (source.range != 0 && source.range <= list[i].qty))
                    {
                        sum += list[i].qty;
                        updationList.Add(list[i]);
                    }
                }
                else if(list[i].a!=0 && list[i].range == 0)
                {
                    if ((sum + list[i].qty) <= source.qty && (source.range==0 || (source.range<=list[i].qty)))
                    {
                        sum += list[i].qty;
                        updationList.Add(list[i]);
                    }
                }
                else if(list[i].a!=0 && list[i].range != 0)
                {
                    if((sum+list[i].qty)<=source.qty && ((source.range==0 && (source.qty-sum)>=list[i].range) || (source.range!=0 && source.range <= list[i].qty)))
                    {
                        sum += list[i].qty;
                        updationList.Add(list[i]);
                    }
                }
                if (sum >= source.qty)
                {
                    for(int j = 0; j < updationList.Count; j++)
                    {
                       if(updationList[j].a==0 && updationList[j].range == 0)
                        {
                            if (source.qty > updationList[j].qty && (source.range==0 || source.range<=updationList[j].qty))
                            {
                                Console.WriteLine(" Source.qty  "+source.qty+" updationList[j].qty "+updationList[j].qty);
                                source.qty -= updationList[j].qty;
                                updationList[j].qty = 0;
                            }
                            else if((source.range == 0 || source.range <= updationList[j].qty))
                            {
                                Console.WriteLine(" Source.qty  " + source.qty + " updationList[j].qty " + updationList[j].qty);
                                updationList[j].qty -= source.qty;
                                source.qty = 0;
                            }
                        }
                       else if (updationList[j].a!=0 && updationList[j].range==0)
                        {
                            if(source.qty >= updationList[j].qty && (source.range == 0 || source.range <= updationList[j].qty))
                            {
                                Console.WriteLine(" Source.qty  " + source.qty + " updationList[j].qty " + updationList[j].qty);
                                source.qty -= updationList[j].qty;
                                updationList[j].qty = 0;
                            }
                        }
                        else if(updationList[j].a!=0 && updationList[j].range != 0)
                        {
                            if(source.qty>=updationList[j].range && (source.range==0 || source.range <= updationList[j].qty))
                            {
                                Console.WriteLine(" Source.qty  " + source.qty + " updationList[j].qty " + updationList[j].qty);
                                source.qty -= updationList[j].qty;
                                updationList[j].qty = 0;
                            }
                        }
                        if (source.qty <= 0)
                        {
                            Console.WriteLine(" Bid " + source.qty);
                        }
                    }
                    break;
                }
            }
        }
        public void updateQty(NewPartyWithId partyA, NewPartyWithId partyB, int trade)
        {
            partyA.qty -= trade;
            partyB.qty -= trade;
        }

        public int isCompatibleGivesTrade(NewPartyWithId party1, NewPartyWithId party2)
        {
            int newQty = -1;
            // Checks the condition of both party
            // Returns the new quantity from party iff they are compatible
            if (party1.qty == 0 || party2.qty == 0)
                return newQty;
            if (party1.a == 0 && party2.a == 0 && party1.range == 0 && party2.range == 0)
            {
                newQty = Math.Min(party1.qty, party2.qty);
            }
            else if (party1.a == 0 && party1.range == 0 && party2.a != 0 && party2.range == 0)
            {
                if (party1.qty >= party2.qty)
                {
                    newQty = party2.qty;
                }
            }
            else if (party1.a != 0 && party1.range == 0 && party2.a == 0 && party2.range == 0)
            {
                if (party2.qty >= party1.qty)
                {
                    newQty = party1.qty;
                }
            }
            else if (party1.a != 0 && party1.range == 0 && party2.a != 0 && party2.range == 0)
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
                else if (party1.range <= party2.range && party1.qty > party2.qty)
                {
                    newQty = party2.qty;
                }
                else if (party2.range <= party1.range && party2.qty > party1.qty)
                {
                    newQty = party1.qty;
                }
                else if (party1.range <= party2.range && party2.qty > party1.qty)
                {
                    newQty = party1.qty;
                }
                else if (party2.range <= party1.range && party1.qty > party2.qty)
                {
                    newQty = party2.qty;
                }
                else if (party1.qty < party2.qty)
                {
                    newQty = party1.qty;
                }
                else
                {
                    newQty = party2.qty;
                }
            }
            else if (party1.a == 0 && party1.range == 0 && party2.a == 0 && party2.range != 0)
            {
                if (party1.qty >= party2.range && party1.qty <= party2.qty)
                {
                    newQty = party1.qty;
                }
                else if (party1.qty >= party2.qty)
                {
                    newQty = party2.qty;
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
            else if (party1.a != 0 && party1.range == 0 && party2.a == 0 && party2.range != 0)
            {
                if (party1.qty >= party2.range && party1.qty <= party2.qty)
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
                if (party1.qty == party2.qty)
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
                else if (party1.qty == party2.range)
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
        public void loopThrough(List<NewPartyWithId> source, List<NewPartyWithId> destination)
        {
            for (int i = 0; i < source.Count; i++)
            {
                for (int j = 0; j < destination.Count; j++)
                {
                    int trade = isCompatibleGivesTrade(source[i], destination[j]);
                    if (trade != -1)
                    {
                        Console.WriteLine($"Trade between {source[i].qty} and {destination[j].qty} with trade {trade}");
                        updateQty(source[i], destination[j], trade);
                    }
                    else
                    {
                        backTrack(source[i], destination, j);
                    }
                }
            }
        }
        public void clean(List<NewPartyWithId> list, int index)
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
            clean(buyers, 0);
            clean(sellers, 0);
            loopThrough(buyers, sellers);
            clean(buyers, 0);
            clean(sellers, 0);
            Console.WriteLine(" Reamining Sellers ");
            for (int i = 0; i < buyers.Count; i++)
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
            NewDemo d = new NewDemo();
            Console.WriteLine("Enter -999 to Stop");
            Console.WriteLine("Buyers:");
            while (input != -999)
            {
                Console.WriteLine("Enter Qty");
                qty = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Ticket Size");
                r = Int32.Parse(Console.ReadLine());
                d.buyers.Add(new NewPartyWithId(qty, a, r));
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
                d.sellers.Add(new NewPartyWithId(qty, a, r));
                Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                input = Int32.Parse(Console.ReadLine());
            }
            d.solve();
            Console.ReadLine();
        }
    }
}
