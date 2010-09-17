using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class VLevels
    {
        public static List<VLevels> GetListLevels()
        {
            return All().ToList();
        }
        public static VLevels GetLevelByID(int id)
        {
            return All().Where(lv => lv.LevelID == id).SingleOrDefault();
        }
        public static void InsertLevel(VLevels lv)
        {
            try
            {
                Add(lv);
            }
            catch
            {
            }
        }
        public static void DeleteLevel(int id)
        {
            try
            {
                Delete(id);
            }
            catch
            {
            }
        }
        public static void UpdateLevel(VLevels vl)
        {
            Update(vl);
        }
    }
}