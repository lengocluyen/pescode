using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Subject
    {
        /// <summary>
        /// Get subject with Level ID
        /// </summary>
        /// <param name="levelID">StudyLevelID</param>
        /// <returns>List Subject</returns>
        public static List<Subject> SubjectGetAllWithLevel(int levelID)
        {
            try
            {
                return Subject.Find(s => s.StudyLevelID == levelID);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get subject with subbject name
        /// </summary>
        /// <param name="levelID">StudyLevelID</param>
        /// <returns>Subject</returns>
        public static Subject SubjectGetByName(string subjectName)
        {
            try
            {
                return Subject.Find(s => s.SubjectName == subjectName).FirstOrDefault();

            }
            catch
            {
                return null;
            }
        }
    }
}