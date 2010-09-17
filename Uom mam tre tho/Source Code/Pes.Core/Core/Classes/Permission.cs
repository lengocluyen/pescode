using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.Query;

namespace Pes.Core
{
    public class Testt
    {
        public Permission Permission { set; get; }
        public AccountPermission AccountPermission { set; get; }
        public Account Account { set; get; }

    }

    public partial class Permission
    {

        public static List<Testt> Test(int accountID)
        {
            var permissions = (from p in Permission.All()
                              join ap in AccountPermission.All()
                                on p.PermissionID equals ap.PermissionID
                              join a in Account.All()
                                  on ap.AccountID equals a.AccountID
                              where a.AccountID == accountID
                              select new
                              {
                                  p,
                                  ap,
                                  a
                              }).Take(1);

            List<Testt> list = new List<Testt>();

            foreach (var item in permissions.ToList())
            {
                Testt t = new Testt();
                t.Account = item.a;
                t.AccountPermission = item.ap;
                t.Permission = item.p;

                list.Add(t);
            }

            return list;
        }


        public static List<Permission> GetPermissionsByAccountID(int accountID)
        {
            var permissions = from p in Permission.All()
                              join ap in AccountPermission.All()
                                on p.PermissionID equals ap.PermissionID
                              join a in Account.All()
                                  on ap.AccountID equals a.AccountID
                              where a.AccountID == accountID
                              select p;
            return permissions.ToList();
        }

        public static Permission GetPermissionByName(string name)
        {
            return Permission.Single(x => x.Name == name);
        }

        public static Permission GetPermissionByID(int permissionID)
        {
            return Permission.Single(x => x.PermissionID == permissionID);
        }
    }

}