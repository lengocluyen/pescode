using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GameResult")]
    public partial class GameResult : EntityBase<GameResult>
    {
        #region Properties

        public override object Id
        {

            get { return GameResultID; }
            set { GameResultID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int GameResultID { get; set; }
		public int? AccountID { get; set; }
		public int? GameID { get; set; }
		public int? GameScores { get; set; }
		public string GameType { get; set; }
		public string Sound { get; set; }

        #endregion

        public GameResult()
        {

        }

        public GameResult(object id)
        {
			if (id != null)
            {
				GameResult entity = Single(id);
				if (entity != null)
					entity.CopyTo<GameResult>(this);
				else
					this.GameResultID = 0;
			}
        }


    }
}