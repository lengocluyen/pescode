using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VPart")]
    public partial class VPart:EntityBase<VPart>
    {
        #region Properties

        public override object Id
        {

            get { return PartID; }
            set { PartID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PartID { get; set; }
        public int PartModuleID{get;set;}
        public int PartLessionID{get;set;}
        public string PartContent{get;set;}
        public int PartPriority{get;set;}
        #endregion

        public VPart()
        {

        }

        public VPart(object id)
        {
			if (id != null)
            {
                VPart entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VPart>(this);
				else
					this.PartID = 0;
			}
        }

    }
}
