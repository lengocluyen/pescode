using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;
namespace PESWeb.Groups
{
    public interface IMembers
    {
        void LoadData(List<Account> Members, List<Account> MembersToApprove);
        void ShowMessage(string Message);
        void SetButtonsVisibility(bool Visible);
    }
}
