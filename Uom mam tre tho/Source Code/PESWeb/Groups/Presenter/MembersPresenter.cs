using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StructureMap;
using Pes.Core;

namespace PESWeb.Groups
{
    public class MembersPresenter
    {
        private IMembers _view;
        private IGroupService _groupService;
        private IWebContext _webContext;
        private IRedirector _redirector;
        public MembersPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _groupService = ObjectFactory.GetInstance<IGroupService>();
        }

        public void Init(IMembers view, bool IsPostBack)
        {
            _view = view;

            //do we show the buttons?
            if(_webContext.CurrentUser == null)
                _view.SetButtonsVisibility(false);
            else if (_groupService.IsOwnerOrAdministrator(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                _view.SetButtonsVisibility(true);
            else
                _view.SetButtonsVisibility(false);

            if(!IsPostBack)
                LoadData();
        }

        public void Next()
        {
            _redirector.GoToGroupsMembers(_webContext.GroupID,(_webContext.PageNumber + 1));
        }

        public void Previous()
        {
            _redirector.GoToGroupsMembers(_webContext.GroupID,(_webContext.PageNumber - 1));
        }

        public void LoadData()
        {
            Account._configuration = ObjectFactory.GetInstance<IConfiguration>();
            
            _view.LoadData(Account.GetApprovedAccountsByGroupID(_webContext.GroupID, _webContext.PageNumber),
                           Account.GetAccountsToApproveByGroupID(_webContext.GroupID));
        }

        public void ApproveMembers(List<int> MemberIDs)
        {
            GroupMember.ApproveGroupMembers(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Members approved!");
        }

        public void DeleteMembers(List<int> MemberIDs)
        {
            GroupMember.DeleteGroupMembers(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Members deleted!");
        }

        public void PromoteMembers(List<int> MemberIDs)
        {
            GroupMember.PromoteGroupMembersToAdmin(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Members promoted!");
        }

        public void DemoteMembers(List<int> MemberIDs)
        {
            GroupMember.DemoteGroupMembersFromAdmin(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Members demoted!");
        }

        public void Back()
        {
            _redirector.GoToGroupsViewGroup(_webContext.GroupID);
        }
    }
}
