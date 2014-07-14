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
        bool IsCompleteWithSample = false, IsAndroidComplete = false, IsiOSComplete = false, IsWP8Complete = false;
         
        public void ProcessRequest(HttpContext context)
        {
            IsCompleteWithSample = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsComplete"]) ? "false" : context.Request.QueryString["IsComplete"]));
            IsAndroidComplete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsAndroidComplete"]) ? "false" : context.Request.QueryString["IsComplete"]));
            IsiOSComplete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsiOSComplete"]) ? "false" : context.Request.QueryString["IsComplete"]));
            IsWP8Complete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsWP8Complete"]) ? "false" : context.Request.QueryString["IsComplete"]));
            Image img = Image.FromFile((IsCompleteWithSample ? context.Server.MapPath("./") + "2.png" : context.Server.MapPath("./") + "1.png"));

            Graphics g = Graphics.FromImage(img);

            g.DrawImage(Image.FromFile((IsAndroidComplete ? context.Server.MapPath("./") + "4.png" : context.Server.MapPath("./") + "3.png")), new Point(10, 10));
            g.DrawImage(Image.FromFile((IsiOSComplete ? context.Server.MapPath("./") + "6.png" : context.Server.MapPath("./") + "5.png")), new Point(20, 20));
            g.DrawImage(Image.FromFile((IsWP8Complete ? context.Server.MapPath("./") + "8.png" : context.Server.MapPath("./") + "7.png")), new Point(30, 30));
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