using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeLayerWebDemo.FileDownLoad
{
    /// <summary>
    /// FileDownLoadHandeler 的摘要说明
    /// </summary>
    public class FileDownLoadHandeler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string encodeFileName = HttpUtility.UrlEncode("新建文本文档.txt");
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", encodeFileName));

            context.Response.WriteFile("新建文本文档.txt");
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