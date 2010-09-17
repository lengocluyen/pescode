using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("BookType")]
    public partial class BookType : EntityBase<BookType>
    {
        #region Properties

        public override object Id
        {

            get { return BookTypeID; }
            set { BookTypeID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int BookTypeID { get; set; }
		public string BookTypeName { get; set; }
        public string BookTypeImg { get; set; }
        public string BookTypeSound { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }

        #endregion

        public BookType()
        {

        }

        public BookType(object id)
        {
			if (id != null)
            {
				BookType entity = Single(id);
				if (entity != null)
					entity.CopyTo<BookType>(this);
				else
					this.BookTypeID = 0;
			}
        }


    }
}