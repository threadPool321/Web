using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lz.Web.Model
{
    /// <summary>
    /// 新闻实体
    /// </summary>
    public class NewsInfo
    {
        //ID, title, content, type, Date, people, picUrl
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Conotent { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string People { get; set; }
        public string PicUrl { get; set; }
    }
}
