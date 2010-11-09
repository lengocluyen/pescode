using System;
using System.Linq;
using SubSonic.Extensions;
using System.Collections.Generic;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    public enum CloudSortOrder
    {
        Ascending,
        Descending,
        Random
    }
    public partial class Tag
    {

        public static Tag GetTagByName(string name)
        {
            return Tag.Find(t => t.Name == name).FirstOrDefault();
        }
        public static Tag GetTagByID(int TagID)
        {
            return Tag.Single(t => t.TagID == TagID);
        }

        public static List<Tag> GetTagsBySystemObjectAndRecordID(int SystemObjectID, long SystemObjectRecordID)
        {
            List<Tag> results = null;
            results = (from t in All()
                       join sot in SystemObjectTag.All() on t.TagID equals sot.TagID
                       where sot.SystemObjectID == SystemObjectID && sot.SystemObjectRecordID == SystemObjectRecordID
                       select t).Distinct().OrderBy(t => t.CreateDate).ToList();
            return results;
        }

        public static List<Tag> GetTagsBySystemObject(int SystemObjectID, int TagsToTake)
        {
            List<Tag> results = null;
            results = (from t in All()
                       join sot in SystemObjectTag.All() on t.TagID equals sot.TagID
                       where sot.SystemObjectID == SystemObjectID
                       select t).Distinct().OrderByDescending(t => t.Count).Take(TagsToTake).ToList();
            return results;
        }

        public static List<Tag> GetTagsGlobal(int TagsToTake)
        {
            List<Tag> results = null;
                results = (from t in Tag.All()
                           select t).Distinct().OrderByDescending(t => t.Count).Take(TagsToTake).ToList();
            return results;
        }

    }

}