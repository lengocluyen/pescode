using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Tags
{
    public interface ITags
    {
        void LoadUI(List<SystemObjectTagWithObjects> tagWithObjects);
        void SetTitle(string TagName);
    }
}
