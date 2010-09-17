using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Profiles.Interface
{
    public interface IProfile
    {
        void SetAvatar(Int32 AccountID);
        void DisplayInfo(Account account);
        void ShowEditAccountInfo(bool value);
        void pnlPrivacyAccountInfoVisible(bool value);
        void pnlPrivacyIMVisible(bool value);
        void pnlPrivacyTankInfoVisible(bool value);
        void LoadFriends(List<Account> Accounts);
        //void LoadStatusUpdates(List<StatusUpdate> StatusUpdates);
        void ShowAlerts(List<Alert> alerts);

    }
}
