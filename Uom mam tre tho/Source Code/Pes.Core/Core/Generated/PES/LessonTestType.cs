using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("LessonTestType")]
    public partial class LessonTestType:EntityBase<LessonTestType>
    {
         #region Properties

        public override object Id
        {

            get { return LessonTestTypeID; }
            set { LessonTestTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LessonTestTypeID { get; set; }
		public int LessonID { get; set; }
		public int TestID { get; set; }
		public int Level { get; set; }

        #endregion

        public LessonTestType()
        {

        }

        public LessonTestType(object id)
        {
            if (id != null)
            {
                LessonTestType entity = Single(id);
                if (entity != null)
                    entity.CopyTo<LessonTestType>(this);
                else
                    this.LessonTestTypeID = 0;
            }
        }
    }
}
