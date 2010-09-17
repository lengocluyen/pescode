using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using Pes.Core.Impl;
using StructureMap;
namespace PESWeb.UserControls
{
    public class RatingsPresenter
    {

        private IRatings _view;
        private IWebContext _webContext;

        public RatingsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        internal void Init(IRatings ratings, bool IsPostBack)
        {
            _view = ratings;
            //if (_webContext.CurrentUser == null)
            //    _view.CanSetRating(false);
            //else if (Rating.HasRatedBefore(_view.SystemObjectID, _view.SystemObjectRecordID, _webContext.CurrentUser.AccountID))
            //    _view.CanSetRating(false);
            //else
            //    _view.CanSetRating(true);

            _view.SetCurrentRating(Rating.GetCurrentRating(_view.SystemObjectID, _view.SystemObjectRecordID));

        }

        internal void SaveRating(object sender, AjaxControlToolkit.RatingEventArgs e, int SystemObjectID, long SystemObjectRecordID)
        {
            Rating rating = new Rating();
            rating.CreatedByAccountID = _webContext.CurrentUser.AccountID;
            rating.CreatedByUsername = _webContext.CurrentUser.Username;
            rating.CreateDate = DateTime.Now;
            rating.Score = int.Parse(e.Value);
            rating.SystemObjectRatingOptionID = 3;
            rating.SystemObjectID = SystemObjectID;
            rating.SystemObjectRecordID = SystemObjectRecordID;
            Rating rt = Rating.Find(r => r.CreatedByAccountID == _webContext.CurrentUser.AccountID && r.SystemObjectRecordID == SystemObjectRecordID).FirstOrDefault();
            if (rt != null)
                Rating.Update(rating);
            else
                Rating.Add(rating);

        }
    }
}
