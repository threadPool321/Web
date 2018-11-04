using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeLayerWebDemo.FileUpload
{
    /// <summary>
    /// ShowImageHandler 的摘要说明
    /// </summary>
    public class ShowImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.WriteFile("a.jpg");
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