using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Files")]
    public partial class File : EntityBase<File>
    {
        #region Properties

		
        public override object Id
        {

            get { return FileID; }
            set { FileID = (long)value; }
        }

		[SubSonicPrimaryKey]
		public long FileID { get; set; }
		public Guid FileSystemName { get; set; }
		public int FileSystemFolderID { get; set; }
		public string FileName { get; set; }
		public int FileTypeID { get; set; }
		public DateTime CreateDate { get; set; }
		public int AccountID { get; set; }
		public bool IsPublicResource { get; set; }
		public long DefaultFolderID { get; set; }
		public string Description { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public long Size { get; set; }

        #endregion

        public File()
        {

        }

        public File(object id)
        {
			if (id != null)
            {
				File entity = Single(id);
				if (entity != null)
					entity.CopyTo<File>(this);
				else
					this.FileID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FileID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}