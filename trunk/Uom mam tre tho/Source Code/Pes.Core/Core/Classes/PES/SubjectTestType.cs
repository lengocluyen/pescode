using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public partial class SubjectTestType
    {
        public static List<SubjectTestType> GetSubjectTestTypebySubjectID(int subjectID)
        {
            return SubjectTestType.Find(p => p.SubjectID == subjectID);
        }
        public static void DeleteSubjectTestType(int idPartTestType)
        {
            Delete(idPartTestType);
        }
        public static void UpdateSubjectTestType(SubjectTestType slt)
        {
            Update(slt);
        }
        public static void InsertSubjectTestType(SubjectTestType slt)
        {
            Add(slt);
        }
    }
}
