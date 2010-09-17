using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Lesson")]
    public partial class Lesson : EntityBase<Lesson>
    {
        #region Properties

        public override object Id
        {

            get { return LessonID; }
            set { LessonID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LessonID { get; set; }
		public int? PartID { get; set; }
		public string LessonName { get; set; }
		public string Sound { get; set; }
        public string LessonImg { get; set; }
		public string LessonContent { get; set; }
		public int? TestID { get; set; }

        #endregion

        public Lesson()
        {

        }

        public Lesson(object id)
        {
			if (id != null)
            {
				Lesson entity = Single(id);
				if (entity != null)
					entity.CopyTo<Lesson>(this);
				else
					this.LessonID = 0;
			}
        }


    }
}