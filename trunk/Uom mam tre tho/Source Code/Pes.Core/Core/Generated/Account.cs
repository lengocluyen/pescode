using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Accounts")]
    public partial class Account : EntityBase<Account>
    {
        #region Properties

		
        public override object Id
        {

            get { return AccountID; }
            set { AccountID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int AccountID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool EmailVerified { get; set; }
		public string Zip { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? LastUpdateDate { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public int TermID { get; set; }
		public DateTime? AgreedToTermsDate { get; set; }

        #endregion

        public Account()
        {

        }

        public Account(object id)
        {
			if (id != null)
            {
				Account entity = Single(id);
				if (entity != null)
					entity.CopyTo<Account>(this);
				else
					this.AccountID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (AccountID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}