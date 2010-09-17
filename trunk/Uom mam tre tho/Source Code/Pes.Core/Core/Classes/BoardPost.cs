using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class BoardPost
    {
        public static bool CheckPostPageNameIsUnique(string PageName)
        {
            bool result;
            BoardPost bp = All().Where(p => p.PageName == PageName).FirstOrDefault();
            if (bp != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static BoardPost GetPostByPageName(string PageName)
        {
            BoardPost result = null;
            BoardPost post = All().Where(p => p.PageName == PageName).FirstOrDefault();
            result = post;
            return result;
        }

        public static BoardPost GetPostByID(Int64 PostID)
        {
            BoardPost result = null;
            BoardPost post = All().Where(p => p.PostID == PostID).FirstOrDefault();
            result = post;
            return result;
        }

        public static List<BoardPost> GetPostsByThreadID(Int64 ThreadID)
        {
            List<BoardPost> result;
            //increment the view count for this thread
            BoardPost thread = All().Where(p => p.PostID == ThreadID).FirstOrDefault();
            if (thread != null)
                thread.ViewCount += 1;
            Update(thread);

            IEnumerable<BoardPost> posts = All().Where(p => p.ThreadID == ThreadID && !p.IsThread).OrderBy(p => p.CreateDate);
            result = posts.ToList();
            return result;
        }

        public static List<BoardPost> GetThreadsByForumID(Int32 ForumID)
        {
            List<BoardPost> result;
            IEnumerable<BoardPost> posts =
                All().Where(p => p.ForumID == ForumID && p.IsThread).OrderBy(p => p.UpdateDate);
            result = posts.ToList();
            result.Reverse();
            return result;
        }

        public static Int64 SavePost(BoardPost boardPost)
        {
            if (boardPost.PostID > 0)
            {
                Update(boardPost);
            }
            else
            {
                //get the parent containers when a new post is created
                //  to update their post counts
                BoardCategory bc = (from c in BoardCategory.All()
                                    join f in BoardForum.All() on c.CategoryID equals f.CategoryID
                                    where f.ForumID == boardPost.ForumID
                                    select c).FirstOrDefault();
                BoardForum bf = (from f in BoardForum.All()
                                 where f.ForumID == boardPost.ForumID
                                 select f).FirstOrDefault();

                //update the thread count
                if (boardPost.IsThread)
                {
                    bc.ThreadCount = bc.ThreadCount + 1;
                    bf.ThreadCount = bf.ThreadCount + 1;
                }
                //update the post count
                else
                {
                    bc.PostCount = bc.PostCount + 1;
                    bf.PostCount = bf.PostCount + 1;

                    //update post count on thread
                    BoardPost bThread = null;
                    if (boardPost.ThreadID != 0)
                    {
                        bThread = (from p in BoardPost.All()
                                   where p.PostID == boardPost.ThreadID
                                   select p).FirstOrDefault();
                    }
                    if (bThread != null)
                    {
                        bThread.ReplyCount = bThread.ReplyCount + 1;
                    }
                }

                Add(boardPost);
            }
            return boardPost.PostID;
        }

        //CHAPTER 10
        public static void DeletePostsByForumID(int ForumID)
        {
            //posts have a reference to threads...so we can't delete the threads first!

            //posts first

            foreach (BoardPost i in All().Where(bp => bp.ForumID == ForumID && !bp.IsThread))
            {
                Delete(i.Id);
            }

            //threads second
            foreach (BoardPost i in All().Where(bp => bp.ForumID == ForumID))
            {
                Delete(i.Id);
            }
        }

        public static void DeletePost(BoardPost boardPost)
        {
            //if this is a thread then we need to delete all of it's children
            if (boardPost.IsThread)
            {
                foreach (BoardPost i in All().Where(bp => bp.ThreadID == boardPost.PostID))
                {
                    Delete(i.Id);
                }
            }
            Delete(boardPost.Id);
        }
    }
}