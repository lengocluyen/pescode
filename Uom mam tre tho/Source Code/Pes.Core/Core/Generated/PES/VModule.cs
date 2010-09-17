using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("VModule")]
    public partial class VModule:EntityBase<VModule>
    {
         #region Properties

        public override object Id
        {

            get { return ModuleId; }
            set { ModuleId = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ModuleId { get; set; }
        public string ModuleName{get;set;}
        public string ModuleImage{get;set;}
        public string LinkAudio{get;set;}
        #endregion

        public VModule()
        {

        }

        public VModule(object id)
        {
			if (id != null)
            {
                VModule entity = Single(id);
				if (entity != null)
                    entity.CopyTo<VModule>(this);
				else
					this.ModuleId = 0;
			}
        }

    }
}
