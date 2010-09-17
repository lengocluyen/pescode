using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Gags")]
    public partial class Gag : EntityBase<Gag>
    {
        #region Properties

		
        public override object Id
        {

            get { return GagID; }
            set { GagID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long GagID { get; set; }
		public int AccountID { get; set; }
		public string AccountUsername { get; set; }
		public DateTime CreateDate { get; set; }
		public System.Data.Linq.Binary TimeStamp { get; set; }
		public string Reason { get; set; }
		public DateTime? GagUntilDate { get; set; }
		public int GaggedByAccountID { get; set; }

        #endregion

        public Gag()
        {

        }

        public Gag(object id)
        {
			if (id != null)
            {
				Gag entity = Single(id);
				if (entity != null)
					entity.CopyTo<Gag>(this);
				else
					this.GagID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (GagID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}