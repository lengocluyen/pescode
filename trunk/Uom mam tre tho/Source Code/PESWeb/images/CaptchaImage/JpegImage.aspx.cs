using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
using System.Drawing.Imaging;

namespace PESWeb.images.CaptchaImage
{
    public partial class JpegImage : System.Web.UI.Page
    {
        private Random random = new Random();
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _webContext.CaptchaImageText = GenerateRandomCode();

            ICaptcha ci = ObjectFactory.GetInstance<ICaptcha>();
            ci.Text = _webContext.CaptchaImageText;
            ci.Width = 200;
            ci.Height = 50;
            ci.FamilyName = "Century Schoobook";

            Response.Clear();
            Response.ContentType = "image/jpeg";
            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);
            ci.Dispose();
        }

        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = string.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
