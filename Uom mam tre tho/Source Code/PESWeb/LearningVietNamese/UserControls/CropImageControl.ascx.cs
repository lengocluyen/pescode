using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PESWeb.LearningVietNamese.UserControls
{
    public partial class CropImageControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadImage();
            }
        }

        private void LoadImage()
        {
            if (Request.Params["imgSource"] != null)
            {
                string imgSource = Request.QueryString["imgSource"];
                this.imgCrop.ImageUrl = imgSource;
                this.Panel2.Visible = false;
                this.Panel1.Visible = true;
            }
            else
                Response.Redirect("Default.aspx");
        }

        protected void bn_Crop_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(this.Hidden_Width.Value);
            int h = Convert.ToInt32(this.Hidden_Height.Value);
            int x = Convert.ToInt32(this.Hidden_X.Value);
            int y = Convert.ToInt32(this.Hidden_Y.Value);

            string imgUrl = this.imgCrop.ImageUrl;
            string path = Server.MapPath(imgUrl);//imgUrl.Substring(imgUrl.IndexOf("/")+1,imgUrl.Length-imgUrl.IndexOf("/")-1));

            byte[] CropImage = Crop(path, w, h, x, y);

            using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
            {

                ms.Write(CropImage, 0, CropImage.Length);

                using (System.Drawing.Image CroppedImage = System.Drawing.Image.FromStream(ms, true))
                {

                    string SaveTo = path;

                    CroppedImage.Save(SaveTo, CroppedImage.RawFormat);

                    Panel1.Visible = false;
                    Panel2.Visible = true;

                    imgCropped.ImageUrl = imgUrl;

                }

            }
        }

        private byte[] Crop(string Img, int Width, int Height, int X, int Y)
        {

            try
            {

                using (System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(Img))
                {

                    using (Bitmap bmp = new Bitmap(Width, Height, OriginalImage.PixelFormat))
                    {

                        bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);

                        using (Graphics Graphic = Graphics.FromImage(bmp))
                        {

                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;

                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;

                            Graphic.DrawImage(OriginalImage, new Rectangle(0, 0, Width, Height), X, Y, Width, Height, GraphicsUnit.Pixel);

                            MemoryStream ms = new MemoryStream();

                            bmp.Save(ms, OriginalImage.RawFormat);

                            return ms.GetBuffer();

                        }

                    }

                }

            }

            catch (Exception Ex)
            {

                throw (Ex);

            }

        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CloseAndReload", " window.close();", true);
        }
        protected void btn_Close_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CloseAndReload", " window.location.href = opener.location.reload(); window.close();", true);
        }
    }
}