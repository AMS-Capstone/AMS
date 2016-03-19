using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS
{
    /// <summary>
    /// Summary description for DocumentHandler
    /// </summary>
    public class DocumentHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if ((context.Session["ImageBytes"]) != null)
            {
                byte[] image = (byte[])(context.Session["ImageBytes"]);
                context.Response.ContentType = "image/JPEG";
                context.Response.BinaryWrite(image);
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