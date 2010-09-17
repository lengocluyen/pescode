using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("ToolsType")]
    public partial class ToolsType : EntityBase<ToolsType>
    {
        #region Properties

        public override object Id
        {

            get { return ToolTypeID; }
            set { ToolTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ToolTypeID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public ToolsType()
        {

        }

        public ToolsType(object id)
        {
			if (id != null)
            {
				ToolsType entity = Single(id);
				if (entity != null)
					entity.CopyTo<ToolsType>(this);
				else
					this.ToolTypeID = 0;
			}
        }


    }
}