using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace Pes.Core
{
    public partial class Comment
    {
        [SubSonicIgnore]
        public string CreateDateString
        {
            get { return CreateDate.ToString("dd/MM/yyyy lúc HH:mm"); }
        }

        private static int MaxComment = 3;

        public static Comment GetCommentByID(long CommentID)
        {
            Comment result = null;
            result = All().Where(c => c.CommentID == CommentID).FirstOrDefault();
            return result;
        }

        public static List<Comment> GetCommentsBySystemObject(int SystemObjectID, long SystemObjectRecordID)
        {
            List<Comment> results = null;
            results =
                All()
                .Where(c => c.SystemObjectID == SystemObjectID && c.SystemObjectRecordID == SystemObjectRecordID)
                .OrderByDescending(c => c.CreateDate)
                .ToList();
            return results;
        }

        public static List<Comment> GetMoreCommentsBySystemObject(int SystemObjectID, long SystemObjectRecordID)
        {
            List<Comment> results =
                All()
                .Where(c => c.SystemObjectID == SystemObjectID && c.SystemObjectRecordID == SystemObjectRecordID)
                .OrderByDescending(c => c.CreateDate).Skip(MaxComment)
                .ToList();
            return results;
        }
        public static List<Comment> GetTopCommentsBySystemObject(int SystemObjectID, long SystemObjectRecordID)
        {
            List<Comment> results =
                All()
                .Where(c => c.SystemObjectID == SystemObjectID && c.SystemObjectRecordID == SystemObjectRecordID)
                .OrderByDescending(c => c.CreateDate).Take(MaxComment)
                .ToList();
            return results;
        }
        public static int CountMore(int SystemObjectID, long SystemObjectRecordID)
        {
            return All()
                .Where(c => c.SystemObjectID == SystemObjectID && c.SystemObjectRecordID == SystemObjectRecordID)
                .OrderByDescending(c => c.CreateDate).Skip(MaxComment).Count();
        }

        public static long SaveComment(Comment comment)
        {
            if (comment.CommentID > 0)
            {
                Update(comment);
            }
            else
            {
                Add(comment);
            }
            return comment.CommentID;
        }

        public static void DeleteComment(Comment comment)
        {
            Delete(comment.CommentID);
        }
    }
}