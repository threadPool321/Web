using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace ThreeLayerWebDemo.FileUpload
{
    /// <summary>
    /// ImageSmallHandel 的摘要说明
    /// </summary>
    public class ImageSmallHandel : IHttpHandler
    {
        //图片的缩略图
       
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";

            HttpPostedFile file = context.Request.Files["imgFile"];
            if(file==null)
            {
                context.Response.End();
            }
            Image image = Image.FromStream(file.InputStream);

            #region 自己写的缩略图代码
            //创建这样一个小的图片
            //Bitmap smallBitMap = new Bitmap(100, 100);

            //Graphics g = Graphics.FromImage(smallBitMap);
            //g.DrawImage(image, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            //string path = "/Upload/smal_" + Guid.NewGuid().ToString() + file.FileName;

            //smallBitMap.Save(context.Request.MapPath(path));
            //MemoryStream ms = new MemoryStream();
            //smallBitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);    //把缩略图写到内存流中去
            //context.Response.BinaryWrite(ms.ToArray()); 
            #endregion

            //生产图片的原始路径
            string originPath = "/Upload/" + Guid.NewGuid().ToString() + file.FileName;
            string oriPath = context.Request.MapPath(originPath);  //相对路径转换为绝对路径
            file.SaveAs(oriPath);

            //缩略图的绝对路径
            string smallPath = "/Upload/smal-" + Guid.NewGuid().ToString() + file.FileName;
            string smPath = context.Request.MapPath(smallPath);
            file.SaveAs(smPath);

            Lz.Web.Common.ImageHelper.MakeThumbnail(oriPath, smPath, 100, 100, "W");

            context.Response.WriteFile(smallPath);  //只有他是输出一个相对路径
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