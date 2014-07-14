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
            try
            {
                IsCompleteWithSample = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsComplete"]) ? "false" : context.Request.QueryString["IsComplete"]));
                IsAndroidComplete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsAndroidComplete"]) ? "false" : context.Request.QueryString["IsAndroidComplete"]));
                IsiOSComplete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsiOSComplete"]) ? "false" : context.Request.QueryString["IsiOSComplete"]));
                IsWP8Complete = bool.Parse((String.IsNullOrEmpty(context.Request.QueryString["IsWP8Complete"]) ? "false" : context.Request.QueryString["IsWP8Complete"]));

                Image img = Image.FromFile((IsCompleteWithSample ? context.Server.MapPath("./images/") + "2.png" : context.Server.MapPath("./images/") + "1.png"));
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(Image.FromFile((IsAndroidComplete ? context.Server.MapPath("./images/") + "4.png" : context.Server.MapPath("./images/") + "3.png")), new Point(10, 10));
                g.DrawImage(Image.FromFile((IsiOSComplete ? context.Server.MapPath("./images/") + "6.png" : context.Server.MapPath("./images/") + "5.png")), new Point(20, 20));
                g.DrawImage(Image.FromFile((IsWP8Complete ? context.Server.MapPath("./images/") + "8.png" : context.Server.MapPath("./images/") + "7.png")), new Point(30, 30));
                Guid newguid = Guid.NewGuid();
                img.Save(context.Server.MapPath("./images/") + newguid + ".png", ImageFormat.Png);
                img.Dispose();
                byte[] imgBytes = File.ReadAllBytes(context.Server.MapPath("./images/") + newguid + ".png");
                if (imgBytes.Length > 0)
                {
                    context.Response.ClearHeaders();
                    context.Response.Clear();
                    context.Response.ContentType = "image/png";
                    context.Response.BinaryWrite(imgBytes);
                }
                File.Delete(context.Server.MapPath("./images/") + newguid + ".png");
            }
            catch (Exception)
            {
                
                throw;
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