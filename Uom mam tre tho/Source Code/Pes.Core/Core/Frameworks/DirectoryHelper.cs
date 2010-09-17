using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for DirectoryHelper
/// </summary>
public class DirectoryHelper
{
    private string directoryPath;

    public string DirectoryPath
    {
        get
        {
            return directoryPath;
        }
        set
        {
            directoryPath = value;
        }
    }

    public DirectoryHelper(string directoryPath)
    {
        this.DirectoryPath = directoryPath;
    }

    public bool CreateSubDirectory(string SubDirectoryName, ref string message)
    {
        try
        {
            string path = HttpContext.Current.Server.MapPath(this.DirectoryPath) + "\\" + SubDirectoryName;
            if (Directory.Exists(path))
            {
                message = "Đã tồn tại thư mục " + SubDirectoryName;
                return false;
            }
            else
            {
                Directory.CreateDirectory(path);
                message = "Đã tạo xong thư mục " + SubDirectoryName;
                return true;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện tạo thư mục " + SubDirectoryName;
            return false;
        }
    }

    public bool DeleteSubDirectory(string SubDirectoryName, ref string message)
    {
        try
        {
            string path = HttpContext.Current.Server.MapPath(this.DirectoryPath) + "\\" + SubDirectoryName;
            if (Directory.Exists(path))
            {
                Directory.Delete(path,true);
                message = "Đã xóa thư mục " + SubDirectoryName;
                return false;
            }
            else
            {
                message = "Không tìm thấy thư mục " + SubDirectoryName;
                return true;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện xóa thư mục " + SubDirectoryName;
            return false;
        }
    }

    public bool DeleteDirectory(ref string message)
    {
        try
        {
            string path = HttpContext.Current.Server.MapPath(this.DirectoryPath);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                message = "Đã xóa thư mục.";
                return false;
            }
            else
            {
                message = "Không tìm thấy thư mục.";
                return true;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện xóa thư mục.";
            return false;
        }
    }
}
