using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Profiles.Interface;
using PESWeb.Profiles.Presenter;

namespace PESWeb.Profiles
{
    public partial class ManagePrivacy : System.Web.UI.Page, IManagePrivacy
    {
        private ManagePrivacyPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ManagePrivacyPresenter();
            _presenter.Init(this);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnSave.Click += new EventHandler(btnSave_Click);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            foreach (var type in _presenter.GetPrivacyFlagType())
            {
                DropDownList ddl = phPrivacyFlagTypes.FindControl("ddlVisibility" + type.PrivacyFlagTypeID) as DropDownList;
                if (ddl != null)
                    _presenter.SavePrivacyFlag(type.PrivacyFlagTypeID, Convert.ToInt32(ddl.SelectedValue));
            }
            lblMessage.Text = "Lưu thành công!";
        }

        #region IManagePrivacy Members

        public void ShowPrivacyTypes(List<Pes.Core.PrivacyFlagType> PrivacyFlagTypes, List<Pes.Core.VisibilityLevel> VisibilityLevels, List<Pes.Core.PrivacyFlag> PrivacyFlags)
        {
            foreach (var type in PrivacyFlagTypes)
            {
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("<div class='divContainerRow'>"));

                phPrivacyFlagTypes.Controls.Add(new LiteralControl("<div class='divContainerCellHeader'>"));
                phPrivacyFlagTypes.Controls.Add(new LiteralControl(type.FieldName));
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("</div>"));

                phPrivacyFlagTypes.Controls.Add(new LiteralControl("<div class='divContainerCell\'>"));
                DropDownList ddlVisibility = new DropDownList();
                ddlVisibility.ID = "ddlVisibility" + type.PrivacyFlagTypeID;
                foreach (var level in VisibilityLevels)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                        li.Selected = _presenter.IsFlagSelected(type.PrivacyFlagTypeID, level.VisibilityLevelID, PrivacyFlags);
                    ddlVisibility.Items.Add(li);
                }
                phPrivacyFlagTypes.Controls.Add(ddlVisibility);
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("</div>"));
                phPrivacyFlagTypes.Controls.Add(new LiteralControl("</div>"));
            }
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text += Message;
        }

        #endregion
    }
}
