using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for ITBusMail
/// </summary>
public class PESMail
{
    public PESMail() { }
    private ArrayList _listStringEmail;
    private string _subjec;
    private string _content;
    private bool _isHtml;

    public ArrayList List
    {
        get { return _listStringEmail; }
        set { _listStringEmail = value; }
    }
    public string Subject
    {
        get { return _subjec; }
        set { _subjec = value; }
    }
    public string Content
    {
        get { return _content; }
        set { _content = value; }
    }
    public bool IsHtml
    {
        get { return _isHtml; }
        set { _isHtml = value; }
    }    
}
