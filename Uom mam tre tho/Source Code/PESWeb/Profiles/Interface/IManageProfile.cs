using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.Profiles.Interface
{
    public interface IManageProfile
    {
        void ShowMessage(string Message);
        void LoadLevelOfExperienceTypes(List<LevelOfExperienceType> types);
        void LoadProfileAttributeTypes(List<ProfileAttributeType> types);
        void LoadProfile(Profile profile);

    }
}
