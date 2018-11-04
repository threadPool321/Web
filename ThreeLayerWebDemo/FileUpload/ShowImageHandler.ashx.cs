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
        //在返回图片的时候进行判断是否是同一个本站点过来的请求

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            //判断是否是本网站的请求，如果是进行放行，如果不是进行拒绝请求
            
            Uri referrerUrl = context.Request.UrlReferrer;   //客户端的url

            //判断：UrlReferrer的域名和端口是否和自己端口一样
            Uri requestUrl = context.Request.Url;

            if(Uri.Compare(referrerUrl,requestUrl,UriComponents.HostAndPort,UriFormat.SafeUnescaped,StringComparison.CurrentCulture)==0)
            {
                context.Response.WriteFile("a.jpg");

            }
            else
            {
                context.Response.WriteFile("b.jpg");  //这是一个错误的图片
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