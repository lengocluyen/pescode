using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("VisibilityLevels")]
    public partial class VisibilityLevel : EntityBase<VisibilityLevel>
    {
        #region Properties

		
        public override object Id
        {

            get { return VisibilityLevelID; }
            set { VisibilityLevelID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int VisibilityLevelID { get; set; }
		public string Name { get; set; }

        #endregion

        public VisibilityLevel()
        {

        }

        public VisibilityLevel(object id)
        {
			if (id != null)
            {
				VisibilityLevel entity = Single(id);
				if (entity != null)
					entity.CopyTo<VisibilityLevel>(this);
				else
					this.VisibilityLevelID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (VisibilityLevelID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}