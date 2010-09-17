using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FileSystemFolders")]
    public partial class FileSystemFolder : EntityBase<FileSystemFolder>
    {
        #region Properties

		
        public override object Id
        {

            get { return FileSystemFolderID; }
            set { FileSystemFolderID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FileSystemFolderID { get; set; }
		public string Path { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public FileSystemFolder()
        {

        }

        public FileSystemFolder(object id)
        {
			if (id != null)
            {
				FileSystemFolder entity = Single(id);
				if (entity != null)
					entity.CopyTo<FileSystemFolder>(this);
				else
					this.FileSystemFolderID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FileSystemFolderID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}