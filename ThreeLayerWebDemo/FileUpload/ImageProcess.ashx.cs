using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ThreeLayerWebDemo.FileUpload
{
    /// <summary>
    /// ImageProcess 的摘要说明
    /// </summary>
    public class ImageProcess : IHttpHandler
    {
        //图片处理水印的

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //接受文件

            HttpPostedFile file = context.Request.Files["imgFile"];
            if(file==null)
            {
                context.Response.End();  //停止该页执行
            }
            //把上传的图片做成一个Image对象
            Image image = Image.FromStream(file.InputStream);
            //在图片上作为背景图片使用
            Graphics graphics = Graphics.FromImage(image);  
            string str = "@byDemo";
            //在画布上写字    
            graphics.DrawString(str,new Font("黑体",24),new SolidBrush(Color.Aqua),new PointF(image.Width-(24*str.Length),image.Height-30));

            string path = "/Upload" + Guid.NewGuid().ToString() + file.FileName;

            image.Save(context.Request.MapPath(path), System.Drawing.Imaging.ImageFormat.Jpeg);

            string strHtml = string.Format("<html><head></head><body><img src='{0}'/></body></html>", path);

            context.Response.Write(strHtml);
            
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