using Lz.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lz.Web.Bll
{
    public class NewsInfoService
    {
        Lz.Web.Dal.NewsInfoDal dal = new Dal.NewsInfoDal();
        public List<NewsInfo> GetAllNews()
        {
            return dal.GetAllNewsInfo();
        }
    }
}
