using MatchingPairAlgorithm_sellerselller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
   
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
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Documents\TestCases2.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\Documents\SingleTestCase.txt");
            int noOfTestcases = Int32.Parse(lines[0]);
            int lineNoForNoOfBuyerSeller = 1;
            line = $" ---No of Testcases: {noOfTestcases}--- ";
            Console.WriteLine(line);
            file.WriteLine(line);
            int testcaseNo = 1;
            while (lineNoForNoOfBuyerSeller < lines.Length)
            {
                Buyers myBuyers = new Buyers();
                Sellers mySellers = new Sellers();
                line = $"{testcaseNo++}) TestCase ------ ";
                Console.WriteLine(line);
                file.WriteLine(line);
                String[] parsing = lines[lineNoForNoOfBuyerSeller].Split(' ');
                int noOfBuyers = Int32.Parse(parsing[0]);
                int noOfSellers = Int32.Parse(parsing[1]);
                for (int i = lineNoForNoOfBuyerSeller+1; i <= lineNoForNoOfBuyerSeller+noOfBuyers; i++)
                {
                    String[] buyerParsing = lines[i].Split(' ');
                    NewPartyWithId myNewParty = new NewPartyWithId(Int32.Parse(buyerParsing[0]), Int32.Parse(buyerParsing[1]), Int32.Parse(buyerParsing[2]), buyerParsing[3]);
                    myBuyers.addBuyers(myNewParty);
                }
                for (int j = lineNoForNoOfBuyerSeller+noOfBuyers+1; j <= lineNoForNoOfBuyerSeller + noOfBuyers + noOfSellers; j++)
                {
                    String[] sellerParsing = lines[j].Split(' ');
                    NewPartyWithId myNewParty = new NewPartyWithId(Int32.Parse(sellerParsing[0]), Int32.Parse(sellerParsing[1]), Int32.Parse(sellerParsing[2]), sellerParsing[3]);
                    mySellers.addSellers(myNewParty);
                }
                Buyers myCopyBuyers = new Buyers();
                Sellers myCopySellers = new Sellers();
                myCopyBuyers.setBuyers(mySellers.getCopySellers());
                myCopySellers.setSellers(myBuyers.getCopyBuyers());
                line = " Before Processing ";
                Console.WriteLine(line);
                file.WriteLine(line);
                printList(myBuyers, mySellers,true);
                line = " After Processing ";
                Console.WriteLine(line);
                file.WriteLine(line);
                solve(myBuyers, mySellers);
                printList(myBuyers, mySellers,true);
                line = " --- Reverse Result ---";
                Console.WriteLine(line);
                file.WriteLine(line);
                solve(myCopyBuyers, myCopySellers);
                printList(myBuyers, mySellers,true);
                lineNoForNoOfBuyerSeller += noOfBuyers + noOfSellers+1 ;
            }
        }
        public void loopThrough(List<NewPartyWithId> source, List<NewPartyWithId> destination, Buyers buyers, Sellers sellers)
        {
            NewRecursiveApproach nr = new NewRecursiveApproach();
            for (int i = 0; i < source.Count; i++)
            {
                nr.isCompatibleGivesTrade(source[i].qty, 0, destination, source[i],i, source);
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
        public void printList(Buyers buyers,Sellers sellers,Boolean fileWrite)
        {
            buyers.printBuyers(fileWrite,file);
            sellers.printSellers(fileWrite,file);
        }
        public void solve(Buyers buyers,Sellers sellers)
        {
            loopThrough(buyers.getBuyers(), sellers.getsellers(),buyers,sellers);
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
            Buyers myBuyers = new Buyers();
            Sellers mySellers = new Sellers();
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
                    String choice, uid;
                    Console.WriteLine(" Is Parent or Child: Enter P for Parent and C for Child");
                    choice = Console.ReadLine();
                    if (choice == "C")
                    {
                        Console.WriteLine(" Enter Parent Node UserId: ");
                        uid = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Enter UserId");
                        uid = Console.ReadLine();
                        Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                        a = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Ticket Size");
                        r = Int32.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Enter Qty");
                    qty = Int32.Parse(Console.ReadLine());
                    NewPartyWithId myNewParty = new NewPartyWithId(qty, a, r, uid);
                    if (choice == "C")
                    {
                        myBuyers.addChild(uid, myNewParty);
                    }
                    else
                    {
                        myBuyers.addBuyers(myNewParty);
                    }
                    Console.WriteLine("Enter -999 to Stop,anyother number to continue");
                    input = Int32.Parse(Console.ReadLine());
                }
                Console.WriteLine("Sellers:");
                input = 0;
                while (input != -999)
                {
                    Console.WriteLine("Enter -999 to Stop");
                    Console.WriteLine("Sellers:");
                    while (input != -999)
                    {
                        String choice, uid;
                        Console.WriteLine(" Is Parent or Child: Enter P for Parent and C for Child");
                        choice = Console.ReadLine();
                        if (choice == "C")
                        {
                            Console.WriteLine(" Enter Parent Node UserId: ");
                            uid = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Enter UserId");
                            uid = Console.ReadLine();
                            Console.WriteLine("Enter 1 for ALL or Nothing Condition ,0 for nothing");
                            a = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Ticket Size");
                            r = Int32.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter Qty");
                        qty = Int32.Parse(Console.ReadLine());
                        NewPartyWithId myNewParty = new NewPartyWithId(qty, a, r, uid);
                        if (choice == "C")
                        {
                            mySellers.addChild(uid, myNewParty);
                        }
                        else
                        {
                            mySellers.addSellers(myNewParty);
                        }
                        Console.WriteLine("Enter -999 to Stop,any other number to continue");
                        input = Int32.Parse(Console.ReadLine());
                    }
                    Buyers myCopyBuyers = new Buyers();
                    Sellers myCopySellers = new Sellers();
                    myCopyBuyers.setBuyers(myBuyers.getCopyBuyers());
                    myCopySellers.setSellers(mySellers.getCopySellers());
                    myBuyers.printBuyers();
                    mySellers.printSellers();
                    Console.WriteLine(" --- Actual Result ---");
                    solve(myBuyers, mySellers);
                    Console.WriteLine(" --- Reverse Result ---");
                    solve(myCopyBuyers, myCopySellers);
                    readI = (char)Console.ReadLine().ToCharArray()[0];
                }
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
