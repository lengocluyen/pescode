using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Profiles.Interface
{
    public interface IManagePrivacy
    {
        void ShowPrivacyTypes(List<PrivacyFlagType> PrivacyFlagTypes,
                                     List<VisibilityLevel> VisibilityLevels,
                                     List<PrivacyFlag> PrivacyFlags);

        void ShowMessage(string Message);
    }
}
