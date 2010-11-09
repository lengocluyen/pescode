using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class SystemObjectTag
    {
        public static List<SystemObjectTagWithObjects> GetSystemObjectsByTagID(int TagID)
        {
            List<SystemObjectTagWithObjects> result = new List<SystemObjectTagWithObjects>();
            List<SystemObjectTag> tags = new List<SystemObjectTag>();

            List<Account> accounts = new List<Account>();
            List<Profile> profiles = new List<Profile>();
            List<Blog> blogs = new List<Blog>();
            List<BoardPost> posts = new List<BoardPost>();
            List<File> files = new List<File>();
            List<FileType> fileTypes = new List<FileType>();
            List<Folder> folders = new List<Folder>();
            List<Group> groups = new List<Group>();

            
                tags =
                    SystemObjectTag.All().ToList().Where(sot => sot.TagID == TagID).
                    OrderByDescending(sot => sot.CreateDate).ToList();
                accounts =
                    Account.All().ToList().Where(
                        a =>
                        tags.Where(t => t.SystemObjectID == 1).Select(t => t.SystemObjectRecordID).Contains(a.AccountID))
                        .Distinct().ToList();
                profiles =
                    Profile.All().ToList().Where(
                        p =>
                        tags.Where(t => t.SystemObjectID == 2).Select(t => t.SystemObjectRecordID).Contains(p.ProfileID))
                        .Distinct().ToList();
                blogs =
                    Blog.All().ToList().Where(
                        b =>
                        tags.Where(t => t.SystemObjectID == 3).Select(t => t.SystemObjectRecordID).Contains(b.BlogID))
                        .Distinct().ToList();
                posts =
                    BoardPost.All().ToList().Where(
                        bp =>
                        tags.Where(t => t.SystemObjectID == 4).Select(t => t.SystemObjectRecordID).Contains(bp.PostID))
                        .Distinct().ToList();
                files =
                    File.All().ToList().Where(
                        f =>
                        tags.Where(t => t.SystemObjectID == 5).Select(t => t.SystemObjectRecordID).Contains(f.FileID))
                        .Distinct().ToList();
                fileTypes = FileType.All().ToList();
                for (int i = 0; i < files.Count(); i++)
                {
                    files[i].Extension =
                        fileTypes.Where(ft => ft.FileTypeID == files[i].FileTypeID).Select(ft => ft.Name).FirstOrDefault();
                }
                folders =
                        Folder.All().ToList().Where(folder => files.Select(f => f.DefaultFolderID).Contains(folder.FolderID)).ToList();
                groups =
                    Group.All().ToList().Where(
                        g =>
                        tags.Where(t => t.SystemObjectID == 6).Select(t => t.SystemObjectRecordID).Contains(g.GroupID))
                        .Distinct().ToList();
            foreach (SystemObjectTag tag in tags)
            {
                switch (tag.SystemObjectID)
                {
                    case 1:
                        result.Add(new SystemObjectTagWithObjects() { SystemObjectTag = tag, Account = accounts.Where(a => a.AccountID == tag.SystemObjectRecordID).FirstOrDefault() });
                        break;

                    case 2:
                        result.Add(new SystemObjectTagWithObjects() { SystemObjectTag = tag, Profile = profiles.Where(p => p.ProfileID == tag.SystemObjectRecordID).FirstOrDefault() });
                        break;

                    case 3:
                        result.Add(new SystemObjectTagWithObjects() { SystemObjectTag = tag, Blog = blogs.Where(b => b.BlogID == tag.SystemObjectRecordID).FirstOrDefault() });
                        break;

                    case 4:
                        result.Add(new SystemObjectTagWithObjects() { SystemObjectTag = tag, BoardPost = posts.Where(p => p.PostID == tag.SystemObjectRecordID).FirstOrDefault() });
                        break;

                    case 5:
                        //need to get the file for use in getting the folder as well
                        File file = files.Where(f => f.FileID == tag.SystemObjectRecordID).FirstOrDefault();
                        result.Add(new SystemObjectTagWithObjects()
                        {
                            SystemObjectTag = tag,
                            File = file,
                            Folder =
                                folders.Where(f => f.FolderID == file.DefaultFolderID).FirstOrDefault()
                        });
                        break;

                    case 6:
                        result.Add(new SystemObjectTagWithObjects() { SystemObjectTag = tag, Group = groups.Where(g => g.GroupID == tag.SystemObjectRecordID).FirstOrDefault() });
                        break;
                }
            }

            return result;
        }
    }
}