using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

/// <summary>
/// Summary description for ParentPage
/// </summary>
/// 
public class ParentControl: System.Web.UI.UserControl
{
    //protected AccessRight Permission = new AccessRight();
    protected AccessPer Permission = new AccessPer();
    protected Account MyAccount = PESSession.Admin;

    public ParentControl() { }

    protected override void  OnInit(EventArgs e)
    {
        //base.OnPreInit(e);
        this.GetAccessRight();
    }

    void GetAccessRight()
    {
        if (PESSession.Admin != null)
        {
            //Role grBO = PRole.Instance.GetRole(((Account)PESSession.Admin).UserID);
            //if (grBO != null)
            //{
                //ITBusSession.Set(SessionConstants.Session_GroupRole, grBO);
                //SetAccsessRight(grBO);
            //}
            //else
            //{
            //    //Khong co quyen truy cap
            //    Response.Redirect("Login.aspx");
            //}
        }
        else
            Response.Redirect("Login.aspx");
    }
    //void SetAccsessRight(Role grBO)
    //{
    //    Permission.Admin = (string)grBO.RoleName;
    //    //Permission.InsertAccount = (bool)grBO.InsertAccount;
    //    //Permission.InsertGroupLession = (bool)grBO.InsertGroupLession;
    //    //Permission.InsertLession = (bool)grBO.InsertLession;
    //    //Permission.InsertModule = (bool)grBO.InsertModule;
    //    //Permission.InsertRole = (bool)grBO.InsertRole;

    //    //Permission.DeleteAccount = (bool)grBO.DeleteAccount;
    //    //Permission.DeleteGroupLession = (bool)grBO.DeleteGroupLession;
    //    //Permission.DeleteLession = (bool)grBO.DeleteLession;
    //    //Permission.DeleteModule = (bool)grBO.DeleteModule;
    //    //Permission.DeleteRole = (bool)grBO.DeleteRole;

    //    //Permission.UpdateAccount = (bool)grBO.UpdateAccount;
    //    //Permission.UpdateGroupLession = (bool)grBO.UpdateGroupLession;
    //    //Permission.UpdateLession = (bool)grBO.UpdateLession;
    //    //Permission.UpdateModule = (bool)grBO.UpdateModule;
    //    //Permission.UpdateRole = (bool)grBO.UpdateRole;

    //    //Permission.ViewGroupLession = (bool)grBO.ViewGroupLession;
    //    //Permission.ViewLession = (bool)grBO.ViewLession;
    //    //Permission.ViewModule = (bool)grBO.ViewModule;
    //}
}
public class AccessRight
{
    public bool InsertLession;
    public bool DeleteLession;
    public bool UpdateLession;
    public bool ViewLession;

    public bool InsertGroupLession;
    public bool DeleteGroupLession;
    public bool UpdateGroupLession;
    public bool ViewGroupLession;

    public bool InsertModule;
    public bool DeleteModule;
    public bool UpdateModule;
    public bool ViewModule;

    public bool InsertRole;
    public bool DeleteRole;
    public bool UpdateRole;

    public bool InsertAccount;
    public bool DeleteAccount;
    public bool UpdateAccount;
        
}
public class AccessPer
{
    public string Admin = "Admin";
    public string User = "User";
}
