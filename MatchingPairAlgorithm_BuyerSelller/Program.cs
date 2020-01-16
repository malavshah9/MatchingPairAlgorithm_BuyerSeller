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
        static void Main(string[] args)
        {
            char input = default(char);
            Queue<Party> SellerQueue = new Queue<Party>();
            Queue<Party> BuyerQueue = new Queue<Party>();
            while (input != 'Y')
            {
                Console.WriteLine(" Enter Price of seller: ");
                int price = Int32.Parse(Console.ReadLine());
                SellerQueue.Enqueue(new Party(price,false,true));
                Console.WriteLine("Enter 'Y' to exit from the input: ");
                input = Console.ReadLine().ToCharArray()[0];
            }
            input = 'A';
            Program p = new Program();
            while (input != 'Y')
            {
                Console.WriteLine(" Enter Price of buyer: ");
                int price = Int32.Parse(Console.ReadLine());
                BuyerQueue.Enqueue(new Party(price, true, false));
                p.Solve(SellerQueue, BuyerQueue);
                Console.WriteLine("Enter 'Y' to exit from the input: ");
                input = Console.ReadLine().ToCharArray()[0];
            }
        }

        private void Solve(Queue<Party> sellerQueue, Queue<Party> buyerQueue)
        {
            if (sellerQueue.Count == 0 || buyerQueue.Count==0)
                Console.WriteLine(" No Seller/buyer to sell ");
            else
            {
                Party dequedElementSeller = sellerQueue.Peek();
                Party peekedElementBuyer = buyerQueue.Peek();
                if (peekedElementBuyer.price == dequedElementSeller.price)
                {
                    dequedElementSeller = sellerQueue.Dequeue();
                    peekedElementBuyer = buyerQueue.Dequeue();
                    Console.WriteLine($" Traded betweem ${dequedElementSeller.price} and ${peekedElementBuyer.price}");
                }
                else if (peekedElementBuyer.price > dequedElementSeller.price)
                {
                    dequedElementSeller = sellerQueue.Dequeue();
                    Console.WriteLine($" Traded betweem ${dequedElementSeller.price} and ${peekedElementBuyer.price}-${dequedElementSeller.price}");
                    peekedElementBuyer.price -= dequedElementSeller.price;
                }
                else
                {
                    peekedElementBuyer = buyerQueue.Dequeue();
                    Console.WriteLine($" Traded betweem ${dequedElementSeller.price} - ${peekedElementBuyer.price} and ${peekedElementBuyer.price}");
                    dequedElementSeller.price -= peekedElementBuyer.price;
                }
                Solve(sellerQueue, buyerQueue);
            }
        }
    }
}
