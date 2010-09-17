using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using Pes.Core;

namespace Testad
{
    public partial class Questions : System.Web.UI.UserControl
    {
        ArrayList numA = new ArrayList();
        ArrayList numC = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadValue();
            }
        }
        public void LoadValue ()
        {

            for(int i=2;i<=6;i++)
                numA.Add(i);
            this.NumAw.DataSource = numA;
            this.NumAw.DataBind();
            this.AddAnswers(2);

        }
        public void AddAnswers(int numanswer)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numanswer; i++)
            {

                numC.Add(i + 1);
                sb.Append("Đáp án " + (i + 1) + ": <input style='width:70%;margin-top:5px;' id=" + "aw" + (i + 1) + " type='text' runat='server'/><br>");
            }
            danswer.InnerHtml = sb.ToString();
            awcs.DataSource = numC;
            awcs.DataBind();
        }

        protected void NumAw_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.NumAw.SelectedValue);
            this.AddAnswers(num);
        }
    }
}