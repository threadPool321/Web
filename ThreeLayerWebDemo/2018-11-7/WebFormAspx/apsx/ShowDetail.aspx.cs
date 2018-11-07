using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThreeLayerWebDemo._2018_11_7.WebFormAspx.apsx
{
    public partial class ShowDetail : System.Web.UI.Page
    {
        public string strHtml { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(Request.QueryString["id"]??"0");

            Lz.Web.Bll.HKSJ_Main bll = new Lz.Web.Bll.HKSJ_Main();
            Lz.Web.Model.HKSJ_Main news = bll.GetModel(id);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<h1 class='title'>{0}</h1>", news.title);
            sb.AppendFormat("<p class='info'>{0}</p>", news.Date.ToString("yyyy-mm-dd"));
            sb.AppendFormat("<p>{0}</p>", news.content);

            strHtml = sb.ToString();

            //< h1 class="title">新政百日后山西临汾房地产业情况调查</h1>
            //        <p class="info">2010年08月18日10:45</p>
            //        <p>为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。</p>


        }
    }
}