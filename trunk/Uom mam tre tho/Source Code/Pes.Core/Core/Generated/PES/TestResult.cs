using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("TestResult")]
    public partial class TestResult : EntityBase<TestResult>
    {
        #region Properties

        public override object Id
        {

            get { return TestResultID; }
            set { TestResultID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TestResultID { get; set; }
		public int? TestID { get; set; }
		public int? AccountID { get; set; }
		public int? Result { get; set; }
		public string Sound { get; set; }

        #endregion

        public TestResult()
        {

        }

        public TestResult(object id)
        {
			if (id != null)
            {
				TestResult entity = Single(id);
				if (entity != null)
					entity.CopyTo<TestResult>(this);
				else
					this.TestResultID = 0;
			}
        }


    }
}