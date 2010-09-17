using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;
namespace PESWeb.Groups
{
    public interface IViewGroup
    {
        void LoadData(Group group);
        void ShowMessage(string Message);
        void ShowPublic(bool Visible);
        void ShowPrivate(bool Visible);
        void ShowRequestMembership(bool Visible);
    }
}
