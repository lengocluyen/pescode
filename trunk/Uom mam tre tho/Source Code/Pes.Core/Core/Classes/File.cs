using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;
using System.IO;

namespace Pes.Core
{
    public partial class File
    {
        public enum Sizes
        {
            T,
            S,
            M,
            L,
            O
        }

        public enum Types
        {
            JPG = 1,
            GIF = 2,
            WAV = 3,
            MP3 = 4,
            WMV = 5,
            FLV = 6,
            JPEG = 7,
            SWF = 8
        }
        [SubSonicIgnore]
        public string Extension { get; set; }
        [SubSonicIgnore]
        public static IWebContext _webContext { get; set; }
        public static bool IsFlagged(int SystemObjectID, Int64 SystemObjectRecordID)
        {
            return Moderation.Exists(x => x.SystemObjectID == SystemObjectID
                && x.SystemObjectRecordID == SystemObjectRecordID
                && x.IsDenied == true);
        }
        
        public static File GetFileByID(Int64 FileID)
        {
            File file;
            
                file = All().Where(f => f.FileID == FileID).FirstOrDefault();
                if (file != null)
                {
                    var fileType = FileType.All().Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                    file.Extension = fileType.Name;
                }
            return file;
        }

        public static File GetFileByFileSystemName(Guid FileSystemName)
        {
            File file;
                file = All().Where(f => f.FileSystemName == FileSystemName).FirstOrDefault();
                var fileType = FileType.All().Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                file.Extension = fileType.Name;
            return file;
        }

        public static List<File> GetFilesByFolderID(Int64 FolderID)
        {
            List<File> result = new List<File>();
                IEnumerable<File> files1 = (from f in All()
                                           where f.DefaultFolderID == FolderID 
                                          // && IsFlagged(5,f.FileID) != true
                                           select f);

               List<File> files1tam = new List<File>();
                foreach (var item in files1)
                {
                    if (!IsFlagged(5, item.FileID))
                        files1tam.Add(item);
                }

                IEnumerable<File> files2 = (from f in All()
                                            join ff in FolderFile.All() on f.FileID equals ff.FileID
                                            where ff.FolderID == FolderID 
                                            //&& IsFlagged(5,f.FileID) != true
                                            select f);

                List<File> files2tam = new List<File>();
                foreach (var item in files2)
                {
                    if (!IsFlagged(5, item.FileID))
                        files2tam.Add(item);
                }
                IEnumerable<File> files3 = files1tam.Union(files2tam);
                result = files3.ToList();

                foreach (File file in result)
                {
                    var fileType = FileType.All().Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                    file.Extension = fileType.Name;
                }

            return result;
        }

        public static void UpdateDescriptions(Dictionary<long, string> fileDescriptions)
        {
                List<Int64> fileIDs = fileDescriptions.Select(f => Convert.ToInt64(f.Key)).Distinct().ToList();
                List<File> files = All().ToList().Where(f =>fileIDs.Contains(f.FileID)).ToList();
                foreach (File file in files)
                {
                    file.Description = fileDescriptions[file.FileID].ToString();
                    //fileDescriptions.Where(f => f.Key == file.FileID).Select(f => f.Value).ToString();
                    Update(file);
                }
        }

        public static Int64 SaveFile(File file)
        {
                    file.CreateDate = DateTime.Now;
                    Add(file);
            return file.FileID;
        }

        public static void DeleteFilesInFolder(Folder folder)
        {
                List<File> files = GetFilesByFolderID(folder.FolderID);
                foreach (File file in files)
                {
                    DeleteFileFromFileSystem(folder, file);
                    File.Delete(file.FileID);
                }
        }

        public static void DeleteFile(File file)
        {
                Folder folder = Folder.All().Where(f => f.FolderID == file.DefaultFolderID).FirstOrDefault();
                DeleteFileFromFileSystem(folder, file);
                File.Delete(file.FileID);
        }

        private static void DeleteFileFromFileSystem(Folder folder, File file)
        {
            string path = "";
            switch (file.FileTypeID)
            {
                case 1:
                case 2:
                case 7:
                    path = "Photos\\";
                    break;
                case 3:
                case 4:
                    path = "Audios\\";
                    break;
                case 5:
                case 8:
                case 6:
                    path = "Videos\\";
                    break;
            }

            string fullPath = _webContext.FilePath + "Files\\" + path + folder.CreateDate.Year.ToString() + folder.CreateDate.Month.ToString() + "\\";
            
            if (Directory.Exists(fullPath))
            {
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__o." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__o." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__t." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__t." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__s." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__s." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__m." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__m." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__l." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__l." + file.Extension);

                if(Directory.GetFiles(fullPath).Count() == 0)
                    Directory.Delete(fullPath);
            }
        }

    }
}