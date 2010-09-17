using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Profiles.Interface;
using PESWeb.Profiles.Presenter;
using Pes.Core;
using PESWeb.UserControls;

namespace PESWeb.Profiles
{
    public partial class ProfileInfo : System.Web.UI.Page, IProfile
    {
        private ProfilePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ProfilePresenter();
            _presenter.Init(this);
        }

        public void SetAvatar(Int32 AccountID)
        {
            if (!imgAvatar.ImageUrl.Contains("AccountID="))
                imgAvatar.ImageUrl += "?AccountID=" + AccountID.ToString();
        }

        public void pnlPrivacyTankInfoVisible(bool value)
        {
            pnlPrivacyTankInfo.Visible = value;
        }
        public void pnlPrivacyAccountInfoVisible(bool value)
        {
            pnlPrivacyAccountInfo.Visible = value;
        }
        public void pnlPrivacyIMVisible(bool value)
        {
            pnlPrivacyIM.Visible = value;
        }
        public void LoadFriends(List<Account> Accounts)
        {
            repFriends.DataSource = Accounts;
            repFriends.DataBind();
        }
        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProfileDisplay pdProfileDisplay = e.Item.FindControl("pdProfileDisplay") as ProfileDisplay;
                pdProfileDisplay.LoadDisplay(((Account)e.Item.DataItem));
            }
        }
        public void LoadStatusUpdates(List<StatusUpdate> StatusUpdates)
        {

        }

        protected void btnViewStatusUpdates_Click(object sender, EventArgs e)
        {
            _presenter.GoToStatusUpdates();
        }

        public void DisplayInfo(Account account)
        {
            litZip.Text = account.Zip;
            if (account.BirthDate.HasValue)
            {
                DateTime dt = (DateTime)account.BirthDate.Value;
                litBirthDate.Text =
                    string.Format("{0} tháng {1} năm {2}",
                    dt.Day.ToString().PadLeft(2, '0'), dt.Month.ToString().PadLeft(2, '0'), dt.Year);
            }

            if (account.Profile != null)
            {
                //litIMAOL.Text = account.Profile.IMAOL;
                litIMGIM.Text = account.Profile.IMGIM;
                //litIMICQ.Text = account.Profile.IMICQ;
                //litIMMSN.Text = account.Profile.IMMSN;
                //litIMSkype.Text = account.Profile.IMSkype;
                litIMYIM.Text = account.Profile.IMYIM;
                litNumberOfTanksOwned.Text = account.Profile.NumberOfFishOwned.ToString();
                litNumberOfTanksOwned.Text = account.Profile.NumberOfTanksOwned.ToString();
                litYearOfFirstTank.Text = account.Profile.YearOfFirstTank.ToString();
                //litLevelOfExperience.Text = "(" + account.Profile.LevelOfExperienceType.LevelOfExperience + ")";
                if (account.Profile.Attributes.Count > 0)
                {
                    foreach (ProfileAttribute attribute in account.Profile.Attributes)
                    {
                        if (_presenter.IsAttributeVisible(attribute.ProfileAttributeType.PrivacyFlagTypeID))
                        {
                            //phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerTitle\">"));
                            //phAttributes.Controls.Add(new LiteralControl(attribute.ProfileAttributeType.AttributeType));
                            //phAttributes.Controls.Add(new LiteralControl("</div>"));
                            //phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerRow\"><div class=\"divContainerCell\">"));
                            //phAttributes.Controls.Add(new LiteralControl(attribute.Response));
                            //phAttributes.Controls.Add(new LiteralControl("</div></div>"));

                            phAttributes.Controls.Add(new LiteralControl("<div class=\"box profile\"><h2>"));
                            phAttributes.Controls.Add(new LiteralControl(string.Format("<a href=\"#\" class=\"hidden\" id=\"toggle-att-{0}\">", attribute.ProfileAttributeID)));
                            phAttributes.Controls.Add(new LiteralControl(attribute.ProfileAttributeType.AttributeType));
                            phAttributes.Controls.Add(new LiteralControl("</a></h2>"));
                            phAttributes.Controls.Add(new LiteralControl(string.Format("<div class=\"block-c\" id=\"att-{0}\">", attribute.ProfileAttributeID)));
                            phAttributes.Controls.Add(new LiteralControl(attribute.Response));
                            phAttributes.Controls.Add(new LiteralControl("</div></div>"));
                        }
                    }
                }
            }
        }

        public void ShowEditAccountInfo(bool value)
        {
            //lnkViewInfo.Visible = !value;
            lnkChangePicture.Visible = value;
            lnkEditProfile.Visible = value;
        }


        #region IProfile Members


        public void ShowAlerts(List<Alert> alerts)
        {
        }

        #endregion
    }
}
