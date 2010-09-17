using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Friend
    {
        public static Friend GetFriendByID(Int32 FriendID)
        {
            return Friend.Single(FriendID);
        }

        public static List<Friend> GetFriendsByAccountID(Int32 AccountID)
        {
            //List<Friend> aFriend = All().ToList();

            List<Friend> result = new List<Friend>();

            //Get my friends direct relationship
            var friends = (from f in Friend.All()
                           where f.AccountID == AccountID &&
                           f.MyFriendsAccountID != AccountID
                           select f).Distinct();
            result = friends.ToList();

            //Getmy friends indirect relationship
            var friends2 = (from f in Friend.All()
                            where f.MyFriendsAccountID == AccountID &&
                            f.AccountID != AccountID 
                            select f).Distinct();

            foreach (var o in friends2)
            {
                Friend friend = new Friend()
                {
                    FriendID = o.FriendID,
                    AccountID = o.MyFriendsAccountID,
                    CreateDate = o.CreateDate,
                    MyFriendsAccountID = o.AccountID,
                    Timestamp = o.Timestamp
                };
                result.Add(friend);
            }
            return result;
        }
        public static List<Account> GetFriendsAccountsByAccountID(Int32 AccountID)
        {
            List<Account> aAccount = Account.All().ToList();

            List<Friend> friends = GetFriendsByAccountID(AccountID);
            List<int> accountIDs = new List<int>();
            foreach (Friend friend in friends)
            {
                accountIDs.Add(friend.MyFriendsAccountID);
            }

            IEnumerable<Account> accounts = from a in aAccount
                                            where accountIDs.Contains(a.AccountID)
                                            select a;
            return accounts.ToList();
        }
        public static List<Account> GetFriendsAccountsByAccountID(Int32 AccountID, int currentPage, int pageSize)
        {
            List<Account> aAccount = Account.All().ToList();

            List<Friend> friends = GetFriendsByAccountID(AccountID);
            List<int> accountIDs = new List<int>();
            foreach (Friend friend in friends)
            {
                accountIDs.Add(friend.MyFriendsAccountID);
            }

            IEnumerable<Account> accounts = from a in aAccount
                                            where accountIDs.Contains(a.AccountID)
                                            select a;
            
            return accounts.Skip(currentPage*pageSize).Take(pageSize).ToList();
        }
        public static void DeleteFriend(Friend friend)
        {
            Friend.Delete(friend.AccountID);
        }

        public static void DeleteFriendByID(Int32 AccountIDToRemoveFriendFrom, Int32 FriendIDToRemove)
        {
            Friend.DeleteMany(f =>
                (
                    f.AccountID == AccountIDToRemoveFriendFrom && f.MyFriendsAccountID == FriendIDToRemove)
                    || (f.AccountID == FriendIDToRemove && f.MyFriendsAccountID == AccountIDToRemoveFriendFrom
                ));
        }

        public static void SaveFriend(Friend friend)
        {
            if (friend.FriendID > 0)
            {
                Friend.Update(friend);
            }
            else
            {
                friend.CreateDate = DateTime.Now;
                Friend.Add(friend);
            }
        }
    }
}