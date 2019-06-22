using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace web_96122
{
    /// <summary>
    /// info 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class info : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 96122调用此接口插入数据
        /// </summary>
        /// <param name="intNum"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="redeptid"></param>
        /// <returns></returns>
        [WebMethod]
        public int AddInfo(string intNum, string title, string content, string redeptid)
        {
            return 0;  //0 失败  1成功
        }
    }
}
