using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Test")]
    public partial class Test : EntityBase<Test>
    {
        #region Properties

        public override object Id
        {

            get { return TestID; }
            set { TestID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int TestID { get; set; }
        public string TestTitle { get; set; }
        public string TestImage { get; set; }
		public string Sound { get; set; }

        #endregion

        public Test()
        {

        }

        public Test(object id)
        {
			if (id != null)
            {
				Test entity = Single(id);
				if (entity != null)
					entity.CopyTo<Test>(this);
				else
					this.TestID = 0;
			}
        }


    }
}