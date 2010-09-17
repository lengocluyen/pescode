using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class StudyLevel
    {
        /// <summary>
        /// Get Studying level with studying programming
        /// </summary>
        /// <param name="studyProgrameID">studyProgrameID</param>
        /// <returns>StudyLevel</returns>
        public static List<StudyLevel> StudyingLevelGet(int studyProgrameID)
        {
            try
            {
                List<StudyLevel> slList = (from slt in StudyLevelType.All()
                                           join sl in StudyLevel.All()
                                           on slt.StudyLevelID equals sl.StudyLevelID
                                           where slt.StudyProgrammingID == studyProgrameID
                                           select sl).ToList();
                return slList;
            }
            catch
            {
                return null;
            }
        }
    }
}