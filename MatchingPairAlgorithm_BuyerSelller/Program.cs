using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    public class Party
    {
        public Boolean isBuyer, isSeller;
        public int price;
        public Party(int p,Boolean isBuyer,Boolean isSeller)
        {
            this.price = p;
            this.isBuyer = isBuyer;
            this.isSeller = isSeller;
        }
    }
    class Program
    {
        public void Solve(Queue<Party> BiddingQueue,Boolean isChanged)
        {
            Party temp = BiddingQueue.Peek();
            if (temp.isBuyer)
            {
                foreach(Party p in BiddingQueue)
                {
                    if (p.isSeller)
                    {
                        if (p.price == temp.price)
                        {
                            BiddingQueue.Dequeue();
                            Queue<Party> tempQueue = new Queue<Party>();
                            while(BiddingQueue.Count!=0)
                            {
                                Party temp2 = BiddingQueue.Peek();
                                if (temp2 == p)
                                {
                                    break;
                                }
                                else
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            if (BiddingQueue.Count != 0)
                                BiddingQueue.Dequeue();
                            if (BiddingQueue.Count != 0)
                            {
                                while (BiddingQueue.Count != 0)
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            BiddingQueue = tempQueue;
                        }
                        else if (p.price < temp.price)
                        {
                            temp.price = temp.price - p.price;
                            Queue<Party> tempQueue = new Queue<Party>();
                            while (BiddingQueue.Count != 0)
                            {
                                Party temp2 = BiddingQueue.Peek();
                                if (temp2 == p)
                                {
                                    break;
                                }
                                else
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            if (BiddingQueue.Count != 0)
                                BiddingQueue.Dequeue();
                            if (BiddingQueue.Count != 0)
                            {
                                while (BiddingQueue.Count != 0)
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            BiddingQueue = tempQueue;
                        }
                        else
                        {
                            BiddingQueue.Dequeue();
                            Queue<Party> tempQueue = new Queue<Party>();
                            while (BiddingQueue.Count != 0)
                            {
                                Party temp2 = BiddingQueue.Peek();
                                if (temp2 == p)
                                {
                                    break;
                                }
                                else
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            if (BiddingQueue.Count != 0)
                            {
                                Party y = BiddingQueue.Peek();
                                y.price = y.price - temp.price;
                            }
                            if (BiddingQueue.Count != 0)
                            {
                                while (BiddingQueue.Count != 0)
                                {
                                    tempQueue.Enqueue(BiddingQueue.Dequeue());
                                }
                            }
                            BiddingQueue = tempQueue;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            char input = default(char);
            Queue<Party> BiddingQueue = new Queue<Party>();
            while (input != 'Y')
            {
                Console.WriteLine("Enter 'Y' to exit from the input: ");
                Console.WriteLine(" Enter Price: ");
                int price = Console.Read();
                Console.WriteLine(" Is Buyer: Press 1 for Yes/ 2 for No ");
                int isBuyerInt = Console.Read();
                Party p;
                if(isBuyerInt == 1 )
                {
                    p = new Party(price, true, false);
                }
                else
                {
                    p = new Party(price, false, true);
                }
                BiddingQueue.Enqueue(p);
            }
            Program p = new Program();
            while(p.Solve(BiddingQueue, true))
            {

            }
            Console.WriteLine(" --- Remaing Elements in Queue --- ");
            foreach( Party p in BiddingQueue)
            {
                Console.WriteLine($" ${p.price} , ${p.isBuyer}  , ${p.isSeller}");
            }
        }
    }
}
