using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Parts")]
    public partial class Part : EntityBase<Part>
    {
        #region Properties

        public override object Id
        {

            get { return PartID; }
            set { PartID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PartID { get; set; }
		public int? SubjectID { get; set; }
        public string PartNum { get; set; }
		public string PartName { get; set; }
        public string PartImg { get; set; }
		public int? TestID { get; set; }

        #endregion

        public Part()
        {

        }

        public Part(object id)
        {
			if (id != null)
            {
				Part entity = Single(id);
				if (entity != null)
					entity.CopyTo<Part>(this);
				else
					this.PartID = 0;
			}
        }


    }
}