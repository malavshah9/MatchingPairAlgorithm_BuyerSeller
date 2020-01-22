using System;
using System.Collections.Generic;
using System.Collections;

public class Order
{
    public int quantity;
    public int ticketSize;
    public int allOrNone;
    public int partyNo;
    public static int partyID = 0;
    public boolean isVoid;
    public Order(int q,int ticket,int all)
    {
        this.quantity = q;
        this.ticketSize = ticket;
        this.allOrNone = all;
        this.partyNo = partyID;
        Order.partyID++;
        this.isVoid = false;
    }
    public void makeVoid()
    {
        this.isVoid = true;
    }
}
public class MatchingPairAlog
{
    public void doTrade(Order buyerParty,Order sellerParty,int quantity)
    {
        //Console.WriteLine//
    }
    public void executeOrdersRecursive(int startIndex,int windowSize,ArrayList<Order> sellerList,)
    {

    }
    public void  executeOrders(ArrayList<Order> sellerList,ArrayList<Order> buyerList,int sellerIndex,int buyerIndex)
    {
        if (IsCriteriaFullfilling(sellerList.ToArray()[sellerIndex], buyerList.ToArray[buyerIndex]))
        {
            int quantity = getQuantity(sellerList.ToArray()[sellerIndex], buyerList.ToArray[buyerIndex]);
            doTrade(sellerList.ToArray()[sellerIndex], buyerList.ToArray[buyerIndex], quantity);
            updateArraylist(buyerList, buyerList.ToArray()[buyerIndex],quantity);
            updateArraylist(sellerList, sellerList.ToArray()[sellerIndex],quantity);
            executeOrders(sellerList, buyerList, 0, buyerIndex + 1);
        }
        else
        {
            int startBuyer = 0;
            int endBuyer = buyerIndex;
            int windowSize = 2;
            while(windowSize<=(end)
        }
    }
    public boolean isFullfillingCriteria(Party p1,Party p2)
    {
        if (p1.price == p2.price)
            return true;
        else
        {
            if (p1.a && p2.a)
            {
                return false;
            }
            else if (p1.a && p2.range)
        }
    }
    public void Program(Queue<Party> BidderQueue, Queue<Party> OfferQueue)
    {
            
    }
}
