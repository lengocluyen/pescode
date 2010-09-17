using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GameCategory
    {

       private static IQueryable<GameCategory> GetAllGameCategoryByName(string GameCategoryName)
        {
            return (from cate in All()
                    where cate.GameCategoryName.ToUpper().Contains(GameCategoryName.ToUpper())
                    select cate);
        }

        public static List<GameCategory> GetAllGameCategories()
        {
            return All().ToList();
        }

        public static GameCategory GetGameCategoryByID(int id)
        {
            GameCategory gameCategory = (from g in All()
                                         where g.GameCategoryID == id
                                         select g).SingleOrDefault();
            return gameCategory;
        }

        public static bool InsertGameCategory(GameCategory gameCategory)
        {
            try
            {
                Add(gameCategory);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteGameCategory(GameCategory gameCategory)
        {
            try
            {
                Delete(gameCategory.GameCategoryID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateGameCategory(GameCategory gc)
        {
            try
            {
                Update(gc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<GameCategory> Get(IQueryable<GameCategory> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<GameCategory> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }

        public static List<GameCategory> SearchByName(string cateName, int start, int end)
        {
            return Get(GetAllGameCategoryByName(cateName), start, end);
        }

        public static List<GameCategory> GetGameCategoryForHomePage()
        {
            return All().Where(cat => cat.Show== true).ToList();
        }

        public static int CountAllGameCategory()
        {
            return All().Count();
        }

        public static int CountAllCategoryByName(string catename)
        {
            return GetAllGameCategoryByName(catename).Count();
        }
    }
}