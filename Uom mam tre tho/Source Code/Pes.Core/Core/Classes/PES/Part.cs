using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Part
    {
        /// <summary>
        /// Get all Part with Subject
        /// </summary>
        /// <param name="subjectID"></param>
        /// <returns>Part list</returns>
        public static List<Part> PartGetAllWithSubject(int subjectID)
        {
            try
            {
                return Part.Find(p => p.SubjectID == subjectID);
            }
            catch
            {
                return null;
            }
        }
    }
}