using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;
using System.Diagnostics;

namespace Pes.Core
{
    public partial class Folder
    {
        public enum Types
        {
            Picture = 1,
            Video = 2,
            Audio = 3,
            File = 4
        }
        [SubSonicIgnore]
        public string FullPathToCoverImage { get; set; }
        [SubSonicIgnore]
        public string Username { get; set; }

        public static List<Folder> GetFoldersByAccountID(Int32 AccountID)
        {
            List<Folder> result = new List<Folder>();
            string cache_key = "GetFoldersByAccountID_" + AccountID.ToString();

            //Stopwatch sw = new Stopwatch();


            //if (_cache.Exists(cache_key))
            //{
            //    sw.Reset();
            //    sw.Start();
            //    result = XMLService.Deserialize<List<Folder>>(_cache.Get(cache_key).ToString());
            //    sw.Stop(); //46ms from cache
            //}
            //else
            //{
            //sw.Reset();
            //sw.Start();
            var account = Account.All().Where(a => a.AccountID == AccountID).FirstOrDefault();

            List<Folder> folders = (from f in Folder.All().ToList()
                                           where f.AccountID == AccountID
                                           orderby f.CreateDate descending
                                           select f).ToList();
            foreach (Folder folder in folders)
            {
                var fullPath = (from f in File.All()
                                join ft in FileType.All() on f.FileTypeID equals ft.FileTypeID
                                where f.DefaultFolderID == folder.FolderID
                                select new
                                {
                                    FullPathToCoverImage = f.CreateDate.Year.ToString() +
                                                           f.CreateDate.Month.ToString() +
                                                           "/" + f.FileSystemName + "__S." +
                                                           ft.Name
                                }).FirstOrDefault();
                if (fullPath != null)
                    folder.FullPathToCoverImage = fullPath.FullPathToCoverImage;
                else
                    folder.FullPathToCoverImage = "default.jpg";
                if (account != null)
                    folder.Username = account.Username;
            }
            result = folders.ToList();
            //sw.Stop(); //190ms from db

            //_cache.Set(cache_key, XMLService.Serialize(result));
            //}
            return result;
        }

        public static List<Folder> GetFriendsFolders(List<Friend> Friends)
        {
            List<Folder> result = new List<Folder>();
            foreach (Friend friend in Friends)
            {
                if (result.Count < 50)
                {
                    List<Folder> folders = GetFoldersByAccountID(friend.MyFriendsAccountID);
                    IEnumerable<Folder> result2 = result.Union(folders);
                    result = result2.ToList();
                }
                else
                    break;
            }
            return result;
        }

        public static Folder GetFolderByID(Int64 FolderID)
        {
            Folder folder;
            folder = Folder.All().Where(f => f.FolderID == FolderID).FirstOrDefault();
            return folder;
        }

        public static Int64 SaveFolder(Folder folder)
        {
            Add(folder);
            return folder.FolderID;
        }

        public static void DeleteFolder(Folder folder)
        {
            //string cache_key = "GetFoldersByAccountID_" + folder.AccountID;

            //if (_cache.Exists(cache_key))
            //    _cache.Delete(cache_key);

            Delete(folder.FolderID);
        }
    }
}