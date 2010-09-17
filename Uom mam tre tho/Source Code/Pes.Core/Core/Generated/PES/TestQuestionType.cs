using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("TestQuestionType")]
    public partial class TestQuestionType : EntityBase<TestQuestionType>
    {
        #region Properties

        public override object Id
        {

            get { return TestTypeID; }
            set { TestTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TestTypeID { get; set; }
		public int? TestQuestionID { get; set; }
		public string TestTypeName { get; set; }

        #endregion

        public TestQuestionType()
        {

        }

        public TestQuestionType(object id)
        {
			if (id != null)
            {
				TestQuestionType entity = Single(id);
				if (entity != null)
					entity.CopyTo<TestQuestionType>(this);
				else
					this.TestTypeID = 0;
			}
        }


    }
}