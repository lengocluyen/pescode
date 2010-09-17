using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    public partial class Account
    {
        [SubSonicIgnore]
        public static IConfiguration _configuration{get;set;}
        private List<Permission> _permissions = new List<Permission>();
        public List<Permission> Permissions
        {
            get { return _permissions; }
        }

        public bool HasPermission(string name)
        {
            return _permissions.Exists(x => x.Name == name);
        }

        public Profile Profile { get; set; }


        public void AddPermission(Permission permission)
        {
            _permissions.Add(permission);
        }

        public static Account GetAccountByUsername(string username)
        {
            return Account.Single(x => x.Username == username);
        }

        public static Account GetAccountByEmail(string email)
        {
            return Account.Single(x => x.Email == email);
        }

        public static void AddPermission(Account account, Permission permission)
        {
            AccountPermission ap = new AccountPermission();
            ap.AccountID = account.AccountID;
            ap.PermissionID = permission.PermissionID;
            ap.Save();
        }

        public static void AddPermissions(Account account, List<Permission> permissions)
        {
            List<AccountPermission> list = new List<AccountPermission>();
            foreach (var p in permissions)
            {
                AccountPermission ap = new AccountPermission();
                ap.AccountID = account.AccountID;
                ap.PermissionID = p.PermissionID;
                list.Add(ap);
            }
            AccountPermission.AddMany(list);
        }
        public static void SaveAccount(Account account)
        {
            account.LastUpdateDate = DateTime.Now;
            if (account.AccountID > 0)
            {
                Account.Update(account);
            }
            else
            {
                account.CreateDate = DateTime.Now;
                Account.Add(account);
            }

        }
        public static Account GetAccountByID(int AccountID)
        {
            return Account.Single(ac => ac.AccountID == AccountID);
        }

        public static List<Account> SearchAccounts(string SearchText)
        {
            return All().Where(a => (a.FirstName + " " + a.LastName).Contains(SearchText) ||
                            a.Email.Contains(SearchText) ||
                            a.Username.Contains(SearchText)).ToList();

        }

        public static List<Account> GetApprovedAccountsByGroupID(int GroupID, int PageNumber)
        {
            List<Account> result = null;
            IEnumerable<Account> accounts = (from a in Account.All()
                                             join m in GroupMember.All() on a.AccountID equals m.AccountID
                                             where m.GroupID == GroupID && m.IsApproved
                                             select a).ToList().Skip((_configuration.NumberOfRecordsInPage * (PageNumber - 1)))
                                             .Take(_configuration.NumberOfRecordsInPage);
            result = accounts.ToList();
            return result;
        }

        public static List<Account> GetAccountsToApproveByGroupID(int GroupID)
        {
            List<Account> result = null;
            IEnumerable<Account> accounts = (from a in Account.All()
                                             join m in GroupMember.All() on a.AccountID equals m.AccountID
                                             where m.GroupID == GroupID && !m.IsApproved
                                             select a);
            result = accounts.ToList();
            return result;
        }


    }
}