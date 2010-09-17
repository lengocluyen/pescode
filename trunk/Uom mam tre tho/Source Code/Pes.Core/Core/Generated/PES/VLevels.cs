using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VLevels")]
    public partial class VLevels:EntityBase<VLevels>
    {
         #region Properties

        public override object Id
        {

            get { return LevelID; }
            set { LevelID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LevelID { get; set; }
        public string LevelName{get;set;}
        #endregion

        public VLevels()
        {
        }

        public VLevels(object id)
        {
			if (id != null)
            {
                VLevels entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VLevels>(this);
				else
					this.LevelID = 0;
			}
        }

    }
}
