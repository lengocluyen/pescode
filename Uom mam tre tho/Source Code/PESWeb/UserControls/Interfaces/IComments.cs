﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.UserControls
{
    public interface IComments
    {
        int SystemObjectID { get; set; }
        long SystemObjectRecordID { get; set; }
        void ShowCommentsBox(bool Isisible);
        void LoadComments(List<Comment> comments);
        void ClearComments();

    }
}
