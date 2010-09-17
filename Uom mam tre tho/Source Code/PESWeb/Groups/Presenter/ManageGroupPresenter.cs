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
    public class ManageGroupPresenter
    {
        private IManageGroup _view;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IGroupService _groupService;
        private IFileService _fileService;

        public ManageGroupPresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            File._webContext = _webContext;
            _groupService = ObjectFactory.GetInstance<IGroupService>();
            _fileService = ObjectFactory.GetInstance<IFileService>();
        }

        public void Init(IManageGroup view, bool IsPostBack)
        {
            _view = view;

            //security check for group
            if (_webContext.GroupID > 0 && !_groupService.IsOwnerOrAdministrator(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                _redirector.GoToAccountAccessDenied();

            if(!IsPostBack)
                view.LoadGroupTypes(GroupType.GetAllGroupTypes());

            if (_webContext.GroupID > 0 && !IsPostBack)
                view.LoadGroup(Group.GetGroupByID(_webContext.GroupID),
                               GroupType.GetGroupTypesByGroupID(_webContext.GroupID));
        }

        public void SaveGroup(Group group, HttpPostedFile file, List<long> selectedGroupTypeIDs)
        {
            if (group.Description.Length > 2000)
            {
                _view.ShowMessage("Your description is " + group.Description.Length.ToString() +
                                  " characters long and can only be 2000 characters!");
            }
            else
            {
                group.AccountID = _webContext.CurrentUser.AccountID;
                group.PageName = group.PageName.Replace(" ", "-");
                //if this is a new group then check to see if the page name is in use
                if (group.GroupID == 0 && Group.CheckIfGroupPageNameExists(group.PageName))
                {
                    _view.ShowMessage("The page name you specified is already in use!");
                }
                else
                {
                    if (file.ContentLength > 0)
                    {
                        List<Int64> fileIDs = _fileService.UploadPhotos(1, _webContext.CurrentUser.AccountID,_webContext.Files, 1);
                        //should only be one item uploaded!
                        if (fileIDs.Count == 1)
                            group.FileID = fileIDs[0];
                    }
                    group.GroupID = _groupService.SaveGroup(group);
                    GroupToGroupType.SaveGroupTypesForGroup(selectedGroupTypeIDs,group.GroupID);
                    _redirector.GoToGroupsViewGroup(group.PageName);
                }
            }
        }

        public string GetImagePathByID(Int64 ImageID)
        {
            return _fileService.GetFullFilePathByFileID(ImageID, File.Sizes.S);
        }
    }
}
