using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public partial class LessonTestType
    {
        public static List<LessonTestType> GetLessonTestTypeByLessonID(int lessonID)
        {
            return LessonTestType.Find(p=>p.LessonID==lessonID);
        }
        public static void DeleteLessonTestType(int idLessonTestType)
        {
            Delete(idLessonTestType);
        }
        public static void UpdateStudyLT(LessonTestType llt)
        {
            Update(llt);
        }
        public static void InsertStudyLT(LessonTestType llt)
        {
            Add(llt);
        }
    }
}
