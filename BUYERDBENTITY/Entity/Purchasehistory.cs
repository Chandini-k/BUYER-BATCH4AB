using System;
using System.Collections.Generic;

namespace BUYERDBENTITY.Entity
{
    public partial class Purchasehistory
    {
        public int Id { get; set; }
        public int? Bid { get; set; }
        public string Transactiontype { get; set; }
        public int? Itemid { get; set; }
        public int? Noofitems { get; set; }
        public DateTime Datetime { get; set; }
        public string Remarks { get; set; }
        public string Transactionstatus { get; set; }

        public virtual Buyer B { get; set; }
        public virtual Items Item { get; set; }
    }
}
