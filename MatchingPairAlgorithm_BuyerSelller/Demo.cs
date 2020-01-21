using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    public class party
    {
        public int qty;
        public int a;
        public int range;
        public party(int q,int allOrNone,int r)
        {
            this.qty = q;
            this.a = allOrNone;
            this.range = r;
        }
    }
    class Demo
    {
        List<party> buyers = new List<party>();
        List<party> sellers = new List<party>();
        public void simplyUpdate(int buyerIndex,int sellerIndex)
        {
            int flag = 0;
            if(this.buyers[buyerIndex].qty==this.sellers[sellerIndex].qty)
            {
                Console.WriteLine("Tradded Between Buyer" + buyers[buyerIndex].qty + " & seller" + sellers[sellerIndex].qty);
                buyers.RemoveAt(buyerIndex);
                sellers.RemoveAt(sellerIndex);
            }
            else if(this.buyers[buyerIndex].qty > this.sellers[sellerIndex].qty)
            {
                Console.WriteLine("Tradded Between Buyer" + buyers[buyerIndex].qty + " & seller" + sellers[sellerIndex].qty);
                buyers[buyerIndex].qty -= sellers[sellerIndex].qty;
                sellers.RemoveAt(sellerIndex);
            }
            else
            {
                Console.WriteLine("Tradded Between Buyer" + buyers[buyerIndex].qty + " & seller" + sellers[sellerIndex].qty);
                sellers[sellerIndex].qty -= buyers[buyerIndex].qty;
                buyers.RemoveAt(buyerIndex);
            }
        }
        public int withOneALlOrNoneCondition(party withoutCondition,party withCondition,int indexWithOutCondition,int indexWithCondition)
        {
            int flag = 0;
            if(withCondition.qty< withoutCondition.qty)
            {
                if(buyers[indexWithOutCondition]==withoutCondition)
                {
                    Console.WriteLine("Tradded Between Buyer" + buyers[indexWithOutCondition].qty + " & seller" + sellers[indexWithCondition].qty);
                    buyers[indexWithOutCondition].qty -= sellers[indexWithCondition].qty;
                    sellers.RemoveAt(indexWithCondition);
                }
                else
                {
                    Console.WriteLine("Tradded Between Buyer" + buyers[indexWithCondition].qty + " & seller" + sellers[indexWithOutCondition].qty);
                    sellers[indexWithOutCondition].qty -= buyers[indexWithCondition].qty;
                    buyers.RemoveAt(indexWithCondition);
                }
            }
            else if(withCondition.qty==withoutCondition.qty)
            {
                if (buyers[indexWithOutCondition] == withoutCondition)
                {
                    Console.WriteLine("Tradded Between Buyer" + buyers[indexWithOutCondition].qty + " & seller" + sellers[indexWithCondition].qty);
                    buyers.RemoveAt(indexWithOutCondition);
                    sellers.RemoveAt(indexWithCondition);
                }
                else
                {
                    Console.WriteLine("Tradded Between Buyer" + buyers[indexWithCondition].qty + " & seller" + sellers[indexWithOutCondition].qty);
                    sellers.RemoveAt(indexWithOutCondition);
                    buyers.RemoveAt(indexWithCondition);
                }
            }
            else
            {
                flag = -1;
            }
            return flag;
        }
        public void solve()
        {
            int i = 0,j=0,flag=0;

            while( i < buyers.Count)
            {
                if (buyers.Count == 0 || sellers.Count == 0)
                {
                    break;
                }

                while (j < sellers.Count)
                {
                    if (buyers.Count == 0 || sellers.Count == 0)
                    {
                        break;
                    }
                    //No Condtition at Buyer,No COndition At Seller
                    if (buyers[i].a == 0 && sellers[i].a == 0 && buyers[i].range == 0 && sellers[i].range == 0)
                    {
                        simplyUpdate(i, j);
                        continue;
                    }

                    //No condition at buyer,All Or None At Seller
                    if (buyers[i].a == 0 && buyers[i].range == 0 && sellers[i].a != 0 && sellers[i].range == 0)
                    {
                        flag = withOneALlOrNoneCondition(buyers[i], sellers[j], i, j);
                        if (flag == -1)
                        {
                            j++;
                        }
                    }
                   
                }
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
               /* Console.WriteLine("Enter Ticket Size");
                r = Int32.Parse(Console.ReadLine());*/
                d.buyers.Add(new party(qty, a, 0));
                Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                input = Int32.Parse(Console.ReadLine());
            }
            party p = d.buyers[0];
            Console.WriteLine(typeof(party).IsInstanceOfType(p));
            Console.WriteLine("Sellers:");
            input = 0;
            while (input != -999)
            {
                Console.WriteLine("Enter Qty");
                qty = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                a = Int32.Parse(Console.ReadLine());
                /*Console.WriteLine("Enter Ticket Size");
                r = Int32.Parse(Console.ReadLine());*/
                d.sellers.Add(new party(qty, a, 0));
                Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                input = Int32.Parse(Console.ReadLine());
            }
            d.solve();
            Console.ReadLine();
        }
    }
}
