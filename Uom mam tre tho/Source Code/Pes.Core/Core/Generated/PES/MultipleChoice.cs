using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("MultipleChoice")]
    public partial class MultipleChoice : EntityBase<MultipleChoice>
    {
        #region Properties

        public override object Id
        {

            get { return MultipleChoiceID; }
            set { MultipleChoiceID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int MultipleChoiceID { get; set; }
		public string MultipleChoiceContent { get; set; }
		public int? TestQuestionID { get; set; }
		public string Sound { get; set; }

        #endregion

        public MultipleChoice()
        {

        }

        public MultipleChoice(object id)
        {
			if (id != null)
            {
				MultipleChoice entity = Single(id);
				if (entity != null)
					entity.CopyTo<MultipleChoice>(this);
				else
					this.MultipleChoiceID = 0;
			}
        }


    }
}