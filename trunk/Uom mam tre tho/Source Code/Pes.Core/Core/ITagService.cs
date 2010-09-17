using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    [PluginFamily("Default")]
    public interface ITagService
    {
        void AddTag(string TagName, int SystemObjectID, long SystemObjectRecordID);
        List<TagWithState> CalculateFontSize(List<TagWithState> Tags);
    }
}
