using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            sync_sql_fylx_once sync_fylx = new sync_sql_fylx_once();
            sync_fylx.getInsertSql();
            Console.ReadKey();
        }
    }
}
