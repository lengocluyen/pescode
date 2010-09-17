using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("SubjectTestType")]
    public partial class SubjectTestType:EntityBase<SubjectTestType>
    {
        #region Properties

        public override object Id
        {

            get { return SubjectTestTypeID; }
            set { SubjectTestTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int SubjectTestTypeID { get; set; }
		public int SubjectID { get; set; }
		public int TestID { get; set; }
		public int Level { get; set; }

        #endregion

        public SubjectTestType()
        {

        }

        public SubjectTestType(object id)
        {
            if (id != null)
            {
                SubjectTestType entity = Single(id);
                if (entity != null)
                    entity.CopyTo<SubjectTestType>(this);
                else
                    this.SubjectTestTypeID = 0;
            }
        }
    }
}
