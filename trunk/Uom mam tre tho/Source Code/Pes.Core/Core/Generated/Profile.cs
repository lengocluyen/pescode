using System;
using System.Collections.Generic;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
	[SubSonicTableNameOverride("Profiles")]
    public partial class Profile : EntityBase<Profile>
    {
        #region Properties

		
        public override object Id
        {

            get { return ProfileID; }
            set { ProfileID = (int)value; }
        }

		[SubSonicPrimaryKey]
		public int ProfileID { get; set; }
		public int AccountID { get; set; }
		public string ProfileName { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? LastUpdateDate { get; set; }
		public string SchoolsName { get; set; }
		public string Address { get; set; }
		public string Enjoy { get; set; }
		public int LevelOfExperienceTypeID { get; set; }
		public string IMMSN { get; set; }
		public string IMAOL { get; set; }
		public string IMGIM { get; set; }
		public string IMYIM { get; set; }
		public string IMICQ { get; set; }
		public string IMSkype { get; set; }
		public string Signature { get; set; }
		public System.Data.Linq.Binary Timestamp { get; set; }
		public byte[] Avatar { get; set; }
		public string AvatarMimeType { get; set; }
		public int UseGravatar { get; set; }
        public int GameScore { get; set; }

        #endregion

        public Profile()
        {

        }

        public Profile(object id)
        {
			if (id != null)
            {
				Profile entity = Single(id);
				if (entity != null)
					entity.CopyTo<Profile>(this);
				else
					this.ProfileID = 0;
			}
        }

        public bool Save()
        {
            bool rs = false;
            if (ProfileID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }


    }
}