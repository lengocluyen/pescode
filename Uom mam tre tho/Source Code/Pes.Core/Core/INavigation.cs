using System.Collections.Generic;
using System.Web;

namespace Pes.Core
{
    public interface INavigation
    {
        SiteMapNode CurrentNode { get; }
        SiteMapNode RootNode { get; }
        List<SiteMapNode> PrimaryNodes();
        List<SiteMapNode> SecondaryNodes();
        List<SiteMapNode> FooterNodes();
        void CheckAccessForCurrentNode();
        List<SiteMapNode> AllNodes();
    }
}