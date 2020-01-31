using System;
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
        public NewPartyWithId(int q, int allOrNone, int r, String userId)
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
}
