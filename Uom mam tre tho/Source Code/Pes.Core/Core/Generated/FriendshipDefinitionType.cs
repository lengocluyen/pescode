using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FriendshipDefinitionTypes")]
    public partial class FriendshipDefinitionType : EntityBase<FriendshipDefinitionType>
    {
        #region Properties

		
        public override object Id
        {

            get { return FriendshipDefinitionTypeID; }
            set { FriendshipDefinitionTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FriendshipDefinitionTypeID { get; set; }
		public string Name { get; set; }

        #endregion

        public FriendshipDefinitionType()
        {

        }

        public FriendshipDefinitionType(object id)
        {
			if (id != null)
            {
				FriendshipDefinitionType entity = Single(id);
				if (entity != null)
					entity.CopyTo<FriendshipDefinitionType>(this);
				else
					this.FriendshipDefinitionTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FriendshipDefinitionTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}