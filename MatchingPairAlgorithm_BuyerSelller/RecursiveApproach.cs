using MatchingPairAlgorithm_sellerselller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    class RecursiveApproach
    {
        public void updatePastStack(List<NewPartyWithId> sourceList,int remaing_amt,String userId)
        {
            int tempRemaingAmt = remaing_amt;
            for(int i = 0; i < sourceList.Count; i++)
            {
                if (sourceList[i].userId == userId)
                {
                    if (remaing_amt > 0)
                    {
                        int temp = sourceList[i].qty;
                        sourceList[i].qty -= Math.Min(sourceList[i].qty, remaing_amt);
                        remaing_amt -= temp;
                    }
                    else
                    {
                        sourceList[i].totalQtyTillNow -= tempRemaingAmt;
                    }
                }
            }
        }
        public Boolean subset_sum(int remaining_amount, int starting_index, List<NewPartyWithId> list, NewPartyWithId source, int source_index, List<NewPartyWithId> source_list)
        {
            if (remaining_amount == 0)
            {
                source.qty = 0;
                return true;
            }
            else if (remaining_amount >= source.range && source.a == 0 && starting_index >= list.Count || source_index >= source_list.Count)
            {
                source.qty = remaining_amount;
                return true;
            }
            if ((source.range != 0 && remaining_amount < source.range) || starting_index >= list.Count || source_index >= source_list.Count || remaining_amount < 0)
                return false;
            Boolean result_1 = false;
            Boolean result_2 = false;
            int tempQuantity = list[starting_index].qty;
            if (list[starting_index].qty != list[starting_index].totalQtyTillNow && list[starting_index].isChild && (source.range == 0 || source.range <= list[starting_index].qty) && (source.a==0 || source.qty<=list[starting_index].totalQtyTillNow))
            {
                if(list[starting_index].range==0 && list[starting_index].a==0 && (source.range==0 || source.range <= list[starting_index].totalQtyTillNow))
                {
                    if (remaining_amount <= list[starting_index].totalQtyTillNow)
                    {
                        updatePastStack(list, remaining_amount, list[starting_index].userId);
                        source.qty = 0;
                        return true;
                    }
                    else
                    {
                        int endQty = 1;
                        if (source.range != 0)
                        {
                            endQty = source.range;
                        }
                        for (int i = list[starting_index].totalQtyTillNow; i >= endQty; i--)
                        {
                            result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index, source_list);
                            if (result_1)
                            {
                                updatePastStack(list, i, list[starting_index].userId);
                                source.qty = 0;
                                return true;
                            }
                        }
                    }
                }
                else if(list[starting_index].range==0 && list[starting_index].a!=0 && source.range <= list[starting_index].totalQtyTillNow)
                {
                    if (remaining_amount == list[starting_index].totalQtyTillNow)
                    {
                        updatePastStack(list, remaining_amount, list[starting_index].userId);
                        source.qty = 0;
                        return true;
                    }
                    else if(remaining_amount<list[starting_index].totalQtyTillNow)
                    {
                        if (subset_sum(list[starting_index].totalQtyTillNow-remaining_amount, 0, source_list, list[starting_index], starting_index, list))
                        {
                            updatePastStack(list, remaining_amount, list[starting_index].userId);
                            source.qty = 0;
                            return true;
                        }
                    }
                    else
                    {
                        if (subset_sum(remaining_amount - list[starting_index].totalQtyTillNow, starting_index + 1, list, source, source_index, source_list))
                        {
                            updatePastStack(list, remaining_amount, list[starting_index].userId);
                            source.qty = 0;
                            return true;
                        }
                    }
                }
                else if (list[starting_index].range != 0 && list[starting_index].a == 0 && source.range <= list[starting_index].totalQtyTillNow)
                {
                    if (remaining_amount >= list[starting_index].range)
                    {
                        if (remaining_amount <= list[starting_index].totalQtyTillNow)
                        {
                            updatePastStack(list, remaining_amount, list[starting_index].userId);
                            source.qty = 0;
                            return true;
                        }
                        else
                        {
                            int endQty = 1;
                            if (source.range != 0)
                            {
                                endQty = source.range;
                            }
                            for (int i = list[starting_index].totalQtyTillNow; i >= endQty; i--)
                            {
                                result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index, source_list);
                                if (result_1)
                                {
                                    updatePastStack(list, i, list[starting_index].userId);
                                    source.qty = 0;
                                    return true;
                                }
                            }
                        }
                    }
                    else if (list[starting_index].range != 0 && list[starting_index].a != 0 && source.range <= list[starting_index].totalQtyTillNow && remaining_amount >=list[starting_index].range)
                    {
                        if (remaining_amount == list[starting_index].totalQtyTillNow)
                        {
                            updatePastStack(list, remaining_amount, list[starting_index].userId);
                            source.qty = 0;
                            return true;
                        }
                        else if (remaining_amount < list[starting_index].totalQtyTillNow)
                        {
                            if (subset_sum(list[starting_index].totalQtyTillNow - remaining_amount, 0, source_list, list[starting_index], starting_index, list))
                            {
                                updatePastStack(list, remaining_amount, list[starting_index].userId);
                                source.qty = 0;
                                return true;
                            }
                        }
                        else
                        {
                            if (subset_sum(remaining_amount - list[starting_index].totalQtyTillNow, starting_index + 1, list, source, source_index, source_list))
                            {
                                updatePastStack(list, remaining_amount, list[starting_index].userId);
                                source.qty = 0;
                                return true;
                            }
                        }
                    }
                }
                return subset_sum(remaining_amount, starting_index + 1, list, source, source_index, source_list);
            }
            else if(!list[starting_index].isChild)
            {
                if (list[starting_index].range == 0 && list[starting_index].a == 0 && (source.range == 0 || source.range <= list[starting_index].qty))
                {
                    if (remaining_amount <= list[starting_index].qty)
                    {
                        list[starting_index].qty -= remaining_amount;
                        //updatePastStack(list,remaining_amount,list[start])
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
                            list[starting_index].qty = tempQuantity - i;
                            result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index, source_list);
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
                        result_1 = subset_sum(remaining_amount - tempQuantity, starting_index + 1, list, source, source_index, source_list);
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
                        result_1 = subset_sum(remaining_amount - tempQuantity, starting_index + 1, list, source, source_index, source_list);
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
                            result_1 = subset_sum(remaining_amount - i, starting_index + 1, list, source, source_index, source_list);
                            if (result_1)
                            {
                                break;
                            }
                        }
                    }
                }
                if (result_1 == false)
                {
                    list[starting_index].qty = tempQuantity;
                    result_2 = subset_sum(remaining_amount, starting_index + 1, list, source, source_index, source_list);
                }
                return result_1 || result_2;
            }
            return false;
        }
    }
}
