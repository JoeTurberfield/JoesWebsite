using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace JoesWebsite
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            //context.Response.Write("Hello World");

            //int width = int.Parse(context.Request.QueryString["width"]);
            //int height = int.Parse(context.Request.QueryString["height"]);

            using (Bitmap bmp = new Bitmap(@"C:\TestImages\RedSquare.png"))
            {
                // Crop image
                Rectangle rect = new Rectangle(0, 0, 250, 250);
                Bitmap bmpcrop = new Bitmap(rect.Height, rect.Width);

                using (Graphics g = Graphics.FromImage(bmpcrop))
                {
                    g.DrawImage(bmp, new Rectangle(0, 0, bmpcrop.Width, bmpcrop.Height),
                    rect,
                    GraphicsUnit.Pixel);
                }
                bmpcrop.Save(context.Response.OutputStream, ImageFormat.Png);
                context.Response.Flush();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}