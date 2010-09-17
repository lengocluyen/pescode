using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Terms")]
    public partial class Term : EntityBase<Term>
    {
        #region Properties

		
        public override object Id
        {

            get { return TermID; }
            set { TermID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TermID { get; set; }
		public string Terms { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public Term()
        {

        }

        public Term(object id)
        {
			if (id != null)
            {
				Term entity = Single(id);
				if (entity != null)
					entity.CopyTo<Term>(this);
				else
					this.TermID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (TermID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}