using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VLessionGroup
    {
       
        public static List<VLessionGroup> GetListLessionGroups()
        {
            return All().ToList();
        }


        public static VLessionGroup GetLessionGroupByID(int id)
        {
            try
            {
                return VLessionGroup.Single(id);
            }
            catch
            {
                return null;
            }
        }

        public static VLessionGroup GetLessionGroupByName(string name)
        {
            try
            {
                VLessionGroup lgBO = (from lg in All()
                                     where lg.LessionGroupName == name
                                     select lg).Single();

                return lgBO;
            }
            catch
            {
                return null;
            }
        }

        public static VLessionGroup GetLessionGroupByView(int view)
        {
            try
            {
                VLessionGroup lgBO = (from lg in All()
                                     where lg.LessionGroupView == view
                                     select lg).Single();

                return lgBO;
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckLessionGroupByName(string name)
        {
            foreach (VLessionGroup lesGroup in All().ToList())
                if (lesGroup.LessionGroupName.CompareTo(name) == 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Lấy tất cả các LessionGroup có trạng thái View=1
        /// </summary>
        /// <returns>List</returns>
        //public static List<LessionGroup> GetAllLessionGroupView()
        //{
        //    try
        //    {
        //        List<LessionGroup> lesView = (from les in GetLessionGroups()
        //                                        where les.LessionGroupView == 1
        //                                        select les).ToList<LessionGroup>();
        //        return lesView;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public static List<VLessionGroup> GetAllLessionGroupByPriority()
        {
            try
            {
                List<VLessionGroup> lesView = (from les in All()
                                              where les.LessionGroupPriority >= 1
                                              orderby les.LessionGroupPriority
                                              select les).ToList();
                return lesView;
            }
            catch
            {
                return null;
            }
        }

        //public static bool CheckFullLessionGroupView()
        //{
        //    List<LessionGroup> list = GetAllLessionGroupView();
        //    if (list.Count >= 6)
        //        return true;
        //    return false;
        //}

        public static void InsertLessionGroup(VLessionGroup lessionGrBO)
        {
            Add(lessionGrBO);
        }

        public static void DeleteLessionGroup(VLessionGroup moBO)
        {
            Delete(moBO);
        }

        public static void UpdateLessionGroup(VLessionGroup moBo)
        {
            Update(moBo);
        }


        public static List<VLessionGroup> GetItemsFromTo(IQueryable<VLessionGroup> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<VLessionGroup> listGet = table.Skip(start - 1).Take(end - start + 1).ToList();

            return listGet;
        }


        public static List<VLessionGroup> GetListLessionGroupFromTo(int start, int end)
        {
            return GetItemsFromTo(All(), start, end);
        }

        public static int CountAllLessionGroup()
        {
            return All().Count();
        }


        public static string ToStringView(object view)
        {
            int temp = CoreSupport.ConvertToInt(view, 0);
            if (temp == 0)
                return "Không";
            return "Có";
        }
    }
}