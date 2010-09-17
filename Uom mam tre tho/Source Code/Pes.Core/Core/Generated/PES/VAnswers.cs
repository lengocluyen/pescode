using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VAnswers")]
    public partial class VAnswers:EntityBase<VAnswers>
    {
         #region Properties

        public override object Id
        {

            get { return AnswerID; }
            set { AnswerID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int AnswerID { get; set; }
		public string AnswerContent { get; set; }
        public bool IsTrue{get;set;}
        public string SoundFile{get;set;}
        public int? QuestionID{get;set;}
        public bool IsText{get;set;}

        #endregion

        public VAnswers()
        {

        }

        public VAnswers(object id)
        {
			if (id != null)
            {
                VAnswers entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VAnswers>(this);
				else
					this.AnswerID = 0;
			}
        }
    }
}
