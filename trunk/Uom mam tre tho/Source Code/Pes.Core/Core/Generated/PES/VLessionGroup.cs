using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VLessionGroup")]
    public partial class VLessionGroup:EntityBase<VLessionGroup>
    {
         #region Properties

        public override object Id
        {

            get { return LessionGroupID; }
            set { LessionGroupID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LessionGroupID { get; set; }
        public string LessionGroupName{get;set;}
        public string LessionGroupImg{get;set;}
        public int LessionGroupView{get;set;}
        public int LessionGroupPriority{get;set;}
        public int LevelID{get;set;}
        #endregion

        public VLessionGroup()
        {

        }

        public VLessionGroup(object id)
        {
			if (id != null)
            {
                VLessionGroup entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VLessionGroup>(this);
				else
					this.LessionGroupID = 0;
			}
        }

    }
}
