using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Comment
    {
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
                    All().Where(
                        c => c.SystemObjectID == SystemObjectID && c.SystemObjectRecordID == SystemObjectRecordID).
                        OrderByDescending(c => c.CreateDate).
                        ToList();
            return results;
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