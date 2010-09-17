using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class LevelOfExperienceType
    {
        public static List<LevelOfExperienceType> GetAllLevelOfExperienceTypes()
        {
            return LevelOfExperienceType.All().OrderBy(x=>x.SortOrder).ToList();
        }

        public static LevelOfExperienceType GetLevelOfExperienceTypeByID(int levelOfExperienceTypeID)
        {
            return LevelOfExperienceType.Single(x => x.LevelOfExperienceTypeID == levelOfExperienceTypeID);
        }

        public static void SaveLevelOfExperienceType(LevelOfExperienceType levelOfExperienceType)
        {
            if (levelOfExperienceType.LevelOfExperienceTypeID > 0)
                LevelOfExperienceType.Update(levelOfExperienceType);
            else
                LevelOfExperienceType.Add(levelOfExperienceType);
        }
    }
}