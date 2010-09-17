using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.UserControls
{
    public interface ITags
    {
        void ShowTagCloud(bool Visible);
        void ShowTagBox(bool Visible);
        int SystemObjectID { get; set; }
        long SystemObjectRecordID { get; set; }
        TagState Display { get; set; }
        void AddTagsToTagCloud(TagWithState tag);
        void ClearTagCloud();
    }
}
