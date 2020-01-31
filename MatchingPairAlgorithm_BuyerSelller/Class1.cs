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
        public String userId;
        public NewPartyWithId(int q, int allOrNone, int r,String userId)
        {
            this.qty = q;
            this.a = allOrNone;
            this.range = r;
            this.userId = userId;
        }
        public String toString()
        {
            return $"User id is {this.userId}:- Quantity is {qty} , AllOrNone{a} and {range}";
        }
    }
    class NewDemo
    {
        System.IO.StreamWriter file;
        String line;
        public NewDemo()
        {
            file=new System.IO.StreamWriter(@"C:\Users\Public\Documents\Answers2.txt");
        }
        public void ReadFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Documents\TestCases2.txt");
            int noOfTestcases = Int32.Parse(lines[0]);
            int lineNoForNoOfBuyerSeller = 1;
            line = $" ---No of Testcases:- ${noOfTestcases}--- ";
            Console.WriteLine(line);
            file.WriteLine(line);
            int testcaseNo = 1;
            while (lineNoForNoOfBuyerSeller < lines.Length)
            {
                List<NewPartyWithId> buyers = new List<NewPartyWithId>();
                List<NewPartyWithId> sellers = new List<NewPartyWithId>();
                line = $"${testcaseNo++}) TestCase ------ ";
                Console.WriteLine(line);
                file.WriteLine(line);
                String[] parsing = lines[lineNoForNoOfBuyerSeller].Split(' ');
                int noOfBuyers = Int32.Parse(parsing[0]);
                int noOfSellers = Int32.Parse(parsing[1]);
                for (int i = lineNoForNoOfBuyerSeller+1; i <= lineNoForNoOfBuyerSeller+noOfBuyers; i++)
                {
                    String[] buyerParsing = lines[i].Split(' ');
                    buyers.Add(new NewPartyWithId(Int32.Parse(buyerParsing[0]), Int32.Parse(buyerParsing[1]), Int32.Parse(buyerParsing[2]),buyerParsing[3]));
                }
                for (int j = lineNoForNoOfBuyerSeller+noOfBuyers+1; j <= lineNoForNoOfBuyerSeller + noOfBuyers + noOfSellers; j++)
                {
                    String[] sellerParsing = lines[j].Split(' ');
                    sellers.Add(new NewPartyWithId(Int32.Parse(sellerParsing[0]), Int32.Parse(sellerParsing[1]), Int32.Parse(sellerParsing[2]),sellerParsing[3]));
                }
                List<NewPartyWithId> copyBuyers = copyList(buyers);
                List<NewPartyWithId> copySellers = copyList(sellers);
                line = "--- In Actual Order ---";
                Console.WriteLine(line);
                file.WriteLine(line);
                solve(buyers, sellers);
                line = "--- In reverse Order ---";
                Console.WriteLine(line);
                file.WriteLine(line);
                solve(copyBuyers, copySellers);
                lineNoForNoOfBuyerSeller += noOfBuyers + noOfSellers+1 ;
            }
        }
        public void loopThrough(List<NewPartyWithId> source, List<NewPartyWithId> destination)
        {
            for (int i = 0; i < source.Count; i++)
            {
                int temp = source[i].qty;
                for (int j = 0; j < destination.Count; j++)
                {
                   
                        RecursiveApproach ra = new RecursiveApproach();
                        if (ra.subset_sum(source[i].qty, 0, destination, source[i],i,source))
                        {
                            source[i].qty = 0;
                        }
                        else
                        {
                            source[i].qty = temp;
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
        public void solve(List<NewPartyWithId> buyerss,List<NewPartyWithId> sellerss)
        {
            loopThrough(buyerss, sellerss);
            clean(buyerss, 0);
            clean(sellerss, 0);
            loopThrough(sellerss, buyerss);
            clean(buyerss, 0);
            clean(sellerss, 0);
            line = "--- Remaing Buyers ---";
            Console.WriteLine(line);
            file.WriteLine(line);
            for (int i = 0; i < buyerss.Count; i++)
            {
                line = buyerss[i].toString();
                Console.WriteLine(line);
                file.WriteLine(line);
            }
            line = "--- Remaing Sellers ---";
            Console.WriteLine(line);
            file.WriteLine(line);
            for (int i = 0; i < sellerss.Count; i++)
            {
                line = sellerss[i].toString();
                Console.WriteLine(line);
                file.WriteLine(line);
            }
        }
        public List<NewPartyWithId> copyList(List<NewPartyWithId> list)
        {
            List<NewPartyWithId> newlist = new List<NewPartyWithId>();
            for(int i = 0; i < list.Count; i++)
            {
                newlist.Add(new NewPartyWithId(list[i].qty,list[i].a,list[i].range,list[i].userId));
            }
            return newlist;
        }
        public void consoleWorks()
        {
            List<NewPartyWithId> buyers = new List<NewPartyWithId>();
            List<NewPartyWithId> sellers = new List<NewPartyWithId>();
            int input = default(int);
            int qty = 0;
            int a = 0;
            int r = 0;
            char readI = default(char);
            while (readI != 'q')
            {
                Console.WriteLine("Enter -999 to Stop");
                Console.WriteLine("Buyers:");
                while (input != -999)
                {
                    Console.WriteLine("Enter UserId");
                    String uid = Console.ReadLine();
                    Console.WriteLine("Enter Qty");
                    qty = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                    a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ticket Size");
                    r = Int32.Parse(Console.ReadLine());
                    buyers.Add(new NewPartyWithId(qty, a, r,uid));
                    Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                    input = Int32.Parse(Console.ReadLine());
                }
                Console.WriteLine("Sellers:");
                input = 0;
                while (input != -999)
                {
                    Console.WriteLine("Enter UserId");
                    String uid = Console.ReadLine();
                    Console.WriteLine("Enter Qty");
                    qty = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                    a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ticket Size");
                    r = Int32.Parse(Console.ReadLine());
                    sellers.Add(new NewPartyWithId(qty, a, r,uid));
                    Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                    input = Int32.Parse(Console.ReadLine());
                }
                List<NewPartyWithId> copyBuyers = copyList(buyers);
                List<NewPartyWithId> copySellers = copyList(sellers);
                solve(buyers, sellers);
                Console.WriteLine(" --- Reverse Result ---");
                solve(copySellers, copyBuyers);
                readI = (char)Console.ReadLine().ToCharArray()[0];
            }
        }
        static void Main(string[] args)
        {
            NewDemo nd = new NewDemo();
            int input=0;
            Console.WriteLine(" Enter 1 for File I/o and 2 for Console I/o:");
            input = Int32.Parse(Console.ReadLine());
            if (input == 1)
                nd.ReadFromFile();
            else if (input == 2)
                nd.consoleWorks();
            Console.WriteLine(" All Done!!!");
            Console.ReadLine();
        }
    }
}
