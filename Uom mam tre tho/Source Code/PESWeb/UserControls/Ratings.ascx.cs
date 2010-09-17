using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using System.Threading;
using AjaxControlToolkit;
namespace PESWeb.UserControls
{
    public partial class Ratings : System.Web.UI.UserControl, IRatings
    {
        public int SystemObjectID { get; set; }
        public long SystemObjectRecordID { get; set; }
        private RatingsPresenter _presenter;


        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new RatingsPresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void SetCurrentRating(int CurrentRating)
        {
            Rating1.CurrentRating = CurrentRating;
        }

        public void LoadOptions(List<SystemObjectRatingOption> Options)
        {

        }
        protected void Rating_Changed(object sender, RatingEventArgs e)
        {
            _presenter.SaveRating(sender, e, SystemObjectID, SystemObjectRecordID);
        }
    }
}