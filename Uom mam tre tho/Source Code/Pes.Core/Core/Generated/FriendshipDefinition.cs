using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FriendshipDefinitions")]
    public partial class FriendshipDefinition : EntityBase<FriendshipDefinition>
    {
        #region Properties

		
        public override object Id
        {

            get { return FriendshipDefinitionID; }
            set { FriendshipDefinitionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FriendshipDefinitionID { get; set; }
		public int FriendID { get; set; }
		public int FriendshipDefinitionTypeID { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public string OptionalText1 { get; set; }
		public string OptionalText2 { get; set; }
		public bool Approved { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public FriendshipDefinition()
        {

        }

        public FriendshipDefinition(object id)
        {
			if (id != null)
            {
				FriendshipDefinition entity = Single(id);
				if (entity != null)
					entity.CopyTo<FriendshipDefinition>(this);
				else
					this.FriendshipDefinitionID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FriendshipDefinitionID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}