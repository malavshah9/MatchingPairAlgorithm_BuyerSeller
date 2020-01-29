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
        System.IO.StreamWriter file;
        String line;
        public NewDemo()
        {
            file=new System.IO.StreamWriter(@"C:\Users\Public\Documents\Answers.txt");
        }
        public void backTrack(NewPartyWithId source,List<NewPartyWithId> list,int length)
        {
            int sum = 0;
            List<NewPartyWithId> updationList = new List<NewPartyWithId>();
            Console.WriteLine(" Inside backTrack ");
            for(int i = 0; i <= length; i++)
            {
                if (list[i].a == 0 && list[i].range == 0)
                {
                    if (source.range == 0 || (source.range != 0 && source.range<=list[i].qty && source.range <= (source.qty-sum)))
                    {
                        sum += list[i].qty;
                        updationList.Add(list[i]);
                    }
                }
                else if(list[i].a!=0 && list[i].range == 0)
                {
                    if ((sum + list[i].qty) <= source.qty  && (source.range==0 || ( source.range <= list[i].qty && (source.range<= (source.qty - sum)))))
                    {
                        sum += list[i].qty;
                        updationList.Add(list[i]);
                    }
                }
                else if(list[i].a!=0 && list[i].range != 0)
                {
                    if((sum+list[i].qty)<=source.qty && ((source.range==0 && (source.qty-sum)>=list[i].range) || (source.range!=0 && source.range <= list[i].qty && source.range <= (source.qty - sum))))
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
            //Console.WriteLine($" updated here , ${partyA.qty} and ${partyB.qty}");
            partyA.qty -= trade;
            partyB.qty -= trade;
        }

        public int isCompatibleGivesTrade(NewPartyWithId party1, NewPartyWithId party2)
        {
            int newQty = -1;
            // Checks the condition of both party
            // Returns the new quantity from party iff they are compatible
            if (party1.qty == 0 || party2.qty == 0 || (party1.range!=0 && party1.qty<party1.range) || (party2.range!=0 && party2.qty<party2.range))
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
        public void ReadFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Documents\TestCases.txt");
            int noOfTestcases = Int32.Parse(lines[0]);
            int lineNoForNoOfBuyerSeller = 1;
            line = $" ---No of Testcases--- ${noOfTestcases}";
            Console.WriteLine(line);
            file.WriteLine(line);
            while (lineNoForNoOfBuyerSeller < lines.Length)
            {
                List<NewPartyWithId> buyers = new List<NewPartyWithId>();
                List<NewPartyWithId> sellers = new List<NewPartyWithId>();
                line = "--- New TestCase ---";
                Console.WriteLine(line);
                file.WriteLine(line);
                String[] parsing = lines[lineNoForNoOfBuyerSeller].Split(' ');
                int noOfBuyers = Int32.Parse(parsing[0]);
                int noOfSellers = Int32.Parse(parsing[1]);
                for (int i = lineNoForNoOfBuyerSeller+1; i <= lineNoForNoOfBuyerSeller+noOfBuyers; i++)
                {
                    String[] buyerParsing = lines[i].Split(' ');
                    Console.WriteLine(" Parsing Line No "+ i);
                    Console.WriteLine(lines[i]);
                    buyers.Add(new NewPartyWithId(Int32.Parse(buyerParsing[0]), Int32.Parse(buyerParsing[1]), Int32.Parse(buyerParsing[2])));
                }
                for (int j = lineNoForNoOfBuyerSeller+noOfBuyers+1; j <= lineNoForNoOfBuyerSeller + noOfBuyers + noOfSellers; j++)
                {
                    String[] sellerParsing = lines[j].Split(' ');
                    sellers.Add(new NewPartyWithId(Int32.Parse(sellerParsing[0]), Int32.Parse(sellerParsing[1]), Int32.Parse(sellerParsing[2])));
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
                    int trade = isCompatibleGivesTrade(source[i], destination[j]);
                    if (trade != -1)
                    {
                        line = $"Trade between {source[i].qty} and {destination[j].qty} with trade {trade}";
                        Console.WriteLine(line);
                        file.WriteLine(line);
                        updateQty(source[i], destination[j], trade);
                    }
                }
            }
            clean(source, 0);
            clean(destination, 0);
            for(int i = 0; i < source.Count; i++)
            {
                for(int j = 0; j < destination.Count; j++)
                {
                    RecursiveApproach ra = new RecursiveApproach();
                    int tempQty = source[i].qty;
                    if (ra.subset_sum(source[i].qty, 0, destination, source[i]))
                    {
                        source[i].qty = 0;
                    }
                    else
                    {
                        source[i].qty = tempQty;
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
                newlist.Add(new NewPartyWithId(list[i].qty,list[i].a,list[i].range));
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
                    Console.WriteLine("Enter Qty");
                    qty = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                    a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ticket Size");
                    r = Int32.Parse(Console.ReadLine());
                    buyers.Add(new NewPartyWithId(qty, a, r));
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
                    sellers.Add(new NewPartyWithId(qty, a, r));
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
