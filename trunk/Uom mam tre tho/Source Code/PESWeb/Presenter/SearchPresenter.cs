using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using Pes.Core;
using PESWeb.Interface;

namespace PESWeb.Presenter
{
    public class SearchPresenter
    {
        private ISearch _view;
        private IRedirector _redirector;

        public void Init(ISearch view)
        {
            _view = view;
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void PerformSearch(string SearchText)
        {
            _view.LoadAccounts(Account.SearchAccounts(SearchText));
        }
    }
}
