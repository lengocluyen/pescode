using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb
{
    public class TestsPresenter
    {
        private IUserSession _userSession;
        
        private ITests _view;

        public TestsPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
           
        }
        public void Init(ITests view)
        {
            
        }
    }
}
