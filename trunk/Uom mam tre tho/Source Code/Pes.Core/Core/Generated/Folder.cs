using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Folders")]
    public partial class Folder : EntityBase<Folder>
    {
        #region Properties

		
        public override object Id
        {

            get { return FolderID; }
            set { FolderID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long FolderID { get; set; }
		public string Name { get; set; }
		public bool IsPublicResource { get; set; }
		public DateTime CreateDate { get; set; }
		public int AccountID { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int? FolderTypeID { get; set; }

        #endregion

        public Folder()
        {

        }

        public Folder(object id)
        {
			if (id != null)
            {
				Folder entity = Single(id);
				if (entity != null)
					entity.CopyTo<Folder>(this);
				else
					this.FolderID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FolderID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}