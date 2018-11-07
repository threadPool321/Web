using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lz.Web.Bll;

namespace ThreeLayerWebDemo._2018_11_7.WebFormAspx
{
    public partial class MyFristWebForm : System.Web.UI.Page
    {
        public List<Lz.Web.Model.HKSJ_Main> NewLists { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            HKSJ_Main bll = new HKSJ_Main();
            NewLists= bll.GetModelList(string.Empty);
        }
    }
}