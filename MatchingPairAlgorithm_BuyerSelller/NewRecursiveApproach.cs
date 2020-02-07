using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingPairAlgorithm_BuyerSelller
{
    class NewRecursiveApproach
    {
        //public Boolean isCompatibleGivesTrade(int remaining_amount, int starting_index, List<NewPartyWithId> pivotStack, NewPartyWithId source, int source_index, List<NewPartyWithId> source_list)
        //{
        //    if (remaining_amount == 0)
        //    {
        //        return true;
        //    }
        //    if (remaining_amount < source.range || starting_index >= pivotStack.Count || source_index >= source_list.Count)
        //    {
        //        return false;
        //    }
        //    if (pivotStack[starting_index].qty <= 0 || pivotStack[starting_index].isInRecursion)
        //        return isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //    source.isInRecursion = true;
        //    if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (remaining_amount <= pivotStack[starting_index].qty)
        //        {
        //            pivotStack[starting_index].qty -= remaining_amount;
        //            source.qty = 0;
        //            source.isInRecursion = false;
        //            return true;
        //        }
        //        else
        //        {
        //            remaining_amount -= pivotStack[starting_index].qty;
        //            pivotStack[starting_index].qty = 0;
        //            source.qty = remaining_amount;
        //            Boolean result=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (remaining_amount == pivotStack[starting_index].qty)
        //        {
        //            pivotStack[starting_index].qty -= remaining_amount;
        //            source.qty = 0;
        //            source.isInRecursion = false;
        //            return true;
        //        }
        //        else if (remaining_amount < pivotStack[starting_index].qty)
        //        {
        //            int tempQty = source.qty;
        //            for (int i = tempQty; i >= 1; i--)
        //            {
        //                source.qty = tempQty - i;
        //                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    Boolean result= isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //                else
        //                {
        //                    source.qty = tempQty;
        //                }
        //            }
        //            source.isInRecursion = false;
        //            Boolean result1=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            return result1;
        //        }
        //        else
        //        {
        //            remaining_amount -= pivotStack[starting_index].qty;
        //            pivotStack[starting_index].qty = 0;
        //            source.qty = remaining_amount;
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (remaining_amount <= pivotStack[starting_index].qty)
        //        {
        //            pivotStack[starting_index].qty -= remaining_amount;
        //            source.qty = 0;
        //            source.isInRecursion = false;
        //            return true;
        //        }
        //        else
        //        {
        //            int tempQty = pivotStack[starting_index].qty;
        //            for (int i = tempQty; i >= 1; i--)
        //            {
        //                if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
        //                {
        //                    source.qty = 0;
        //                    pivotStack[starting_index].qty = tempQty - i;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //            }
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (remaining_amount == pivotStack[starting_index].qty)
        //        {
        //            source.qty = pivotStack[starting_index].qty = 0;
        //            source.isInRecursion = false;
        //            return true;
        //        }
        //        else if (remaining_amount < pivotStack[starting_index].qty)
        //        {
        //            int tempQty = source.qty;
        //            source.qty = 0;
        //            if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
        //            {
        //                pivotStack[starting_index].qty = 0;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                source.qty = tempQty;
        //                Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
        //            {
        //                source.qty = 0;
        //                pivotStack[starting_index].qty = 0;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //    }
        //    else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
        //    {
        //        if (remaining_amount == pivotStack[starting_index].qty)
        //        {
        //            source.qty = 0;
        //            pivotStack[starting_index].qty = 0;
        //            source.isInRecursion = false;
        //            return true;
        //        }
        //        else if (remaining_amount > pivotStack[starting_index].qty)
        //        {
        //            if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
        //            {
        //                source.qty = remaining_amount - pivotStack[starting_index].qty;
        //                pivotStack[starting_index].qty = 0;
        //                Boolean result= isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
        //            {
        //                source.qty = 0;
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //    }
        //    else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
        //    {
        //        if (remaining_amount <= pivotStack[starting_index].qty)
        //        {
        //            if (remaining_amount >= pivotStack[starting_index].range)
        //            {
        //                source.qty = 0;
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                Boolean result=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            int tempQty = pivotStack[starting_index].qty;
        //            source.qty -= pivotStack[starting_index].qty;
        //            pivotStack[starting_index].qty = 0;
        //            Boolean result=isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (pivotStack[starting_index].qty >= source.range)
        //        {
        //            if (pivotStack[starting_index].qty <= remaining_amount)
        //            {
        //                source.qty -= pivotStack[starting_index].qty;
        //                pivotStack[starting_index].qty = 0;
        //                Boolean result=isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
        //    {
        //        if (remaining_amount >= pivotStack[starting_index].range)
        //        {
        //            if (remaining_amount <= pivotStack[starting_index].qty)
        //            {
        //                source.qty = 0;
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                for (int i = pivotStack[starting_index].qty; i >= pivotStack[starting_index].range; i--)
        //                {
        //                    if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
        //                    {
        //                        source.qty = 0;
        //                        pivotStack[starting_index].qty -= i;
        //                        source.isInRecursion = false;
        //                        return true;
        //                    }
        //                }
        //                Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
        //    {
        //        if (remaining_amount >= pivotStack[starting_index].qty)
        //        {
        //            if (pivotStack[starting_index].qty >= source.range)
        //            {
        //                int tempQty = pivotStack[starting_index].qty;
        //                pivotStack[starting_index].qty = 0;
        //                source.qty -= tempQty;
        //                Boolean result= isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                Boolean result=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            int tempQty = source.qty;
        //            for (int i = source.qty; i >= source.range; i--)
        //            {
        //                source.qty = tempQty - i;
        //                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    Boolean result=isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //            }
        //            source.qty = tempQty;
        //            Boolean result1=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result1;
        //        }
        //    }
        //    else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range != 0)
        //    {
        //        if (remaining_amount >= pivotStack[starting_index].range)
        //        {
        //            if (remaining_amount <= pivotStack[starting_index].qty)
        //            {
        //                int tempQty = source.qty;
        //                source.qty = 0;
        //                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                else
        //                {
        //                    source.qty = tempQty;
        //                    Boolean result=isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //            }
        //            else
        //            {
        //                if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
        //                {
        //                    pivotStack[starting_index].qty = source.qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                else
        //                {
        //                    Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range == 0 && pivotStack[starting_index].a != 0)
        //    {
        //        if (pivotStack[starting_index].qty >= source.range)
        //        {
        //            if (pivotStack[starting_index].qty <= remaining_amount)
        //            {
        //                if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
        //                {
        //                    source.qty = pivotStack[starting_index].qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                else
        //                {
        //                    Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //            }
        //            else
        //            {
        //                int tempQty = source.qty;
        //                source.qty = 0;
        //                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                else
        //                {
        //                    source.qty = tempQty;
        //                    Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                    source.isInRecursion = false;
        //                    return result;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range != 0)
        //    {
        //        if (remaining_amount >= pivotStack[starting_index].range)
        //        {
        //            if (remaining_amount >= pivotStack[starting_index].qty)
        //            {
        //                int tempQty = pivotStack[starting_index].qty;
        //                pivotStack[starting_index].qty = 0;
        //                Boolean result=isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                int tempQty = source.qty;
        //                source.qty = 0;
        //                for (int i = remaining_amount; i >= pivotStack[starting_index].range; i--)
        //                {
        //                    if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

        //                    {
        //                        pivotStack[starting_index].qty = 0;
        //                        source.qty = tempQty - i;
        //                        Boolean result= isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list);
        //                        source.isInRecursion = false;
        //                        return result;
        //                    }
        //                }
        //                source.qty = tempQty;
        //                Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result1;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range == 0 && pivotStack[starting_index].a == 0)
        //    {
        //        if (source.range <= pivotStack[starting_index].qty)
        //        {
        //            if (remaining_amount <= pivotStack[starting_index].qty)
        //            {
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //            else
        //            {
        //                for (int i = pivotStack[starting_index].qty; i >= source.range; i--)
        //                {
        //                    if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))

        //                    {
        //                        pivotStack[starting_index].qty -= i;
        //                        source.isInRecursion = false;
        //                        return true;
        //                    }
        //                }
        //                Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list); 
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range != 0 && pivotStack[starting_index].a == 0)
        //    {
        //        if (pivotStack[starting_index].range <= remaining_amount && source.range <= pivotStack[starting_index].qty)
        //        {
        //            if (pivotStack[starting_index].qty <= remaining_amount)
        //            {
        //                for (int i = pivotStack[starting_index].qty; i >= Math.Max(source.range, pivotStack[starting_index].range); i--)
        //                {
        //                    if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
        //                    {
        //                        pivotStack[starting_index].qty -= i;
        //                        source.isInRecursion = false;
        //                        return true;
        //                    }
        //                }
        //                Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                pivotStack[starting_index].qty -= remaining_amount;
        //                source.qty = 0;
        //                source.isInRecursion = false;
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].range != 0 && pivotStack[starting_index].a != 0)
        //    {
        //        if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
        //        {
        //            if (remaining_amount >= pivotStack[starting_index].qty)
        //            {
        //                int tempQty = pivotStack[starting_index].qty;
        //                pivotStack[starting_index].qty = 0;
        //                Boolean result= isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //            else
        //            {
        //                int tempQty = source.qty;
        //                source.qty = 0;
        //                for (int i = remaining_amount; i >= Math.Max(source.range, pivotStack[starting_index].range); i--)
        //                {
        //                    if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
        //                    {
        //                        pivotStack[starting_index].qty -= remaining_amount;
        //                        source.qty = tempQty - i;
        //                        Boolean result= isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list);
        //                        source.isInRecursion = false;
        //                        return result;
        //                    }
        //                }
        //                source.qty = tempQty;
        //                Boolean result1= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result1;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else if(source.range!=0 && source.a!=0 && pivotStack[starting_index].a!=0 && pivotStack[starting_index].range != 0)
        //    {
        //        if(remaining_amount>=pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
        //        {
        //            if (remaining_amount <= pivotStack[starting_index].qty)
        //            {
        //                int tempQty = source.qty;
        //                source.qty = 0;
        //                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - tempQty, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                source.qty = tempQty;
        //                source.isInRecursion = false;
        //                return isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            }
        //            else
        //            {
        //                if (isCompatibleGivesTrade(remaining_amount-pivotStack[starting_index].qty, starting_index+1, pivotStack, source, source_index, source_list))
        //                {
        //                    pivotStack[starting_index].qty = 0;
        //                    source.qty = 0;
        //                    source.isInRecursion = false;
        //                    return true;
        //                }
        //                Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //                source.isInRecursion = false;
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            Boolean result= isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
        //            source.isInRecursion = false;
        //            return result;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Source" + source.toString());
        //    }
        //    source.isInRecursion = false;
        //    return false;
        //}
        public void updateQty(int remaing_amount,List<NewPartyWithId> pivotStack,String userId)
        {
            int tempRemaingAmount = remaing_amount;
            int tq = 0;
            for(int i = 0; i < pivotStack.Count; i++)
            {
                if (pivotStack[i].userId == userId)
                {
                    if (remaing_amount > 0)
                    {
                        int minAmt = Math.Min(pivotStack[i].qty, remaing_amount);
                        tq += minAmt;
                        pivotStack[i].qty -= minAmt;
                        pivotStack[i].totalQtyTillNow -= tq;
                        remaing_amount -= minAmt;
                    }
                    else
                    {
                        pivotStack[i].totalQtyTillNow -= tempRemaingAmount;
                    }
                }
            }
        }
        public Boolean isCompatibleGivesTrade(int remaining_amount, int starting_index, List<NewPartyWithId> pivotStack, NewPartyWithId source, int source_index, List<NewPartyWithId> source_list)
        {
            if (remaining_amount == 0)
            {
                return true;
            }
            if (remaining_amount < source.range || starting_index >= pivotStack.Count || source_index >= source_list.Count)
            {
                return false;
            }
            if (pivotStack[starting_index].qty <= 0 || pivotStack[starting_index].isInRecursion)
                return isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
            source.isInRecursion = true;
            if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
            {
                if (remaining_amount <= pivotStack[starting_index].totalQtyTillNow)
                {
                    pivotStack[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    source.isInRecursion = false;
                    return true;
                }
                else
                {
                    remaining_amount -= pivotStack[starting_index].qty;
                    pivotStack[starting_index].qty = 0;
                    source.qty = remaining_amount;
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
            {
                if (remaining_amount == pivotStack[starting_index].qty)
                {
                    pivotStack[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    source.isInRecursion = false;
                    return true;
                }
                else if (remaining_amount < pivotStack[starting_index].qty)
                {
                    int tempQty = source.qty;
                    for (int i = tempQty; i >= 1; i--)
                    {
                        source.qty = tempQty - i;
                        if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
                        {
                            pivotStack[starting_index].qty = 0;
                            Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                        else
                        {
                            source.qty = tempQty;
                        }
                    }
                    source.isInRecursion = false;
                    Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    return result1;
                }
                else
                {
                    remaining_amount -= pivotStack[starting_index].qty;
                    pivotStack[starting_index].qty = 0;
                    source.qty = remaining_amount;
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
            {
                if (remaining_amount <= pivotStack[starting_index].qty )
                {
                    //updateQty(remaining_amount, pivotStack, pivotStack[starting_index].userId);
                    pivotStack[starting_index].qty -= remaining_amount;
                    source.qty = 0;
                    source.isInRecursion = false;
                    return true;
                }
                else
                {
                    int tempQty = pivotStack[starting_index].qty;
                    for (int i = tempQty; i >= 1; i--)
                    {
                        if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
                        {
                            source.qty = 0;
                            pivotStack[starting_index].qty = tempQty - i;
                            source.isInRecursion = false;
                            return true;
                        }
                    }
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
            {
                if (remaining_amount == pivotStack[starting_index].qty)
                {
                    source.qty = pivotStack[starting_index].qty = 0;
                    source.isInRecursion = false;
                    return true;
                }
                else if (remaining_amount < pivotStack[starting_index].qty)
                {
                    int tempQty = source.qty;
                    source.qty = 0;
                    if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
                    {
                        pivotStack[starting_index].qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        source.qty = tempQty;
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
                    {
                        source.qty = 0;
                        pivotStack[starting_index].qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
            }
            else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
            {
                if (remaining_amount == pivotStack[starting_index].qty)
                {
                    source.qty = 0;
                    pivotStack[starting_index].qty = 0;
                    source.isInRecursion = false;
                    return true;
                }
                else if (remaining_amount > pivotStack[starting_index].qty)
                {
                    if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
                    {
                        source.qty = remaining_amount - pivotStack[starting_index].qty;
                        pivotStack[starting_index].qty = 0;
                        Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
                    {
                        source.qty = 0;
                        pivotStack[starting_index].qty -= remaining_amount;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
            }
            else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
            {
                if (source.isChild && source.totalQtyTillNow >= pivotStack[starting_index].range)
                {
                    if (source.totalQtyTillNow <= pivotStack[starting_index].qty)
                    {
                        int updatedQty = source.totalQtyTillNow;
                        updateQty(source.totalQtyTillNow, source_list, source.userId);
                        pivotStack[starting_index].qty -= updatedQty;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        updateQty(pivotStack[starting_index].qty, source_list, source.userId);
                        pivotStack[starting_index].qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                }
                else if(source.isChild && source.totalQtyTillNow < pivotStack[starting_index].range)
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
                else if (remaining_amount <= pivotStack[starting_index].qty)
                {
                    if (remaining_amount >= pivotStack[starting_index].range)
                    {
                        source.qty = 0;
                        pivotStack[starting_index].qty -= remaining_amount;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    int tempQty = pivotStack[starting_index].qty;
                    source.qty -= pivotStack[starting_index].qty;
                    pivotStack[starting_index].qty = 0;
                    Boolean result = isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range == 0)
            {
                if(pivotStack[starting_index].isChild && pivotStack[starting_index].totalQtyTillNow >= source.range)
                {
                    if (remaining_amount <= pivotStack[starting_index].totalQtyTillNow)
                    {
                        updateQty(remaining_amount, pivotStack, pivotStack[starting_index].userId);
                        source.qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        int updatedQty = pivotStack[starting_index].totalQtyTillNow;
                        updateQty(updatedQty, pivotStack, pivotStack[starting_index].userId);
                        source.qty = remaining_amount-updatedQty;
                        Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }

                }
                else if (pivotStack[starting_index].qty >= source.range)
                {
                    
                    if (pivotStack[starting_index].qty <= remaining_amount)
                    {
                        source.qty -= pivotStack[starting_index].qty;
                        pivotStack[starting_index].qty = 0;
                        Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                    else
                    {
                        pivotStack[starting_index].qty -= remaining_amount;
                        source.qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a == 0 && pivotStack[starting_index].range != 0)
            {
                if (remaining_amount >= pivotStack[starting_index].range)
                {
                    if (remaining_amount <= pivotStack[starting_index].qty)
                    {
                        source.qty = 0;
                        pivotStack[starting_index].qty -= remaining_amount;
                        source.isInRecursion = false;
                        return true;
                    }
                    else
                    {
                        for (int i = pivotStack[starting_index].qty; i >= pivotStack[starting_index].range; i--)
                        {
                            if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
                            {
                                source.qty = 0;
                                pivotStack[starting_index].qty -= i;
                                source.isInRecursion = false;
                                return true;
                            }
                        }
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range == 0)
            {
                if (remaining_amount >= pivotStack[starting_index].qty)
                {
                    if (pivotStack[starting_index].qty >= source.range)
                    {
                        int tempQty = pivotStack[starting_index].qty;
                        pivotStack[starting_index].qty = 0;
                        source.qty -= tempQty;
                        Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    int tempQty = source.qty;
                    for (int i = source.qty; i >= source.range; i--)
                    {
                        source.qty = tempQty - i;
                        if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

                        {
                            pivotStack[starting_index].qty = 0;
                            Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                    source.qty = tempQty;
                    Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result1;
                }
            }
            else if (source.a != 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range != 0)
            {
                if (remaining_amount >= pivotStack[starting_index].range)
                {
                    if (remaining_amount <= pivotStack[starting_index].qty)
                    {
                        int tempQty = source.qty;
                        source.qty = 0;
                        if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

                        {
                            pivotStack[starting_index].qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            source.qty = tempQty;
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                    else
                    {
                        if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
                        {
                            pivotStack[starting_index].qty = source.qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range == 0 && pivotStack[starting_index].a != 0)
            {
                if (pivotStack[starting_index].qty >= source.range)
                {
                    if (pivotStack[starting_index].qty <= remaining_amount)
                    {
                        if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
                        {
                            source.qty = pivotStack[starting_index].qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                    else
                    {
                        int tempQty = source.qty;
                        source.qty = 0;
                        if (isCompatibleGivesTrade(pivotStack[starting_index].qty - remaining_amount, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

                        {
                            pivotStack[starting_index].qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            source.qty = tempQty;
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a == 0 && source.range == 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range != 0)
            {
                if (source.isChild)
                {
                    if (source.totalQtyTillNow >= pivotStack[starting_index].range)
                    {
                        if (source.totalQtyTillNow >= pivotStack[starting_index].qty)
                        {
                            int tempQty = pivotStack[starting_index].qty;
                            updateQty(tempQty, source_list, source.userId);
                            pivotStack[starting_index].qty = 0;
                            Boolean result = isCompatibleGivesTrade(source.qty, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                        else
                        {
                            int tempQty = source.qty;
                            source.qty = 0;
                            for (int i = remaining_amount; i >= pivotStack[starting_index].range; i--)
                            {
                                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

                                {
                                    pivotStack[starting_index].qty = 0;
                                    source.qty = tempQty - i;
                                    Boolean result = isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list);
                                    source.isInRecursion = false;
                                    return result;
                                }
                            }
                            source.qty = tempQty;
                            Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result1;
                        }
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    if (remaining_amount >= pivotStack[starting_index].range)
                    {
                        if (remaining_amount >= pivotStack[starting_index].qty)
                        {
                            int tempQty = pivotStack[starting_index].qty;
                            pivotStack[starting_index].qty = 0;
                            Boolean result = isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                        else
                        {
                            int tempQty = source.qty;
                            source.qty = 0;
                            for (int i = remaining_amount; i >= pivotStack[starting_index].range; i--)
                            {
                                if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))

                                {
                                    pivotStack[starting_index].qty = 0;
                                    source.qty = tempQty - i;
                                    Boolean result = isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list);
                                    source.isInRecursion = false;
                                    return result;
                                }
                            }
                            source.qty = tempQty;
                            Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result1;
                        }
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
            }
            else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range == 0 && pivotStack[starting_index].a == 0)
            {
                if (pivotStack[starting_index].isChild)
                {
                    if (source.range <= pivotStack[starting_index].totalQtyTillNow)
                    {
                        if (remaining_amount <= pivotStack[starting_index].totalQtyTillNow)
                        {
                            updateQty(remaining_amount, pivotStack, pivotStack[starting_index].userId);
                            source.qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            for (int i = pivotStack[starting_index].totalQtyTillNow; i >= source.range; i--)
                            {
                                if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))

                                {
                                    updateQty(i, pivotStack, pivotStack[starting_index].userId);
                                    source.isInRecursion = false;
                                    return true;
                                }
                            }
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    if (source.range <= pivotStack[starting_index].qty)
                    {
                        if (remaining_amount <= pivotStack[starting_index].qty)
                        {
                            pivotStack[starting_index].qty -= remaining_amount;
                            source.qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        else
                        {
                            for (int i = pivotStack[starting_index].qty; i >= source.range; i--)
                            {
                                if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))

                                {
                                    pivotStack[starting_index].qty -= i;
                                    source.isInRecursion = false;
                                    return true;
                                }
                            }
                            Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                            source.isInRecursion = false;
                            return result;
                        }
                    }
                    else
                    {
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
            }
            else if (source.a != 0 && source.range != 0 && pivotStack[starting_index].range != 0 && pivotStack[starting_index].a == 0)
            {
                if (pivotStack[starting_index].range <= remaining_amount && source.range <= pivotStack[starting_index].qty)
                {
                    if (pivotStack[starting_index].qty <= remaining_amount)
                    {
                        for (int i = pivotStack[starting_index].qty; i >= Math.Max(source.range, pivotStack[starting_index].range); i--)
                        {
                            if (isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list))
                            {
                                pivotStack[starting_index].qty -= i;
                                source.isInRecursion = false;
                                return true;
                            }
                        }
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                    else
                    {
                        pivotStack[starting_index].qty -= remaining_amount;
                        source.qty = 0;
                        source.isInRecursion = false;
                        return true;
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.a == 0 && source.range != 0 && pivotStack[starting_index].range != 0 && pivotStack[starting_index].a != 0)
            {
                if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
                {
                    if (remaining_amount >= pivotStack[starting_index].qty)
                    {
                        int tempQty = pivotStack[starting_index].qty;
                        pivotStack[starting_index].qty = 0;
                        Boolean result = isCompatibleGivesTrade(remaining_amount - tempQty, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                    else
                    {
                        int tempQty = source.qty;
                        source.qty = 0;
                        for (int i = remaining_amount; i >= Math.Max(source.range, pivotStack[starting_index].range); i--)
                        {
                            if (isCompatibleGivesTrade(pivotStack[starting_index].qty - i, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
                            {
                                pivotStack[starting_index].qty -= remaining_amount;
                                source.qty = tempQty - i;
                                Boolean result = isCompatibleGivesTrade(remaining_amount - i, starting_index + 1, pivotStack, source, source_index, source_list);
                                source.isInRecursion = false;
                                return result;
                            }
                        }
                        source.qty = tempQty;
                        Boolean result1 = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result1;
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else if (source.range != 0 && source.a != 0 && pivotStack[starting_index].a != 0 && pivotStack[starting_index].range != 0)
            {
                if (remaining_amount >= pivotStack[starting_index].range && pivotStack[starting_index].qty >= source.range)
                {
                    if (remaining_amount <= pivotStack[starting_index].qty)
                    {
                        int tempQty = source.qty;
                        source.qty = 0;
                        if (isCompatibleGivesTrade(pivotStack[starting_index].qty - tempQty, 0, source_list, pivotStack[starting_index], starting_index, pivotStack))
                        {
                            pivotStack[starting_index].qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        source.qty = tempQty;
                        source.isInRecursion = false;
                        return isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    }
                    else
                    {
                        if (isCompatibleGivesTrade(remaining_amount - pivotStack[starting_index].qty, starting_index + 1, pivotStack, source, source_index, source_list))
                        {
                            pivotStack[starting_index].qty = 0;
                            source.qty = 0;
                            source.isInRecursion = false;
                            return true;
                        }
                        Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                        source.isInRecursion = false;
                        return result;
                    }
                }
                else
                {
                    Boolean result = isCompatibleGivesTrade(remaining_amount, starting_index + 1, pivotStack, source, source_index, source_list);
                    source.isInRecursion = false;
                    return result;
                }
            }
            else
            {
                Console.WriteLine("Source" + source.toString());
            }
            source.isInRecursion = false;
            return false;
        }
    }
}
