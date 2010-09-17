using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.Interface
{
    public interface IDefault
    {
        int ItemAdd { get; set; }
        int TotalItem { get; set; }
        void ShowAlerts(List<Alert> alerts);
        void ShowAlertsExtra(List<Alert> alerts);
    }
}
