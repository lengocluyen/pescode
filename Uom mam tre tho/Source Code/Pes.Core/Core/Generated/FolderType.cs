using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FolderTypes")]
    public partial class FolderType : EntityBase<FolderType>
    {
        #region Properties

		
        public override object Id
        {

            get { return FolderTypeID; }
            set { FolderTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FolderTypeID { get; set; }
		public string Name { get; set; }

        #endregion

        public FolderType()
        {

        }

        public FolderType(object id)
        {
			if (id != null)
            {
				FolderType entity = Single(id);
				if (entity != null)
					entity.CopyTo<FolderType>(this);
				else
					this.FolderTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FolderTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}