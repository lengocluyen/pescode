using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core.Impl;
using Pes.Core;
using StructureMap;
namespace PESWeb.UserControls
{
    public class TagsPresenter
    {
        private ITags _view;
        private ITagService _tagService;
        private IWebContext _webContext;
        private IConfiguration _configuration;

        public TagsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            _tagService = ObjectFactory.GetInstance<ITagService>();
        }

        public void Init(ITags view, bool IsPostBack)
        {
            _view = view;
            DetermineClientState();
        }

        public void DetermineClientState()
        {
            if (_webContext.CurrentUser != null && _view.Display == TagState.ShowCloud)
            {
                _view.ShowTagCloud(true);
                BuildTagCloud();
            }
            else if (_webContext.CurrentUser != null && _view.Display == TagState.ShowCloudAndTagBox)
            {
                _view.ShowTagBox(true);
                _view.ShowTagCloud(true);
                BuildTagCloud();
            }
            else if (_webContext.CurrentUser == null && _view.Display == TagState.ShowCloudAndTagBox)
            {
                _view.ShowTagBox(false);
                _view.ShowTagCloud(true);
                BuildTagCloud();
            }
            else if (_view.Display == TagState.ShowCloud)
            {
                _view.ShowTagBox(true);
            }
            else if (_view.Display == TagState.ShowParentCloud)
            {
                _view.ShowTagCloud(true);
                _view.ShowTagBox(false);
                BuildParentTagCloud();
            }
            else if (_view.Display == TagState.ShowGlobalCloud)
            {
                _view.ShowTagCloud(true);
                _view.ShowTagBox(false);
                BuildGlobalTagCloud();
            }
            else
            {
                _view.ShowTagBox(false);
                _view.ShowTagCloud(false);
            }
        }

        private TagWithState FixTags(Tag t)
        {
            TagWithState ts = new TagWithState();
            ts.Count = t.Count;
            ts.CreateDate = t.CreateDate;
            ts.FinalCalculatedValue = Decimal.Zero;
            ts.FontSize = int.MinValue;
            ts.InitialValue = Decimal.Zero;
            ts.MinimumOffset = Decimal.Zero;
            ts.Name = t.Name;
            ts.PreCalculatedValue = Decimal.Zero;
            ts.Ranged = Decimal.Zero;
            ts.TagID = t.TagID;
            ts.Timestamp = t.Timestamp;
            return ts;

        }

        private void BuildGlobalTagCloud()
        {
            List<Tag> tag = Tag.GetTagsGlobal(_configuration.NumberOfTagsInCloud);
            List<TagWithState> tags = new List<TagWithState>();
            foreach (Tag t in tag)
            {
                tags.Add(FixTags(t));
            }
            tags = _tagService.CalculateFontSize(tags);
            foreach (TagWithState t in tags)
            {
                _view.AddTagsToTagCloud(t);
            }
        }

        private void BuildParentTagCloud()
        {
            List<Tag> tag = Tag.GetTagsBySystemObject(_view.SystemObjectID, _configuration.NumberOfTagsInCloud);
            List<TagWithState> tags = new List<TagWithState>();
            foreach (Tag t in tag)
            {
                tags.Add(FixTags(t));
            }
            tags = _tagService.CalculateFontSize(tags);
            foreach (TagWithState t in tags)
            {
                _view.AddTagsToTagCloud(t);
            }
        }

        private void BuildTagCloud()
        {
            List<Tag> tag = Tag.GetTagsBySystemObjectAndRecordID(_view.SystemObjectID, _view.SystemObjectRecordID);
            List<TagWithState> tags = new List<TagWithState>();
            foreach (Tag t in tag)
            {
                tags.Add(FixTags(t));
            }
            tags = _tagService.CalculateFontSize(tags);
            foreach (TagWithState t in tags)
            {
                _view.AddTagsToTagCloud(t);
            }
        }

        public void btnTag_Click(string TagName)
        {
            _tagService.AddTag(TagName, _view.SystemObjectID, _view.SystemObjectRecordID);
            if (_view.Display == TagState.ShowCloud || _view.Display == TagState.ShowCloudAndTagBox)
            {
                _view.ClearTagCloud();
                BuildTagCloud();
            }
        }
    }
}
