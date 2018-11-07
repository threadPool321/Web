using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace WebDemo.Common
{
    public class LogHelper
    {
        public static Queue<string> ExcpetionInfoQueue = new Queue<string>();

        public static string LogBasePath;

        static LogHelper()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (ExcpetionInfoQueue.Count > 0)
                    {
                        string str = ExcpetionInfoQueue.Dequeue();
                        //写入错误消息。
                        string strFileName =   DateTime.Now.ToString(@"yyyy-MM-dd") + ".txt";

                        string absoluteFileName = Path.Combine(LogBasePath, strFileName);

                        lock (ExcpetionInfoQueue)
                        {
                            using (FileStream fs = new FileStream(absoluteFileName, FileMode.Append, FileAccess.Write))
                            {
                                byte[] data = Encoding.Default.GetBytes(str);
                                fs.Write(data, 0, data.Length);
                            } 
                        }
                    }
                }
            });
        }

    }
}
