using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Status
{
    /// <summary>
    /// Summary description for getStatus
    /// </summary>
    public class getStatus : IHttpHandler
    {
        bool IsCompleteWithSample = false, IsAndroidComplete = false, IsiOSComplete = false, IsWP8Complete = false, IsText = false, IsWire = false;
        string Resize = "";
        Guid newGuid;
        int resizeS = 400, resizeM=600, resizeL=800,requestedSize=400;
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                IsText = bool.Parse(GetParam("text", context));
                IsWire = bool.Parse(GetParam("wire", context));
                Resize = GetParam("size", context);
                if (Resize == "false") requestedSize = 0;
                else
                {
                    switch (Resize)
                    {
                        case "s":
                            requestedSize = resizeS;
                            break;
                        case "m":
                            requestedSize = resizeM;
                            break;
                        case "l":
                            requestedSize = resizeL;
                            break;
                        default:
                            requestedSize = resizeS;
                            break;
                    }
                }
                IsCompleteWithSample = bool.Parse(GetParam("complete", context));
                IsAndroidComplete = bool.Parse(GetParam("android", context));
                IsiOSComplete = bool.Parse(GetParam("ios", context));
                IsWP8Complete = bool.Parse(GetParam("wp", context));

                string ext = ".png";
                string text = ((IsText) ? "-text" : "") + ext;

                var wpImg = Image.FromFile(context.Server.MapPath("./images/") + (IsWP8Complete ? "4" : "3") + text);

                var iOsImg = Image.FromFile(context.Server.MapPath("./images/") + (IsiOSComplete ? "6" : "5") + text);
                var androidImg = Image.FromFile(context.Server.MapPath("./images/") + (IsAndroidComplete ? "8" : "7") + text);
                Image img = Image.FromFile(context.Server.MapPath("./images/") + (IsCompleteWithSample ? "2" : "1") + ext);

                Graphics g = Graphics.FromImage(img);
                var centerPoint = new Point((img.Width) / 2, (img.Height) / 2);

                g.DrawImage(wpImg, ImgOffset(wpImg, centerPoint));
                g.DrawImage(iOsImg, ImgOffset(iOsImg, centerPoint));
                g.DrawImage(androidImg, ImgOffset(androidImg, centerPoint));

                if (IsWire)
                {
                    DrawWireFrame(g, img);
                    DrawWireFrame(g, androidImg, ImgOffset(androidImg, centerPoint), Color.GreenYellow);
                    DrawWireFrame(g, iOsImg, ImgOffset(iOsImg, centerPoint), Color.Purple);
                    DrawWireFrame(g, wpImg, ImgOffset(wpImg, centerPoint), Color.Blue);
                }
                img = ImageResize(img, requestedSize, requestedSize);
                newGuid = Guid.NewGuid();
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Png);
                    stream.WriteTo(context.Response.OutputStream);
                    using (Image image = Image.FromStream(stream))
                    {
                        image.Save(context.Server.MapPath("./images/") + newGuid + ".png", ImageFormat.Png);
                    }
                   
                    byte[] imgBytes = File.ReadAllBytes(context.Server.MapPath("./images/") + newGuid + ".png");
                    if (imgBytes.Length > 0)
                    {
                        context.Response.ClearHeaders();
                        context.Response.Clear();
                        context.Response.ContentType = "image/png";
                        context.Response.BinaryWrite(imgBytes);
                    }
                }
                File.Delete(context.Server.MapPath("./images/") + newGuid + ".png");
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(ex.Message + "\r\n" + ex.StackTrace + ex.InnerException);
            }
            
        }

        public static Image ImageResize(Image SourceImage, Int32 NewHeight, Int32 NewWidth)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(NewWidth, NewHeight, SourceImage.PixelFormat);

            if (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed |
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed | 
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed |
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Undefined | 
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.DontCare |
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppArgb1555 |
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppGrayScale)
            {
                throw new NotSupportedException("Pixel format of the image is not supported.");
            }

            System.Drawing.Graphics graphicsImage = System.Drawing.Graphics.FromImage(bitmap);

            graphicsImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphicsImage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphicsImage.DrawImage(SourceImage, 0, 0, bitmap.Width, bitmap.Height);
            graphicsImage.Dispose();
            return bitmap;
        }

        bool dummyCallBack()
        {
            return false;
        }
        private Point ImgOffset(Image img, Point canvasCenter)
        {
            var imageCenter = new Size((img.Width) / 2, (img.Height) / 2);
            return (Point.Subtract(canvasCenter, imageCenter));
        }

        private void DrawWireFrame(Graphics g, Image img, Point offset = default(Point), Color color = default(Color))
        {
            if (color.IsEmpty)
                color = Color.Red;
            g.DrawRectangle(new Pen(color), offset.X, offset.Y, img.Width - 1, img.Height - 1);
            var endPoints = (Point.Add(offset, img.Size));
            g.DrawLine(new Pen(color), offset.X, offset.Y, endPoints.X, endPoints.Y);
            g.DrawLine(new Pen(color), offset.X, endPoints.X, endPoints.Y, offset.Y);
        }

        private string GetParam(string param, HttpContext context)
        {
            return (String.IsNullOrEmpty(context.Request.QueryString[param])
                ? "false"
                : context.Request.QueryString[param].ToLowerInvariant());
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