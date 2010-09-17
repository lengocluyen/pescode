using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class BoardCategory
    {
        public static BoardCategory GetCategoryByCategoryID(Int32 CategoryID)
        {
            BoardCategory result;
                BoardCategory bc = All().Where(c => c.CategoryID == CategoryID).FirstOrDefault();
                result = bc;
            return result;
        }

        public static BoardCategory GetCategoryByPageName(string PageName)
        {
            BoardCategory category;
                category = All().Where(bc => bc.PageName == PageName).FirstOrDefault();
            return category;
        }

        //CHAPTER 10
        public static List<BoardCategory> GetAllCategories()
        {
            List<BoardCategory> result;
                IEnumerable<BoardCategory> categories = All().Where(c => c.CategoryID != 4); //don't get the groups category
                result = categories.ToList();
            return result;
        }

        public static Int32 SaveCategory(BoardCategory category)
        {
                if (category.CategoryID > 0)
                {
                    Update(category);
                }
                else
                {
                    Add(category);
                }
            return category.CategoryID;
        }

        public static void DeleteCategory(BoardCategory category)
        {
            Delete(category.Id);
        }
    }
}