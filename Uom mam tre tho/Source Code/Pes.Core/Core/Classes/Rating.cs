using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Rating
    {
        public static bool HasRatedBefore(int SystemObjectID, long SystemObjectRecordID, int AccountID)
        {

            bool result = false;
            if (All().Where(r => r.SystemObjectID == SystemObjectID &&
                r.SystemObjectRecordID == SystemObjectRecordID &&
                r.CreatedByAccountID == AccountID).Count() > 0)
                result = true;
            return result;
        }

        public static int GetCurrentRating(int SystemObjectID, long SystemObjectRecordID)
        {
            double result;
            if (All().Where(r => r.SystemObjectID == SystemObjectID && r.SystemObjectRecordID == SystemObjectRecordID).Count() > 0)
                result =
                    Rating.All().Where(
                        r => r.SystemObjectID == SystemObjectID && r.SystemObjectRecordID == SystemObjectRecordID).
                        Select(r => r.Score).Average();
            else
                result = 0;
            return Convert.ToInt32(result);
        }

        public static void SaveRatings(List<Rating> ratings)
        {
            //get a list of items that have been rated before
            List<long> previouslyRatedSystemObjectRecordIDs = Rating.All().Where(r => r.CreatedByAccountID == ratings[0].CreatedByAccountID).Select(r => r.SystemObjectRecordID).ToList();
            foreach (Rating rating in ratings)
            {
                //be sure that this user has not already rated this particular system object before
                if (!previouslyRatedSystemObjectRecordIDs.Contains(rating.SystemObjectRecordID))
                    Rating.Add(rating);
            }
        }
    }
}
