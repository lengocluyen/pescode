using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GameAnnoucement
    {
         public static GameAnnoucement GetGameAnnoucementByID(int id)
        {
            GameAnnoucement pBO = (from part in All()
                                   where part.GameAnnoucementID == id
                                   select part).Single<GameAnnoucement>();
            return pBO;
        }

        public static List<GameAnnoucement> GetListGameAnnoucements()
        {
            return All().ToList();
        }

        public static bool InsertGameAnnoucement(GameAnnoucement GameAnnoucement)
        {
            try
            {
                Add(GameAnnoucement);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteGameAnnoucement(GameAnnoucement pBO)
        {
            try
            {
                Delete(pBO.GameAnnoucementID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateGameAnnoucement(GameAnnoucement pBo)
        {
            try
            {
                Update(pBo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<GameAnnoucement> GetGameAnnoucementPaging̣(int currPage, int pageSize)
        {
            //if (currPage < 1)
            //    currPage = 1;
            //currPage--;
            //int start = currPage * pageSize + 1;
            //int end = start + pageSize - 1;

            //List<GameAnnoucement> lstResult = Get(All(), start, end);
            List<GameAnnoucement> a = GetPaged(currPage-1, pageSize);
            return a;
        }

        public static List<GameAnnoucement> Get(IQueryable<GameAnnoucement> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<GameAnnoucement> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }

        public static GameAnnoucement GetOneNewAnnoucement(int start)
        {
            return All().OrderByDescending(ann => ann.DateAdded).Skip(start).Take(1).SingleOrDefault();
        }

        public static int CountGameAnnoucement()
        {
            return All().Count();
        }
    }
}