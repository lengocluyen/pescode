using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Books")]
    public partial class Book : EntityBase<Book>
    {
        #region Properties

        public override object Id
        {

            get { return BookID; }
            set { BookID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int BookID { get; set; }
		public string BookName { get; set; }
		public string Author { get; set; }
        public string BookSound { get; set; }
        public string BookImg { get; set; }
        public string ReadNum { get; set; }
		public int? BookTypeID { get; set; }
		public string PublishYear { get; set; }
		public string Language { get; set; }
		public string Description { get; set; }
		public string Source { get; set; }
		public string Link { get; set; }
		public string AccoundID { get; set; }

        #endregion

        public Book()
        {

        }

        public Book(object id)
        {
			if (id != null)
            {
				Book entity = Single(id);
				if (entity != null)
					entity.CopyTo<Book>(this);
				else
					this.BookID = 0;
			}
        }


    }
}