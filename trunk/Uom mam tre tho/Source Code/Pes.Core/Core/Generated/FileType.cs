using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("FileTypes")]
    public partial class FileType : EntityBase<FileType>
    {
        #region Properties

		
        public override object Id
        {

            get { return FileTypeID; }
            set { FileTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int FileTypeID { get; set; }
		public string Name { get; set; }

        #endregion

        public FileType()
        {

        }

        public FileType(object id)
        {
			if (id != null)
            {
				FileType entity = Single(id);
				if (entity != null)
					entity.CopyTo<FileType>(this);
				else
					this.FileTypeID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (FileTypeID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}