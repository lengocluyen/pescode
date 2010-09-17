using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Games")]
    public partial class Game : EntityBase<Game>
    {
        #region Properties

        public override object Id
        {

            get { return GameID; }
            set { GameID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int GameID { get; set; }
		public int? GameCategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? FileID { get; set; }
        public string GameFile { get; set; }
		public string GameImg { get; set; }
		public int? ScoresPerPoint { get; set; }

        #endregion

        public Game()
        {

        }

        public Game(object id)
        {
			if (id != null)
            {
				Game entity = Single(id);
				if (entity != null)
					entity.CopyTo<Game>(this);
				else
					this.GameID = 0;
			}
        }


    }
}