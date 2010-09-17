using System;
using System.Collections.Generic;
using Pes.Core;

public interface IFolderService
{
    List<Folder> GetFriendsFolders(Int32 AccountID);
}
