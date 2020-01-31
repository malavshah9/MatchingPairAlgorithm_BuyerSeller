using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    class RecursiveApproach
    {
        //public Boolean subset_sum(int remaining_amount,int starting_index, List<NewPartyWithId> list,NewPartyWithId source)
        //{
        //    if (remaining_amount < source.range)
        //        return false;
        //    if (remaining_amount == 0)
        //    {
        //        source.qty = 0;
        //        return true;
        //    }
        //    if ((source.range != 0 && remaining_amount < source.range) || remaining_amount<0)
        //        return false;
        //    if (list.Count - starting_index == 1)
        //    {
        //        if (list[starting_index].range == 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //        {
        //            if (remaining_amount <= list[starting_index].qty)
        //            {
        //                list[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else if (list[starting_index].range == 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //        {
        //            if (remaining_amount == list[starting_index].qty)
        //            {
        //                list[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else if (list[starting_index].range != 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //        {
        //            if (remaining_amount <=list[starting_index].qty && list[starting_index].range<= remaining_amount)
        //            {
        //                list[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else if(list[starting_index].range!=0 && list[starting_index].a!=0 && (source.range==0 || source.range<=list[starting_index].qty))
        //        {
        //            if (remaining_amount >= list[starting_index].range && remaining_amount<=list[starting_index].qty)
        //            {
        //                list[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //            return false;
        //    }
        //    Boolean result_1=false;
        //    Boolean result_2=false;
        //    int tempQuantity = list[starting_index].qty;
        //    if (list[starting_index].range == 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //    {
        //        if (remaining_amount <= list[starting_index].qty)
        //        {
        //            list[starting_index].qty -= remaining_amount;
        //            source.qty = 0;
        //            result_1 = true;
        //        }
        //        else
        //        {
        //            int startQty = 1;
        //            if (source.range != 0)
        //            {
        //                startQty = source.range;
        //            }
        //            for(int i = startQty; i <= list[starting_index].qty; i++)
        //            {
        //                list[starting_index].qty = tempQuantity - i;
        //                result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source);
        //                if(result_1)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    else if (list[starting_index].range == 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //    {
        //        list[starting_index].qty = 0;
        //        result_1 = subset_sum(remaining_amount - list[starting_index].qty, starting_index + 1, list, source);
        //    }
        //    else if (list[starting_index].range != 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //    {
        //        if (list[starting_index].qty == remaining_amount)
        //        {
        //            list[starting_index].qty = 0;
        //            source.qty = 0;
        //            result_1 = true;
        //        }
        //    }
        //    else if (list[starting_index].range != 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
        //    {
        //        if (remaining_amount >= list[starting_index].range && remaining_amount <= list[starting_index].qty)
        //        {
        //            list[starting_index].qty -= remaining_amount;
        //            source.qty = 0;
        //            result_1 = true;
        //        }
        //        else if (remaining_amount >= list[starting_index].range)
        //        {
        //            for(int i=Math.Max(source.range, list[starting_index].range); i <= list[starting_index].qty; i++)
        //            {
        //                list[starting_index].qty = tempQuantity - i;
        //                result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source);
        //                if (result_1)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (result_1 == false)
        //    {
        //        list[starting_index].qty = tempQuantity;
        //        result_2 = subset_sum(remaining_amount, starting_index + 1, list, source);
        //    }
        //    return result_1 || result_2;
        //}
        //public int knapSack(int remaining, List<NewPartyWithId> list)
        //{
        //    int[,] K = new int[list.Count + 1, remaining + 1];
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        for (int j = 0; j < remaining; j++)
        //        {
        //            if (i == 0 || j == 0)
        //                K[i,j] = 0;
        //            else if()
        //        }
        //    }

        //    return K[list.Count, remaining];

        //}
        public Boolean subset_sum(int remaining_amount, int starting_index, List<NewPartyWithId> list, NewPartyWithId source,int source_index,List<NewPartyWithId> source_list)
        {
            if (remaining_amount == 0)
            {
                source.qty = 0;
                return true;
            }
            if ( (source.range!=0 && remaining_amount < source.range) || starting_index >= list.Count || source_index>=source_list.Count)
                return false;
            if ((source.range != 0 && remaining_amount < source.range) || remaining_amount < 0)
                return false;
            Boolean result_1 = false;
            Boolean result_2 = false;
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
                    int endQty = 1;
                    if (source.range != 0)
                    {
                        endQty = source.range;
                    }
                    for (int i = list[starting_index].qty; i >= endQty; i--)
                    {
                        list[starting_index].qty = tempQuantity-i;
                        result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index,source_list);
                        if (result_1)
                        {
                            break;
                        }
                    }
                }
            }
            else if (list[starting_index].range == 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                if (list[starting_index].qty <= remaining_amount)
                {
                    list[starting_index].qty = 0;
                    result_1 = subset_sum(remaining_amount - tempQuantity, starting_index + 1, list, source, source_index,source_list);
                }
                else
                {
                    int tempQty = list[starting_index].qty;
                    list[starting_index].qty -= remaining_amount;
                    int tempSourceQty = source.qty;
                    source.qty = 0;
                    if (subset_sum(list[starting_index].qty, 0, source_list, list[starting_index], starting_index, list))
                    {
                        list[starting_index].qty = 0;
                        result_1 = true;
                    }
                    else
                    {
                        source.qty = tempSourceQty;
                        list[starting_index].qty = tempQty;
                    }
                }
            }
            else if (list[starting_index].range != 0 && list[starting_index].a != 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                if (list[starting_index].qty <= remaining_amount)
                {
                    list[starting_index].qty = 0;
                    result_1 = subset_sum(remaining_amount - tempQuantity, starting_index + 1, list, source, source_index,source_list);
                }
            }
            else if (list[starting_index].range != 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
            {
                if (remaining_amount >= list[starting_index].range && remaining_amount <= list[starting_index].qty)
                {
                    list[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    result_1 = true;
                }
                else if (remaining_amount >= list[starting_index].range)
                {
                    int endQty = Math.Max(source.range, list[starting_index].range);
                    if (endQty == 0)
                        endQty = 1;
                    for (int i = list[starting_index].qty; i >= endQty; i--)
                    {
                        list[starting_index].qty = tempQuantity - i;
                        result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index,source_list);
                        if (result_1)
                        {
                            break;
                        }
                    }
                }
            }
            //else if(list[starting_index].a!=0 && list[starting_index].qty >= remaining_amount && remaining_amount>=list[starting_index].range)
            //{
            //    if (list[starting_index].range == 0)
            //    {
            //        for(int i = remaining_amount; i >= 1; i--)
            //        {
            //            if (subset_sum(i, source_index + 1, source_list, source, source_index, list))
            //            {
            //                result_1 = true;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // Put that range condition here
            //    }
            //}
            if (result_1 == false)
            {
                list[starting_index].qty = tempQuantity;
                result_2 = subset_sum(remaining_amount, starting_index + 1, list, source, source_index,source_list);
            }
            return result_1 || result_2;
        }
    }
}
