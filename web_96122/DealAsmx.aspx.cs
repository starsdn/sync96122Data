using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using web_96122.webService;

namespace web_96122
{
    public partial class DealAsmx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string strXml = Request.QueryString["xmldata"];
            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string req = HttpUtility.UrlDecode(System.Text.Encoding.Default.GetString(byts));
            string strTest = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><AddInfo xmlns=\"http://tempuri.org/\"><intNum>19062115411641161431</intNum><title>&#x54A8;(&#x67E5;)&#x8BE2;:&#x8F66;&#x9A7E;&#x7BA1;&#x7406;</title><content>&#x5176;&#x4ED6;</content><redeptid>2341</redeptid></AddInfo></soapenv:Body></soapenv:Envelope>";
            string strResponse = DealXML(strTest);
            // DealXML(req);
            //string strXml = HttpUtility.UrlDecode(Request.QueryString["xmldata"]);//得到对应的xml并解码
            //  string strResponse = "<string xmlns=\"http://webServices.tmri.com\"><?xml version=\"1.0\" encoding=\"GBK\"?><root><head><code>1</code> <message></message> <keystr>3</keystr> </head> <body> </body> </root></string>";
            Response.Write(strResponse);
        }
        /// <summary>
        /// 处理请求的xml数据
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        private string DealXML(string strXml)
        {
            sysLog.WriteOptDisk(strXml);
            // string strResponse = "<AddInfoResponse xmlns=\"http://tempuri.org/\"><AddInfoResult><?xml version=\"1.0\" encoding=\"UTF - 8\"?><int xmlns = \"http://tempuri.org/\" >{0}</ int ></AddInfoResult></AddInfoResponse>";
            string strResponse = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><int xmlns = \"http://tempuri.org/\" >{0}</ int >";
             string strKey = "";
            try
            {
                //1 先得到para参数
                XmlDocument allXml = new XmlDocument();
                allXml.LoadXml(strXml);//加载xml

                XmlNamespaceManager man = new XmlNamespaceManager(allXml.NameTable);
                man.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");

                //Querying
                XmlNode titlenode = allXml.SelectSingleNode("/soapenv:Envelope/soapenv:Body", man);
                string strPara = titlenode.InnerXml; //得到para参数值
              //  strPara = HttpUtility.HtmlDecode(strPara);//html解码

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strPara);
                XmlNodeList nodes = xmlDoc.ChildNodes;
                //   DataTable dtPara = new DataTable();
                string intNum = "";//
                string title = "";//标题
                string content = "";//内容
                string redeptid = "";//部门id
                Hashtable hashParam = new Hashtable();//
                foreach (XmlNode xnode in nodes)
                {
                    List<object> objList = new List<object>();
                    XmlNodeList listParam = xnode.ChildNodes;
                    foreach (XmlNode nd in listParam) //遍历得到具体参数
                    {
                        string strCol = nd.Name;
                        if (strCol.Equals("intNum"))
                        {
                            intNum = nd.InnerText;
                        }
                        else if (strCol.Equals("title"))
                        {
                            title = nd.InnerText;
                        }
                        else if (strCol.Equals("content"))
                        {
                            content = nd.InnerText;
                        }
                        else if (strCol.Equals("redeptid"))
                        {
                            redeptid = nd.InnerText;
                        }
                        hashParam.Add(strCol, nd.InnerText);
                        objList.Add(nd.InnerText);
                    }
                   // dtPara.Rows.Add(objList.ToArray());
                }
                //一路插入本地数据库

                // 一路请求老网站webservice  
                ResquestParams rp = new ResquestParams();
                rp.MethodName = "AddInfo";
                rp.Parames = hashParam;
                rp.URL = "http://" + Request.Url.Authority + "/old_website/info.asmx";
                SoapWebService soapWebService = new SoapWebService();
                XmlDocument xmlRes = soapWebService.RequestWebService(rp);

                //string url = "http://"+Request.Url.Authority + "/old_website/info.asmx"; ;
                //byte[] bytes = Encoding.UTF8.GetBytes(strXml);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Method = "POST";
                //request.ContentLength = bytes.Length;
                //request.ContentType = "text/xml";
                //using (Stream requestStream = request.GetRequestStream())
                //{
                //    requestStream.Write(bytes, 0, bytes.Length);
                //}

                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode != HttpStatusCode.OK)
                //{
                //    string message = String.Format("POST failed. Received HTTP {0}",
                //    response.StatusCode);
                //    throw new ApplicationException(message);
                //}


                //通过后台post请求各个网点客户端
                return string.Format(strResponse, "1"); ;
            }
            catch (Exception ex)
            {
                return string.Format(strResponse, "$E", ex.Message, strKey);
            }
        }
    }
}