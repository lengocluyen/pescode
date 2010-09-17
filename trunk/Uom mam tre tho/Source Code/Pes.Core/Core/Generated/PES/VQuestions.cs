using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VQuestions")]
    public partial class VQuestions:EntityBase<VQuestions>
    {
        #region Properties

        public override object Id
        {

            get { return QuestionID; }
            set { QuestionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int QuestionID { get; set; }
        public float Mark{get;set;}
        public string SoundFile{get;set;}
        public string QuestionContent{get;set;}
        public string AuthorID{get;set;}
        public int LevelID{get;set;}
        #endregion

        public VQuestions()
        {

        }

        public VQuestions(object id)
        {
			if (id != null)
            {
                VQuestions entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VQuestions>(this);
				else
					this.QuestionID = 0;
			}
        }

    }
}
