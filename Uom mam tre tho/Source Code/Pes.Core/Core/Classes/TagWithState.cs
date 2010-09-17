using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public class TagWithState:IComparable<Tag>
    {
        public decimal InitialValue { get; set; }
        public decimal MinimumOffset { get; set; }
        public decimal Ranged { get; set; }
        public decimal PreCalculatedValue { get; set; }
        public decimal FinalCalculatedValue { get; set; }
        public int FontSize { get; set; }

        public long TagID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public System.Data.Linq.Binary Timestamp { get; set; }
        public DateTime CreateDate { get; set; }

        public int CompareTo(TagWithState other)
        {
            return other.FinalCalculatedValue.CompareTo(this.FinalCalculatedValue);
        }

        #region IComparable<Tag> Members

        public int CompareTo(Tag other)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
