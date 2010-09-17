using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Profiles.Interface
{
    public interface IStatusUpdates
    {
        void ShowUpdates(List<StatusUpdate> StatusUpdates);
    }
}
