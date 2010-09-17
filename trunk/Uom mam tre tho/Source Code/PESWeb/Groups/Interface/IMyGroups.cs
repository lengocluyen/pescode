using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;
namespace PESWeb.Groups
{
    public interface IMyGroups
    {
        void LoadData(List<Group> groups);
        void ShowMessage(string message);
    }
}
