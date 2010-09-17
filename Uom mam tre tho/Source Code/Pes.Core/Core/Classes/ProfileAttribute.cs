using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class ProfileAttribute
    {
        public ProfileAttributeType ProfileAttributeType { get; set; }

        public static ProfileAttributeType GetProfileAttributeTypeByID(int profileAttributeTypeID)
        {
            return ProfileAttributeType.Single(x => x.ProfileAttributeTypeID == profileAttributeTypeID);
        }

        public static List<ProfileAttributeType> GetProfileAttributeTypes()
        {
            return ProfileAttributeType.All().OrderBy(x => x.SortOrder).ToList();
        }
        public static void AddProfileAttributes(params ProfileAttribute[] attributes)
        {
            ProfileAttribute.AddMany(attributes);
        }

        public static void SaveProfileAttribute(ProfileAttribute attribute)
        {
            if (attribute.ProfileAttributeID > 0)
                ProfileAttribute.Update(attribute);
            else
                ProfileAttribute.Add(attribute);
        }

        public static List<ProfileAttribute> GetProfileAttributesByProfileID(int ProfileID)
        {
            var query = from pa in ProfileAttribute.All()
                        join pat in ProfileAttributeType.All()
                        on pa.ProfileAttributeTypeID equals pat.ProfileAttributeTypeID
                        orderby pat.SortOrder
                        where pa.ProfileID == ProfileID
                        select pa;
            return query.ToList();
        }
    }
}