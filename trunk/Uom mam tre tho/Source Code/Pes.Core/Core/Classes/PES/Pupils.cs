using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Pupils
    {
        public static Pupils GetPupilByID(int idAccount)
        {
            return Single(p=>p.AccountID==idAccount);
        }

        public static Pupils GetPupilByNickName(string NickName)
        {
            return Single(p=>p.NickName==NickName);
        }
        public static Pupils GetPupilByEmailAccount(string email)
        {
            return Single(p=>p.AccountID==Account.GetAccountByEmail(email).AccountID);
        }
        public static Pupils GetPupilByAccontLogin(string email, string password)
        {
            return Single(p=>p.AccountID==Account.Single(a=>a.Email==email&&a.Password==password).AccountID);
        }
        public static Pupils GetPupilByAccountID(int id)
        {
            return Single(p => p.AccountID == id);
        }
        //public static Pupils GetPupilByEmail(string email)
        //{
        //    return Single(p=>p.Email==email);
        //}

        //public static Pupils GetPupilByEmailAndPassword(string userName, string password)
        //{
        //    return Single(p=>p.UserName==userName&&p.PassWord==password);
        //}

        public static List<Pupils> GetListPupils()
        {
            return All().ToList();
        }

        public static void InsertPupil(Pupils pBO)
        {
            Add(pBO);
        }

        public static void DeletePupil(Pupils pBO)
        {
            Delete(pBO);
        }

        public static void UpdatePupil(Pupils pBO)
        {
            Update(pBO);
        }

        public static List<Pupils> Get(IQueryable<Pupils> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<Pupils> l = table.Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }
    }
}