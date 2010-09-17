using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class StudyLevelType
    {
        public static void DeleteStudyLT(int idStudyLevelType)
        {
            Delete(idStudyLevelType);
        }
        public static void UpdateStudyLT(StudyLevelType slt)
        {
            Update(slt);
        }
        public static void InsertStudyLT(StudyLevelType slt)
        {
            Add(slt);
        }
    }
}