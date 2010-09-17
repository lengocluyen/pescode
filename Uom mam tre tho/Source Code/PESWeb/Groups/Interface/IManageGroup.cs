using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;
namespace PESWeb.Groups
{
    public interface IManageGroup
    {
        void LoadGroup(Group group, List<GroupType> selectedTypes);
        void ShowMessage(string Message);
        void LoadGroupTypes(List<GroupType> types);
    }
}
