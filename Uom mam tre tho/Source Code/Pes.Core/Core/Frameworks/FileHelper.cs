using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for FileHelper
/// </summary>
public class FileHelper
{
    private static FileStream fileStream;
    private static StreamReader streamRead;
    private static StreamWriter streamWrite;

    public static string ReadData(string pathFile)
    {
        try
        {
            fileStream = new FileStream(HttpContext.Current.Server.MapPath(pathFile), FileMode.Open, FileAccess.Read);
            streamRead = new StreamReader(fileStream);
            string data = streamRead.ReadToEnd();
            return data;
        }
        catch
        {
            return null;
        }
        finally
        {
            streamRead.Close();
            fileStream.Close();
        }
    }

    public static bool WriteData(string pathFile, string data, ref string message)
    {
        try
        {
            fileStream = new FileStream(HttpContext.Current.Server.MapPath(pathFile), FileMode.Create, FileAccess.Write);
            streamWrite = new StreamWriter(fileStream);
            streamWrite.Write(data);
            message = "Đã ghi thành công file";
            return true;
        }
        catch
        {
            message = "Không thể thực hiện việc ghi file";
            return false;
        }
        finally
        {
            streamWrite.Close();
            fileStream.Close();
        }

    }

    public static bool DeleteFile(string pathFile, ref string message)
    {
        try
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(pathFile)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(pathFile));
                message = "Đã xóa file";
                return true;
            }
            else
            {
                message = "Không tìm thấy file";
                return false;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện xóa file";
            return false;
        }
    }

    public static bool CopyFile(string sourcePath, string desPath, ref string message)
    {
        try
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(sourcePath)))
            {
                File.Copy(HttpContext.Current.Server.MapPath(sourcePath), HttpContext.Current.Server.MapPath(desPath));
                message = "Đã copy file";
                return true;
            }
            else
            {
                message = "Không tìm thấy file nguồn.";
                return false;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện copy file";
            return false;
        }
    }

    public static bool MoveFile(string sourcePath, string desPath, bool overwrite, ref string message)
    {
        try
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(sourcePath)))
            {
                if (overwrite)
                {
                    File.Move(HttpContext.Current.Server.MapPath(sourcePath), HttpContext.Current.Server.MapPath(desPath));
                    message = "Đã di chuyển file";
                    return true;
                }
                else
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(desPath)))
                    {
                        message = "Đã tồn tại file.";
                        return false;
                    }
                    else
                    {
                        File.Move(HttpContext.Current.Server.MapPath(sourcePath), HttpContext.Current.Server.MapPath(desPath));
                        message = "Đã di chuyển file";
                        return true;
                    }
                }
            }
            else
            {
                message = "Không tìm thấy file nguồn.";
                return false;
            }
        }
        catch
        {
            message = "Lỗi khi thực hiện ghi file";
            return false;
        }
    }

}
