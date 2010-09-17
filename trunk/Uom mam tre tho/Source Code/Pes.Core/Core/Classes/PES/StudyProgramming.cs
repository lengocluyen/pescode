using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class StudyProgramming
    {
        /// <summary>
        /// Get studying programming's info
        /// </summary>
        /// <returns>StudyProgramming</returns>
        public static List<StudyProgramming> StudyingProgrammingGetAll()
        {
            try
            {
                return StudyProgramming.All().ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}