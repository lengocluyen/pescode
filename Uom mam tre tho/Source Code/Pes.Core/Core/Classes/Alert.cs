using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    public partial class Alert
    {
        [SubSonicIgnore]
        public string CreateDateString
        {
            get { return CreateDate.ToString("dd-MM-yyyy lúc HH:mm"); }
        }
        [SubSonicIgnore]
        public int More { get; set; }

        private List<Comment> _Comments;
        public List<Comment> Comments
        {
            get
            {
                if (_Comments == null)
                    _Comments = GetTopComments();
                return _Comments;
            }
            set
            {
                _Comments = value;
            }
        }

        public List<Comment> GetTopComments()
        {
            int more;
            List<Comment> list= Comment.GetTopCommentsBySystemObjectAjax((int)SystemObject.Names.Alerts, AlertID, out more);
            More = more;
            return list;
        }

        public static void SaveAlert(Alert alert)
        {
            if (alert.AlertID > 0)
            {
                Alert.Update(alert);
            }
            else
            {
                alert.CreateDate = DateTime.Now;
                Alert.Add(alert);
            }
        }

        public static List<Alert> GetAlertsByAccountID(int accountID)
        {
            var query = (from a in Alert.All()
                         where a.AccountID == accountID
                         orderby a.CreateDate descending
                         select a).Take(20);
            return query.ToList();
        }

        public static List<Alert> GetAlertsByAccountID(int accountID, int skip)
        {
            if (skip > 0)
            {
                var query = (from a in Alert.All()
                             where a.AccountID == accountID
                             orderby a.CreateDate descending
                             select a).Skip(skip).Take(20);
                return query.ToList();
            }
            return (from a in Alert.All()
                    where a.AccountID == accountID
                    orderby a.CreateDate descending
                    select a).ToList();
        }

        public static Int32 CountAlertsByAccountID(int accountID)
        {
            return (from a in Alert.All()
                    where a.AccountID == accountID
                    orderby a.CreateDate descending
                    select a).Count();
        }
        public static List<Alert> GetAlertsByAccountID(int accountID, int currentIndex, int itemNum)
        {
            var query = (from a in Alert.All()
                         where a.AccountID == accountID
                         orderby a.CreateDate descending
                         select a).Skip(currentIndex).Take(itemNum);
            return query.ToList();
        }
        public static List<Alert> GetAlertByAccountIDofMeAndFriend(int accountID)
        {
            List<Friend> listFriends = (from f in Friend.All() where f.AccountID == accountID || f.MyFriendsAccountID == accountID orderby f.CreateDate descending select f).ToList();

            var queryAlert = (from i in Alert.All()
                              orderby i.CreateDate descending
                              select i);
            List<Alert> temp = new List<Alert>();
            foreach (Alert i in queryAlert)
                if (CheckFriendByAccount(listFriends, i.AccountID) && CheckAlert(temp, i))
                    temp.Add(i);
            return temp.Take(20).ToList();


        }
        public static bool CheckFriendByAccount(List<Friend> list, int accID)
        {
            foreach (Friend i in list)
                if (i.AccountID == accID)
                    return true;
            return false;
        }
        public static bool CheckAlert(List<Alert> list, Alert i)
        {
            foreach (Alert a in list)
            {
                if (a.Message.CompareTo(i.Message) == 0)
                    return false;

            }
            return true;
        }



    }
}