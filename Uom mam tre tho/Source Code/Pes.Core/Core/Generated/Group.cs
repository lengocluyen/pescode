using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Groups")]
    public partial class Group : EntityBase<Group>
    {
        #region Properties

		
        public override object Id
        {

            get { return GroupID; }
            set { GroupID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int GroupID { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int MemberCount { get; set; }
		public string PageName { get; set; }
		public string Description { get; set; }
		public int AccountID { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public long FileID { get; set; }
		public bool IsPublic { get; set; }
		public string Body { get; set; }

        #endregion

        public Group()
        {

        }

        public Group(object id)
        {
			if (id != null)
            {
				Group entity = Single(id);
				if (entity != null)
					entity.CopyTo<Group>(this);
				else
					this.GroupID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (GroupID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}