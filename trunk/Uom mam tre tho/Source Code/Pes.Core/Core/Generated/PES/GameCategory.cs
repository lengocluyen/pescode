using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GameCategory")]
    public partial class GameCategory : EntityBase<GameCategory>
    {
        #region Properties

        public override object Id
        {

            get { return GameCategoryID; }
            set { GameCategoryID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int GameCategoryID { get; set; }
		public string GameCategoryName { get; set; }
		public bool? Show { get; set; }

        #endregion

        public GameCategory()
        {

        }

        public GameCategory(object id)
        {
			if (id != null)
            {
				GameCategory entity = Single(id);
				if (entity != null)
					entity.CopyTo<GameCategory>(this);
				else
					this.GameCategoryID = 0;
			}
        }


    }
}