using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        
        bool IsCompleteWithSample = false, IsAndroidComplete = false, IsiOSComplete = false, IsWP8Complete = false;
         
        public void ProcessRequest(HttpContext context)
        {
            const string ext = ".png";
            IsCompleteWithSample = bool.Parse(GetParam("complete",context));
            IsAndroidComplete = bool.Parse(GetParam("android", context));
            IsiOSComplete = bool.Parse(GetParam("ios", context));
            IsWP8Complete = bool.Parse(GetParam("wp", context));

            Image img = Image.FromFile(context.Server.MapPath("./") + (IsCompleteWithSample ? "2" : "1") + ext);
            var wpImg = Image.FromFile(context.Server.MapPath("./") + (IsWP8Complete ? "4" : "3") + ext);
            var iOsImg = Image.FromFile(context.Server.MapPath("./") + (IsiOSComplete ? "6" : "5") + ext);
            var androidImg = Image.FromFile(context.Server.MapPath("./") + (IsAndroidComplete ? "8" : "7") + ext);

            Graphics g = Graphics.FromImage(img);
            var centerPoint = new Point(img.Width/2,img.Height/2);
            
            g.DrawImage(androidImg, ImgOffset(androidImg,centerPoint));
            g.DrawImage(iOsImg, ImgOffset(iOsImg, centerPoint));
            g.DrawImage(wpImg, ImgOffset(wpImg, centerPoint));
            img.Save(context.Server.MapPath("./") + "output.png", ImageFormat.Png);
            img.Dispose();
            byte[] imgBytes = File.ReadAllBytes(context.Server.MapPath("./") + "output.png");
            if (imgBytes.Length > 0)
            {
                context.Response.ClearHeaders();
                context.Response.Clear();
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(imgBytes);
            }
        }

        private Point ImgOffset(Image img, Point canvasCenter)
        {
            var imageCenter = new Size(img.Width/2,img.Height/2);

            return Point.Subtract(canvasCenter, imageCenter);
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

    public static class RequestExtensions
    {
        public static string QueryStringValue(this HttpRequest request, string parameter)
        {
            return !string.IsNullOrEmpty(request.QueryString[parameter]) ? request.QueryString[parameter] : string.Empty;
        }

        public static bool QueryStringValueMatchesExpected(this HttpRequest request, string parameter, string expected)
        {
            return !string.IsNullOrEmpty(request.QueryString[parameter]) && request.QueryString[parameter].Equals(expected, StringComparison.OrdinalIgnoreCase);
        }
    }
}