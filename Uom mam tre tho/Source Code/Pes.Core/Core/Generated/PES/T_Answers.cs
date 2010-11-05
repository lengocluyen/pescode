using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;
using SubSonic.BaseClasses;

namespace Pes.Core
{
    [SubSonicTableNameOverride("T_Answers")]
    public partial class T_Answers : EntityBase<T_Answers>
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
        public bool IsTrue { get; set; }
        public string SoundFile { get; set; }
        public int QuestionID { get; set; }
        public bool IsText { get; set; }

        #endregion

        public T_Answers()
        {

        }

        public T_Answers(object id)
        {
            if (id != null)
            {
                T_Answers entity = Single(id);
                if (entity != null)
                    entity.CopyTo<T_Answers>(this);
                else
                    this.AnswersID = 0;
            }
        }
    }
}
