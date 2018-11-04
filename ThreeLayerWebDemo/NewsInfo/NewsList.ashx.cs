using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace ThreeLayerWebDemo.NewsInfo
{
    /// <summary>
    /// NewsList 的摘要说明
    /// </summary>
    public class NewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Lz.Web.Bll.NewsInfoService newsInfoService = new Lz.Web.Bll.NewsInfoService();
            List<Lz.Web.Model.NewsInfo> newsInfo = newsInfoService.GetAllNews();
            StringBuilder sb = new StringBuilder();
            foreach (var item in newsInfo)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='{0}'>操作</a></td></tr>", item.ID, item.Titel, item.Type, item.Date, item.People);
            }
           string result= System.IO.File.ReadAllText(context.Request.MapPath("NewsListTemp.html"));
            context.Response.Write( result.Replace("@trHoldPlace", sb.ToString()));

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