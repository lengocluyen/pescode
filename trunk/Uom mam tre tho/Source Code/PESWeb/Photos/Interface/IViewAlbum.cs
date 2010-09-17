using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Photos
{
    public interface IViewAlbum
    {
        void LoadPhotos(List<File> files);
        void LoadAlbumDetails(Folder folder);
    }
}

