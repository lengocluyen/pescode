using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Book
    {
        public static Book BookGetByBookID(int bookId)
        {
            return Book.Find(b => b.BookID == bookId).FirstOrDefault();
        }
        /// <summary>
        /// Book's  type get all!
        /// </summary>
        /// <returns>List BooKType</returns>
        public static List<BookType> BookTypeGetAll()
        {
            return BookType.All().ToList();
        }

        /// <summary>
        /// List's book get by book's type
        /// </summary>
        /// <param name="id">BookTypeID</param>
        /// <returns>List Book</returns>
        public static List<Book> BookGetByBookType(int typeId)
        {
            return Book.Find(b => b.BookTypeID == typeId).ToList();
        }

        /// <summary>
        /// Book top All
        /// </summary>
        /// <param name="num">get top num</param>
        /// <returns>list Book</returns>
        public static List<Book> BookTop(int num)
        {
            return Book.GetTop(num, "ReadNum").ToList();
        }

        /// <summary>
        /// Book's top in book type
        /// </summary>
        /// <param name="num">get top num</param>
        /// <param name="typeID">type ID</param>
        /// <returns>List book</returns>
        public static List<Book> BookTopInBookType(int num, int typeID)
        {
            return Book.GetTop(num, "ReadNum", "ReadNum == " + typeID).ToList();
        }

            
    }
}