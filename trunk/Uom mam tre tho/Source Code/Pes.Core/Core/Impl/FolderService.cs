using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;
using StructureMap;


public class FolderService : IFolderService
{
    public FolderService()
    {
        
    }

    public List<Folder> GetFriendsFolders(Int32 AccountID)
    {
        List<Friend> friends = Friend.GetFriendsByAccountID(AccountID);
        List<Folder> folders = Folder.GetFriendsFolders(friends);
        folders.OrderBy(f => f.CreateDate).Reverse();
        return folders;
    }
}

