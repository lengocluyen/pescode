using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VLession")]
    public partial class VLession:EntityBase<VLession>
    {
         #region Properties

        public override object Id
        {

            get { return LessionID; }
            set { LessionID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int LessionID { get; set; }
		public string LessionName { get; set; }
        public int? AuthorID{get;set;}
        public int? GroupID{get;set;}
        public string LessionImg{get;set;}
        public int LessionPriority{get;set;}
        
        #endregion

        public VLession()
        {

        }

        public VLession(object id)
        {
			if (id != null)
            {
                VLession entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VLession>(this);
				else
					this.LessionID = 0;
			}
        }
    }
}
