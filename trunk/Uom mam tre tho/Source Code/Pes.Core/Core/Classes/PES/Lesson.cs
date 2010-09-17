using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Lesson
    {
        /// <summary>
        /// Get lesson with part
        /// </summary>
        /// <param name="partID">PartID</param>
        /// <returns>List Lesson</returns>
        public static List<Lesson> LessonGetAllWithPart(int partID)
        {
            try
            {
                return Lesson.Find(l => l.PartID == partID);
            }
            catch
            {
                return null;
            }
        }

    }
}