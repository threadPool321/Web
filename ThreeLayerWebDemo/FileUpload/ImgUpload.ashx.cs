using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ThreeLayerWebDemo.FileUpload
{
    /// <summary>
    /// ImgUpload 的摘要说明
    /// </summary>
    public class ImgUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            var files = context.Request.Files["imgFile"];
            var ext=Path.GetExtension(files.FileName);
            //这里的校验是相对安全的，客户端的校验就是提示客户进行的一个提示信息
            if (!(ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".gif"))
            {
                context.Response.Write("格式不正确");
                context.Response.End();  //这个方法就是彻底的结束了不在走下面的代码了
            }

                string path = "/Upload/" + Guid.NewGuid().ToString() + files.FileName;
            files.SaveAs(context.Request.MapPath( path));

            context.Response.Write("<html><head></head><body><img src='"+path+"'/></body></html>");
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