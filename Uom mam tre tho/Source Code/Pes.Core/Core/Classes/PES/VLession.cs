using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VLession
    {
        #region IQueryable
       
        public static IQueryable<VLession> GetLessionsByAuthorID(int id)
        {
            return (from lession in All()
                    where lession.AuthorID == id
                    select lession);
        }

      
        #endregion

        #region Count
        public static int CountAllLession()
        {
            return All().Count(); ;
        }

        public static int CountAllLessionByAuthorID(int id)
        {
            return (from lession in All()
                    where lession.AuthorID == id
                    select lession).Count();
        }
        #endregion

        #region To List, Object
        public static VLession GetLessionByID(int id)
        {
            try
            {
                return VLession.Single(id);
            }
            catch { return null; }
        }

        public static IQueryable<VLession> GetLessionByGroup(int idGroup)
        {
            return (from lession in All()
                    where lession.GroupID == idGroup
                    select lession);

        }

        public static List<VLession> GetListLessionByGroup(int idGroup)
        {
            return GetLessionByGroup(idGroup).ToList();
        }

        public static List<VLession> GetListLessions()
        {
            return All().ToList();
        }

        public static List<VLession> GetAllLessionForLessionGroup(int lessionGroupID)
        {
            List<VLession> list = new List<VLession>();
            list = (from lession in All()
                    where lession.GroupID == lessionGroupID
                    select lession).ToList();

            return list;
        }

        #endregion


        #region Actions
        public static void InsertLession(VLession Lession)
        {
            VLession.Add(Lession);
        }

        public static void DeleteLession(VLession moBO)
        {
            VLession.Delete(moBO.LessionID);
        }

        public static void UpdateLession(VLession moBO)
        {
            VLession.Update(moBO);
        }

        public static void UpdateLession(int lessionID, string lessionName, int authorID, int groupID, string lessionImage)
        {
            VLession lBO = GetLessionByID(lessionID);
            lBO.LessionName = lessionName;
            VLession.Update(lBO);
        }

        #endregion

        /// <summary>
        /// Get items from Start to End.
        /// </summary>
        /// <param name="table">IQueryable table</param>
        /// <param name="start">Get from</param>
        /// <param name="end">Get to</param>
        /// <returns></returns>
        public static List<VLession> GetItemsFromTo(IQueryable<VLession> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VLession> listGet = table.Skip(start - 1).Take(end - start + 1).ToList<VLession>();

            return listGet;
        }

        public static List<VLession> GetListLessionFromTo(int start, int end)
        {
            return GetItemsFromTo(All(), start, end);
        }

        public static List<VLession> GetListLessionByAuthorIDFromTo(int authorID, int start, int end)
        {
            return GetItemsFromTo(GetLessionsByAuthorID(authorID), start, end);
        }


        // Search
        protected static IQueryable<VLession> GetIQueryableLessionBySearch(int currMemberID, VLession lession, string authorName)
        {

            IQueryable<VLession> table;
            IQueryable<VLession> fromTable;

            if (currMemberID < 0) //unlimit
                fromTable = All();
            else
                fromTable = GetLessionsByAuthorID(currMemberID);

            if (lession.LessionPriority > 0 && lession.GroupID > 0)
                table = (from l in fromTable
                         where l.LessionName.ToUpper().Contains(lession.LessionName.ToUpper()) == true && l.GroupID == lession.GroupID
                         && l.LessionPriority == lession.LessionPriority
                         select l);
            else if (lession.LessionPriority < 0 && lession.GroupID > 0)
                table = (from l in fromTable
                         where l.LessionName.ToUpper().Contains(lession.LessionName.ToUpper()) == true && l.GroupID == lession.GroupID
                         select l);
            else if (lession.LessionPriority > 0 && lession.GroupID < 0)
                table = (from l in fromTable
                         where l.LessionName.ToUpper().Contains(lession.LessionName.ToUpper()) == true
                         && l.LessionPriority == lession.LessionPriority
                         select l);
            else
                table = (from l in fromTable
                         where l.LessionName.ToUpper().Contains(lession.LessionName.ToUpper()) == true
                         select l);


            return table;
        }


        protected static bool CheckLessionPriority(int priorityInDB, int priorityToCompare)
        {
            if (priorityToCompare < 0)
                return true;
            if (priorityInDB == priorityToCompare)
                return true;
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="currMemberID">Less than 0: unlimit, More than 0: Limit by this memberID</param>
        /// <param name="lession"></param>
        /// <param name="authorName"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int CountSearchResult(int currMemberID, VLession lession, string authorName)
        {
            return GetIQueryableLessionBySearch(currMemberID, lession, authorName).Count();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="currMemberID">Less than 0: unlimit, More than 0: Limit by this memberID</param>
        /// <param name="lession"></param>
        /// <param name="authorName"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<VLession> GetLessionBySearch(int currMemberID, VLession lession, string authorName, int start, int end)
        {
            return GetItemsFromTo(GetIQueryableLessionBySearch(currMemberID, lession, authorName), start, end);
        }
    }
}