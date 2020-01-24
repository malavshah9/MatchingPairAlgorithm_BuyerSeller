using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    class RecursiveApproach
    {
        public Boolean Recursive(int index,List<NewPartyWithId> list,NewPartyWithId source,int sum,List<NewPartyWithId> updationList)
        {
            Console.WriteLine(" source " + source.toString());
            for(int i = 0; i < updationList.Count; i++)
            {
                Console.WriteLine(updationList[i].toString());
            }
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
                    else if (updationList[j].a != 0 && updationList[j].range != 0 && (source.range == 0 || (source.range <= updationList[j].qty)) && updationList[j].qty<= (source.qty-take) && updationList[j].range <= (source.qty - take))
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
                        if (updationList.Count == 0)
                            return true;
                        else
                            return false;
                        return true;
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
