using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("GameAnnoucements")]
    public partial class GameAnnoucement : EntityBase<GameAnnoucement>
    {
        #region Properties

        public override object Id
        {

            get { return GameAnnoucementID; }
            set { GameAnnoucementID = (int)value; }
        }

		[SubSonicPrimaryKey]
        public int GameAnnoucementID { get; set; }
		public int? AccountID { get; set; }
		public string GameTitle { get; set; }
		public string GameImg { get; set; }
		public string AnnoucementContent { get; set; }
		public DateTime? DateAdded { get; set; }

        #endregion

        public GameAnnoucement()
        {

        }

        public GameAnnoucement(object id)
        {
			if (id != null)
            {
				GameAnnoucement entity = Single(id);
				if (entity != null)
					entity.CopyTo<GameAnnoucement>(this);
				else
                    this.GameAnnoucementID = 0;
			}
        }


    }
}