using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    [SubSonicTableNameOverride("Pupils")]
    public partial class Pupils: EntityBase<Pupils>
    {
        #region Properties

        public override object Id
        {

            get { return PupilID; }
            set { PupilID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int PupilID { get; set; }
        public int AccountID{get;set;}
        public string NickName{get;set;}
        public string Name{get;set;}
        public string FamilyName{get;set;}
        public DateTime Birthday{get;set;}
        public int Point{get;set;}
        public string PupilAvatar{get;set;}
        public int PupilLevel { get; set; }
        public string SchoolName { get; set; }

        #endregion

        public Pupils()
        {

        }

        public Pupils(object id)
        {
			if (id != null)
            {
                Pupils entity = Single(id);
				if (entity != null)
                    entity.CopyTo<Pupils>(this);
				else
					this.PupilID = 0;
			}
        }
    }
}
