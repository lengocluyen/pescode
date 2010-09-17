using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("TestQuestion")]
    public partial class TestQuestion : EntityBase<TestQuestion>
    {
        #region Properties

        public override object Id
        {

            get { return TestQuestionID; }
            set { TestQuestionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TestQuestionID { get; set; }
		public int? TestID { get; set; }
		public int? TestQuestionType { get; set; }
		public string TestContent { get; set; }
		public string Sound { get; set; }

        #endregion

        public TestQuestion()
        {

        }

        public TestQuestion(object id)
        {
			if (id != null)
            {
				TestQuestion entity = Single(id);
				if (entity != null)
					entity.CopyTo<TestQuestion>(this);
				else
					this.TestQuestionID = 0;
			}
        }


    }
}