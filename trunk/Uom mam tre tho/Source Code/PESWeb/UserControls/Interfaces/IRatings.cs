using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.UserControls
{
    public interface IRatings
    {
        int SystemObjectID { get; set; }
        long SystemObjectRecordID { get; set; }
        void LoadOptions(List<SystemObjectRatingOption> Options);
        void SetCurrentRating(int CurrentRating);
    }
}
