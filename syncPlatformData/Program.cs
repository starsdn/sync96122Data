using System;
using System.IO;
using System.Text;
using System.Threading;

namespace syncPlatformData
{
    public class Program
    {
        private static string strMaxId = "0";//当前已经获取数据的最大ID
        static void Main(string[] args)
        {
            Console.WriteLine("开始同步……");
            //获取本地保存的最大ID 
            getMaxId();
            Console.WriteLine("获取上次最大ID：" + strMaxId);
            Console.WriteLine("开始遍历数据……");
            deal_nw_DB deal_db = new deal_nw_DB(strMaxId);
            deal_db.event_showLogs += ShowConsoleLogs;
            new Thread(deal_db.syncData_loop).Start();//开启数据同步
            Console.ReadKey();
        }

        private static void getMaxId()
        {
            using (FileStream fs = new FileStream("configs/maxid.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                {
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    strMaxId = sr.ReadLine();
                    sr.Close();
                    fs.Close();
                }
            }
        }
        /// <summary>
        /// 前台显示信息
        /// </summary>
        private static void ShowConsoleLogs(string strContent)
        {
            Console.WriteLine(strContent);
        }
    }
}
