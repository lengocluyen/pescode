﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Profiles.Presenter;
using PESWeb.Profiles.Interface;
using PESWeb.UserControls;
using Pes.Core;

namespace PESWeb.Profiles
{
    public partial class ViewProfile : System.Web.UI.Page, IProfile
    {
        private ProfilePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ProfilePresenter();
            _presenter.Init(this);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnAddStatus.Click += new EventHandler(btnAddStatus_Click);
        }

        void btnAddStatus_Click(object sender, EventArgs e)
        {
            _presenter.AddStatus(txtStatus.Text);
            txtStatus.Text = "";
        }
        public void SetAvatar(Int32 AccountID)
        {
            if (!imgAvatar.ImageUrl.Contains("AccountID="))
                imgAvatar.ImageUrl += "?AccountID=" + AccountID.ToString();
            lnkViewInfo.NavigateUrl += "?AccountID=" + AccountID.ToString();
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

        //public void LoadStatusUpdates(List<StatusUpdate> StatusUpdates)
        //{
        //    //    repStatusUpdates.DataSource = StatusUpdates;
        //    //    repStatusUpdates.DataBind();
        //}

        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProfileDisplay pdProfileDisplay = e.Item.FindControl("pdProfileDisplay") as ProfileDisplay;
                pdProfileDisplay.LoadDisplay(((Account)e.Item.DataItem));
            }
        }

        //protected void btnViewStatusUpdates_Click(object sender, EventArgs e)
        //{
        //    _presenter.GoToStatusUpdates();
        //}

        public void DisplayInfo(Account account)
        {
            //lblFirstName.Text = account.FirstName;
            //lblLastName.Text = account.LastName;
            //litLastUpdateDate.Text = account.LastUpdateDate.ToString();
            litZip.Text = account.Zip;
            if (account.BirthDate.HasValue)
            {
                DateTime dt = (DateTime)account.BirthDate.Value;
                litBirthDate.Text =
                    string.Format("{0} tháng {1} năm {2}",
                    dt.Day.ToString().PadLeft(2, '0'), dt.Month.ToString().PadLeft(2, '0'), dt.Year);
            }
            //litSex.Text = account.Profile.se;

            if (account.Profile != null)
            {
                //litIMAOL.Text = account.Profile.IMAOL;
                litIMGIM.Text = account.Profile.IMGIM;
                //litIMICQ.Text = account.Profile.IMICQ;
                //litIMMSN.Text = account.Profile.IMMSN;
                //litIMSkype.Text = account.Profile.IMSkype;
                litIMYIM.Text = account.Profile.IMYIM;
                litNumberOfTanksOwned.Text = account.Profile.Address.ToString();
                litNumberOfFishOwned.Text = account.Profile.Enjoy.ToString();
                litYearOfFirstTank.Text = account.Profile.SchoolsName.ToString();
                //litLevelOfExperience.Text = "(" + account.Profile.LevelOfExperienceType.LevelOfExperience + ")";
                //if (account.Profile.Attributes.Count > 0)
                //{
                //    foreach (ProfileAttribute attribute in account.Profile.Attributes)
                //    {
                //        if (_presenter.IsAttributeVisible(attribute.ProfileAttributeType.PrivacyFlagTypeID))
                //        {
                //            //phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerTitle\">"));
                //            //phAttributes.Controls.Add(new LiteralControl(attribute.ProfileAttributeType.AttributeType));
                //            //phAttributes.Controls.Add(new LiteralControl("</div>"));
                //            //phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerRow\"><div class=\"divContainerCell\">"));
                //            //phAttributes.Controls.Add(new LiteralControl(attribute.Response));
                //            //phAttributes.Controls.Add(new LiteralControl("</div></div>"));

                //            phAttributes.Controls.Add(new LiteralControl("<div class=\"box profile\"><h2>"));
                //            phAttributes.Controls.Add(new LiteralControl(attribute.ProfileAttributeType.AttributeType));
                //            phAttributes.Controls.Add(new LiteralControl("</h2>"));
                //            phAttributes.Controls.Add(new LiteralControl(string.Format("<div class=\"block-c\" id=\"att-{0}\">", attribute.ProfileAttributeID)));
                //            phAttributes.Controls.Add(new LiteralControl(attribute.Response));
                //            phAttributes.Controls.Add(new LiteralControl("</div></div>"));
                //        }
                //    }
                //}
            }
        }

        public void ShowEditAccountInfo(bool value)
        {
            lnkViewInfo.Visible = !value;
            lnkChangePicture.Visible = value;
            lnkEditProfile.Visible = value;
        }


        #region IDefault Members

        public void ShowAlerts(List<Alert> alerts)
        {
            repFilter.DataSource = alerts;
            repFilter.DataBind();

            if (repFilter.Items.Count == 0)
                lblMessage.Text = "Bạn chưa đăng tin nào!";
        }

        #endregion
    }
}
