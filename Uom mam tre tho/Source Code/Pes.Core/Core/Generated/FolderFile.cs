using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FolderFiles")]
    public partial class FolderFile : EntityBase<FolderFile>
    {
        #region Properties

		
        public override object Id
        {

            get { return FolderID; }
            set { FolderID = (long)value; }
        }
        [SubSonicPrimaryKey]
		public long FolderID { get; set; }
        [SubSonicPrimaryKey]
        public long FileID { get; set; }
		public int AccountID { get; set; }
		public DateTime? CreateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public FolderFile()
        {

        }

        public FolderFile(object id)
        {
			if (id != null)
            {
				FolderFile entity = Single(id);
				if (entity != null)
					entity.CopyTo<FolderFile>(this);
				else
					this.FolderID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FolderID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}