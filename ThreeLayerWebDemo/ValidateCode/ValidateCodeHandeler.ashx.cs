using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeLayerWebDemo.ValidateCode
{
    /// <summary>
    /// ValidateCodeHandeler 的摘要说明
    /// </summary>
    public class ValidateCodeHandeler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            Lz.Web.Common.ValidateCode.CreateValidateGraphic(Lz.Web.Common.ValidateCode.CreateValidateCode(5),context);
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