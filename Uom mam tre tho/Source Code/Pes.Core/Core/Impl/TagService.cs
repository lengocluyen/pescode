using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SubSonic.Repository;
using SubSonic.Extensions;
namespace Pes.Core.Impl
{
    [Pluggable("Default")]
    public class TagService:ITagService
    {
        private IWebContext _webContext;
        private IConfiguration _configuration;
        private CloudSortOrder _sortOrder;

        public TagService()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            if (_configuration.CloudSortOrder.ToLower() == "ascending")
                _sortOrder = CloudSortOrder.Ascending;
            else if (_configuration.CloudSortOrder.ToLower() == "descending")
                _sortOrder = CloudSortOrder.Descending;
            else
                _sortOrder = CloudSortOrder.Random;
        }

        public void AddTag(string TagName, int SystemObjectID, long SystemObjectRecordID)
        {
            Tag tag = Tag.Find(t => t.Name == TagName).FirstOrDefault();
            if (tag == null)
            {
                tag = new Tag();
                tag.CreateDate = DateTime.Now;
                tag.Name = TagName;
                tag.Count = 1;
            }
            else
            {
                tag.Count += 1;
            }
            tag.Save();
            SystemObjectTag sysObjecttag = new SystemObjectTag();
            sysObjecttag.CreateDate = DateTime.Now;
            sysObjecttag.CreatedByAccountID = _webContext.CurrentUser.AccountID;
            sysObjecttag.CreatedByUsername = _webContext.CurrentUser.Username;
            sysObjecttag.SystemObjectRecordID = SystemObjectRecordID;
            sysObjecttag.SystemObjectID = SystemObjectID;
            sysObjecttag.TagID = tag.TagID;

            sysObjecttag.Save();

        }

        /// <summary>
        /// Sorts the tags based on their count amount from 1 to _configuration.TagCloudLargestBaseFontSize
        /// </summary>
        /// <param name="Tags">The list of tags to calculate</param>
        /// <returns>The list of calculated tags</returns>
        public List<TagWithState> CalculateFontSize(List<TagWithState> Tags)
        {
            decimal MinimumRange;
            decimal MaximumRange;
            decimal Delta;

            //get the smallest count in this list
            MinimumRange = (Tags.OrderBy(t => t.Count).Take(1).Select(t => t.Count).FirstOrDefault());

            //get the largest count in this list
            MaximumRange = (Tags.OrderByDescending(t => t.Count).Take(1).Select(t => t.Count).FirstOrDefault());

            //determine the difference between the minimum and the maximum
            Delta = MaximumRange - MinimumRange;

            if (Tags.Count > 1)
            {
                for (int i = 0; i < Tags.Count(); i++)
                {
                    //set a working value
                    Tags[i].InitialValue = Tags[i].Count;

                    //calculate the minimum offset
                    Tags[i].MinimumOffset = Tags[i].InitialValue - MinimumRange;

                    //calculate the ranged value
                    if (Tags[i].MinimumOffset > 0 && Delta > 0)
                        Tags[i].Ranged = Tags[i].MinimumOffset / Delta;
                    else
                        Tags[i].Ranged = 0;

                    //calculate the pre calculation
                    Tags[i].PreCalculatedValue = Tags[i].Ranged *
                                                 ((_configuration.TagCloudLargestFontSize -
                                                   _configuration.TagCloudSmallestFontSize) - 1);

                    //calculate the final value
                    Tags[i].FinalCalculatedValue = Tags[i].PreCalculatedValue + 1;

                    //calculate the font size
                    Tags[i].FontSize =
                        Convert.ToInt32(Tags[i].FinalCalculatedValue + _configuration.TagCloudSmallestFontSize);
                }
            }

            //if a standard sort is not what you require, you can call Tags.Sort
            //  The Tags.Sort() method (in the Domain/Tag.cs partial class) can be 
            //  modified to use different properties to sort by

            if (_sortOrder == CloudSortOrder.Ascending) //small to tall
            {
                Tags = Tags.OrderBy(t => t.FinalCalculatedValue).ToList();
            }
            else if (_sortOrder == CloudSortOrder.Descending) //tall to small
            {
                Tags = Tags.OrderByDescending(t => t.FinalCalculatedValue).ToList();
            }
            else
            {
                Tags.ShuffleList(); //randomize!
            }

            return Tags;
        }
    }
}
