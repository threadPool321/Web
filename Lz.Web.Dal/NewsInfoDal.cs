using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lz.Web.Model;

namespace Lz.Web.Dal
{
    public class NewsInfoDal
    {
        public List<NewsInfo> GetAllNewsInfo()
        {
            string sqll = "select ID, title, content, type, Date, people, picUrl from [dbo].[HKSJ_Main]";
            System.Data.DataTable table=SqlHelper.ExecuteDataTable(sqll, System.Data.CommandType.Text);
            List<NewsInfo> list = new List<NewsInfo>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(new NewsInfo()
                {
                    ID = Convert.ToInt32(table.Rows[i]["ID"]),
                    Titel = table.Rows[i]["title"] as string,
                    Conotent = table.Rows[i]["content"] as string,
                    Type=table.Rows[0]["type"] as string,
                    Date=Convert.ToDateTime(table.Rows[0]["Date"]),
                    People=table.Rows[i]["people"] as string,
                    PicUrl=table.Rows[i]["picUrl"] as string                    
                });
            }
            return list;
        }
    }
}
