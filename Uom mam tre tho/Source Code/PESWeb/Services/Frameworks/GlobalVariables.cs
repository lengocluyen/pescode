using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalVariables
/// </summary>
public class GlobalVariables
{
	public GlobalVariables(){}

    //Struct Example
    public struct exampleStruct
    {
        public string value1;
        public int value2;
        public float value3;
        public exampleStruct(string svalue1, int svalue2, float svalue3)
        {
            this.value1 = svalue1;
            this.value2 = svalue2;
            this.value3 = svalue3;            
        }
    }

    public static exampleStruct CreateStruct
    {
        get
        {
            exampleStruct objCC = new exampleStruct();
            if (System.Web.HttpContext.Current.Session["CreateStruct"] == null)
                return objCC;
            return (exampleStruct)System.Web.HttpContext.Current.Session["CreateStruct"];
        }
        set
        {
            System.Web.HttpContext.Current.Session["CreateStruct"] = value;
        }
    }

    //string Session Example
    public static string stringSession
    {
        get
        {
            if (PESSession.Get("stringSession") == null)
                return string.Empty;
            return Commons.ForceString(PESSession.Get("stringSession"));
        }
        set
        {
            PESSession.Set("stringSession", value);
        }
    }
}
