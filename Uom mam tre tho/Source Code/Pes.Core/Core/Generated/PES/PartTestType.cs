using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("PartTestType")]
    public partial class PartTestType:EntityBase<PartTestType>
    {
        #region Properties

        public override object Id
        {

            get { return PartTestTypeID; }
            set { PartTestTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PartTestTypeID { get; set; }
		public int PartID { get; set; }
		public int TestID { get; set; }
		public int Level { get; set; }

        #endregion

        public PartTestType()
        {

        }

        public PartTestType(object id)
        {
            if (id != null)
            {
                PartTestType entity = Single(id);
                if (entity != null)
                    entity.CopyTo<PartTestType>(this);
                else
                    this.PartTestTypeID = 0;
            }
        }
    }
}
