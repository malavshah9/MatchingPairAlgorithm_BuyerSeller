using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    class RecursiveApproach
    {
        public Boolean subset_sum(int remaining_amount,int starting_index, List<NewPartyWithId> list,NewPartyWithId source)
        {
            if (remaining_amount == 0)
            {
                source.qty = 0;
                return true;
            }
            if (source.range != 0 && remaining_amount < source.range || remaining_amount<0)
                return false;
            if (list.Count - starting_index == 1)
            {
                if (list[starting_index].range == 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
                {
                    if (remaining_amount <= list[starting_index].qty)
                    {
                        list[starting_index].qty -= remaining_amount;
                        source.qty = 0;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (list[starting_index].range == 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
                {
                    if (remaining_amount == list[starting_index].qty)
                    {
                        list[starting_index].qty -= remaining_amount;
                        source.qty = 0;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(list[starting_index].range!=0 && list[starting_index].a!=0 && (source.range==0 || source.range<=list[starting_index].qty))
                {
                    if (remaining_amount >= list[starting_index].range && remaining_amount<=list[starting_index].qty)
                    {
                        list[starting_index].qty -= remaining_amount;
                        source.qty = 0;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            Boolean result_1=false;
            Boolean result_2=false;
            int tempQuantity = list[starting_index].qty;
            if (list[starting_index].range == 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                if (remaining_amount <= list[starting_index].qty)
                {
                    list[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    result_1 = true;
                }
                else
                {
                    int startQty = 1;
                    if (source.range != 0)
                    {
                        startQty = source.range;
                    }
                    for(int i = startQty; i <= list[starting_index].qty; i++)
                    {
                        int temp = list[starting_index].qty;
                        list[starting_index].qty -= i;
                        result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source);
                        if (result_1 == false)
                        {
                            list[starting_index].qty = temp;
                        }
                    }
                }
            }
            else if (list[starting_index].range == 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                list[starting_index].qty = 0;
                result_1 = subset_sum(remaining_amount - list[starting_index].qty, starting_index + 1, list, source);
            }
            else if (list[starting_index].range != 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                if (remaining_amount >= list[starting_index].range && remaining_amount <= list[starting_index].qty)
                {
                    list[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    result_1 = true;
                }
                else
                {
                    int startQty = list[starting_index].range;
                    if (source.range != 0)
                    {
                        startQty = Math.Max(list[starting_index].range,source.range);
                    }
                    for (int i = startQty; i <= list[starting_index].qty; i++)
                    {
                        int temp = list[starting_index].qty;
                        list[starting_index].qty -= i;
                        result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source);
                        if (result_1 == false)
                        {
                            list[starting_index].qty = temp;
                        }
                    }
                }
            }
            if (result_1 == false)
            {
                list[starting_index].qty = tempQuantity;
                result_2 = subset_sum(remaining_amount, starting_index + 1, list, source);
            }
            return result_1 || result_2;
        }
        public Boolean Recursive(int index,List<NewPartyWithId> list,NewPartyWithId source,int sum,List<NewPartyWithId> updationList)
        {
            Console.WriteLine(" source " + source.toString());
            for(int i = 0; i < updationList.Count; i++)
            {
                Console.WriteLine(updationList[i].toString());
            }
            if (source.qty == 0)
                return true;
            if (index >= list.Count && sum != 0)
                return false;
            if (sum >= source.qty)
            {
                int take = 0;
                Boolean []flags = new Boolean[updationList.Count];
                for(int j = 0; j < updationList.Count; j++)
                {
                    if (updationList[j].a == 0 && updationList[j].range == 0 && (source.range == 0 || (source.range <= updationList[j].qty && (take - updationList[j].qty >= source.range))))
                    {
                        if (updationList[j].qty <= (source.qty - take))
                        {
                            take += updationList[j].qty;
                        }
                        else
                        {
                            take += updationList[j].qty - take;
                        }
                        flags[j] = true;
                    }
                    else if (updationList[j].a != 0 && updationList[j].range == 0 && (source.range == 0 || (source.range <= updationList[j].qty)))
                    {
                        if (updationList[j].qty <= (source.qty - take))
                        {
                            take += updationList[j].qty;
                            flags[j] = true;
                        }
                    }
                    else if (updationList[j].a != 0 && updationList[j].range != 0 && (source.range == 0 || (source.range <= updationList[j].qty && source.range<=(source.range-take))) && updationList[j].qty<= (source.qty-take) && updationList[j].range <= (source.qty - take))
                    {
                        take += updationList[j].qty;
                        flags[j] = true;
                    }
                    if (take == source.qty)
                    {
                        for(int i = 0; i < updationList.Count; i++)
                        {
                            if (flags[i])
                            {
                                //updationList.RemoveAt(i);
                                if (updationList[i].qty <= source.qty)
                                {
                                    Console.WriteLine(" Trade happends between " + updationList[i].qty + " and " + source.qty);
                                    updationList[i].qty = 0;
                                }
                                else
                                {
                                    Console.WriteLine(" Trade happends between " + updationList[i].qty+ " with ("+source.qty + ") and " + source.qty);
                                    updationList[i].qty -= source.qty ;
                                     source.qty = 0;
                                     //break;
                                }
                                updationList.RemoveAt(i);
                            }
                        }
                        if (source.qty == 0)
                        {
                            updationList = new List<NewPartyWithId>();
                            return true;
                        }
                        else
                            return false;
                    }
                }
                //updationList = new List<NewPartyWithId>();
                return false;
            }
            else
            {
                if (index >= list.Count)
                {
                    return false;
                }
                else
                {
                    updationList.Add(list[index]);
                    Boolean isPossible = false;
                    for (int j = index + 1; j < list.Count; j++)
                    {
                        if(Recursive(j, list, source, sum + list[index].qty, updationList))
                        {
                            isPossible = true;
                            break;
                        }
                    }
                    if (index < updationList.Count)
                    {
                        updationList.RemoveAt(index);
                    }
                    return isPossible;   
                }
            }
        }
    }
}
