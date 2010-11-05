using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("T_Question")]
    public partial class T_Question : EntityBase<T_Question>
    {
        #region Properties

        public override object Id
        {

            get { return QuestionID; }
            set { QuestionID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int QuestionID { get; set; }
        public float Mark { get; set; }
        public string SoundFile { get; set; }
        public string QuestionContent { get; set; }
        public int LevelID { get; set; }
        public int AuthorID { get; set; }

        #endregion

        public T_Question()
        {

        }

        public T_Question(object id)
        {
            if (id != null)
            {
                T_Question entity = Single(id);
                if (entity != null)
                    entity.CopyTo<T_Question>(this);
                else
                    this.QuestionID = 0;
            }
        }
    }
}
