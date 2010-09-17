using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Answers")]
    public partial class Answer : EntityBase<Answer>
    {
        #region Properties

        public override object Id
        {

            get { return AnswersID; }
            set { AnswersID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int AnswersID { get; set; }
		public string AnswersContent { get; set; }
		public string Sound { get; set; }
		public int? TestQuestionID { get; set; }

        #endregion

        public Answer()
        {

        }

        public Answer(object id)
        {
			if (id != null)
            {
				Answer entity = Single(id);
				if (entity != null)
					entity.CopyTo<Answer>(this);
				else
					this.AnswersID = 0;
			}
        }


    }
}