using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class BoardForum
    {
        public static BoardForum GetForumByGroupID(Int32 GroupID)
        {
            BoardForum result;
                BoardForum forum = (from f in BoardForum.All()
                                    join gf in GroupForum.All() on f.ForumID equals gf.ForumID
                                    where gf.GroupID == GroupID
                                    select f).FirstOrDefault();
                result = forum;
            return result;
        }

        public static BoardForum GetForumByID(Int32 ForumID)
        {
            BoardForum result;
                BoardForum forum = BoardForum.All().Where(f => f.ForumID == ForumID).FirstOrDefault();
                result = forum;
            return result;
        }

        public static BoardForum GetForumByPageName(string PageName)
        {
            BoardForum result;
                BoardForum forum = BoardForum.All().Where(f => f.PageName == PageName).FirstOrDefault();
                result = forum;
            return result;
        }

        public static List<BoardForum> GetForumsByCategoryID(Int32 CategoryID)
        {
            List<BoardForum> results;
                IEnumerable<BoardForum> forums = BoardForum.All().Where(f => f.CategoryID == CategoryID);
                results = forums.ToList();
            return results;
        }

        public static List<BoardForum> GetAllForums()
        {
            List<BoardForum> results;
                IEnumerable<BoardForum> forums = BoardForum.All();
                results = forums.ToList();
            return results;
        }

        public static Int32 SaveForum(BoardForum boardForum)
        {
                if (boardForum.ForumID > 0)
                {
                    BoardForum.Update(boardForum);
                }
                else
                {
                    Add(boardForum);
                }
            return boardForum.ForumID;
        }

        public static void DeleteForum(BoardForum boardForum)
        {
            Delete(boardForum.ForumID);
        }
    }
}