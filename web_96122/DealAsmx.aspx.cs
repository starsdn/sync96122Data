
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using web_96122.DBHelper;
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
            ///string strTest = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><AddInfo xmlns=\"http://tempuri.org/\"><intNum>19062115411641161431</intNum><title>&#x54A8;(&#x67E5;)&#x8BE2;:&#x8F66;&#x9A7E;&#x7BA1;&#x7406;</title><content>&#x5176;&#x4ED6;</content><redeptid>2341</redeptid></AddInfo></soapenv:Body></soapenv:Envelope>";
            //string strResponse = DealXML(strTest);
            string strResponse = DealXML(req);
            string strXml = HttpUtility.UrlDecode(Request.QueryString["xmldata"]);//得到对应的xml并解码
            //string strResponse = "<string xmlns=\"http://webServices.tmri.com\"><?xml version=\"1.0\" encoding=\"GBK\"?><root><head><code>1</code> <message></message> <keystr>3</keystr> </head> <body> </body> </root></string>";

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
            //string strResponse = "<AddInfoResponse xmlns=\"http://tempuri.org/\"><AddInfoResult><?xml version=\"1.0\" encoding=\"UTF-8\"?><int xmlns =\"http://tempuri.org/\">{0}</int></AddInfoResult></AddInfoResponse>";
            //string strResponse = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><int xmlns=\"http://tempuri.org/\">{0}</int>";
            string strResponse = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body>" +
              "<AddInfoResponse xmlns=\"http://tempuri.org/\">" +
                           "<AddInfoResult>{0}</AddInfoResult>" +
                       "</AddInfoResponse>" +
                   "</soap:Body>" +
                "</soap:Envelope>";
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

                //获取交办单位在新民意中对应的guid
                string depguid = string.Empty;
                string depsql = "select gid from TRAFFIC_DEPARTMENT t where id='2341'";
                DataSet depDS = DbHelperOra.Query(depsql);

                if (depDS != null && depDS.Tables[0] != null && depDS.Tables[0].Rows.Count > 0)
                {
                    depguid = depDS.Tables[0].Rows[0][0].ToString();
                }

                if (!string.IsNullOrEmpty(depguid))
                {
                    try
                    {
                        #region 民意档案
                        string con_guid = Guid.NewGuid().ToString("N").ToUpper(); //民意档案id
                        AddJLYEE(con_guid, title, content, intNum);
                        #endregion

                        #region 交办
                        string assign_guid = Guid.NewGuid().ToString("N").ToUpper();//交办id
                        AddAssign(assign_guid, con_guid, depguid);
                        #endregion

                        #region 处办
                        string inwork_guid = Guid.NewGuid().ToString("N").ToUpper();//处办id
                        AddInwork(inwork_guid, assign_guid, depguid);
                        #endregion
                        sysLog.WriteOptDisk("录入成功");
                    }
                    catch (Exception e)
                    {
                        sysLog.WriteOptDisk("添加新民意数据异常【error】" + e.Message + e.StackTrace);
                    }
                }
                else
                {
                    sysLog.WriteOptDisk("未获取到交办单位guid");
                }
                // 一路请求老网站webservice  
                ResquestParams rp = new ResquestParams();
                rp.MethodName = "AddInfo";
                rp.Parames = hashParam;
                rp.URL = "http://50.73.141.111/info.asmx";
                sysLog.WriteOptDisk("一路请求老网站webservice 【url】" + "http://50.73.141.111/info.asmx");
                SoapWebService soapWebService = new SoapWebService();
                XmlDocument xmlRes = soapWebService.RequestWebService(rp);
                sysLog.WriteOptDisk("老网站返回值【return】" + xmlRes);

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
                sysLog.WriteOptDisk("DealXML异常【error】" + ex.Message + ex.StackTrace);
                return string.Format(strResponse, "$E", ex.Message, strKey);
                //return "0";
            }
        }

        #region 将数据插入新民意
        /// <summary>
        /// 添加民意档案数据
        /// </summary>
        /// <param name="con_guid">民意档案id</param>
        /// <param name="title">标题</param>
        /// <param name="content">反映内容</param>
        /// <param name="intnum">96122formid</param>
        /// <returns></returns>
        private int AddJLYEE(string con_guid, string title, string content, string intnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CON_JLYEE(");
            strSql.Append("ID,BH,BT,FYNR,JBRQ,CJR,CJSJ,ZT,FYRQ,INTNUM)");
            strSql.Append(" values (");
            strSql.Append(":ID,:BH,:BT,:FYNR,:JBRQ,:CJR,:CJSJ,:ZT,:FYRQ,:INTNUM)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":BH", OracleType.VarChar,100),
                    new OracleParameter(":BT", OracleType.VarChar,500),
                    new OracleParameter(":FYNR", OracleType.Clob),
                    new OracleParameter(":JBRQ", OracleType.DateTime),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime),
                    new OracleParameter(":ZT", OracleType.Int32,1),
                    new OracleParameter(":FYRQ", OracleType.DateTime),
                    new OracleParameter(":INTNUM",OracleType.VarChar,50)};
            parameters[0].Value = con_guid;
            parameters[1].Value = intnum;
            parameters[2].Value = title;
            if (string.IsNullOrEmpty(content))
            {
                parameters[3].Value = DBNull.Value;
            }
            else
            {
                parameters[3].Value = content;
            }
            parameters[4].Value = DateTime.Now;
            parameters[5].Value = "96122";
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = intnum;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 添加交办数据
        /// </summary>
        /// <param name="assign_guid">交办id</param>
        /// <param name="con_guid">民意档案id</param>
        /// <param name="jbdw">交办单位</param>
        /// <returns></returns>
        private int AddAssign(string assign_guid, string con_guid, string jbdw)
        {
            StringBuilder insertSql_assign = new StringBuilder();
            insertSql_assign.Append("insert into ASSIGN(");
            insertSql_assign.Append("ID,MYSJDX,MYLY,JBRQ,JBDW,ZT,CJR,CJSJ)");
            insertSql_assign.Append(" values (");
            insertSql_assign.Append(":ID,:MYSJDX,:MYLY,:JBRQ,:JBDW,:ZT,:CJR,:CJSJ)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":MYSJDX", OracleType.VarChar,36),
                    new OracleParameter(":MYLY", OracleType.VarChar,36),
                    new OracleParameter(":JBRQ", OracleType.DateTime),
                    new OracleParameter(":JBDW", OracleType.VarChar,2000),
                    new OracleParameter(":ZT", OracleType.Int32,4),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime)
                };
            parameters[0].Value = assign_guid;
            parameters[1].Value = con_guid;
            parameters[2].Value = "510521AAF5FC4F06BD58C2696BDA22E5";
            parameters[3].Value = DateTime.Now;
            parameters[4].Value = jbdw;
            parameters[5].Value = 1;
            parameters[6].Value = "96122";
            parameters[7].Value = DateTime.Now;
            int rows = DbHelperOra.ExecuteSql(insertSql_assign.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 添加处办数据
        /// </summary>
        /// <param name="inworkid">处办id</param>
        /// <param name="assignid">交办id</param>
        /// <param name="jbdw">交办单位</param>
        /// <returns></returns>
        private int AddInwork(string inworkid, string assignid, string jbdw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into INWORK(");
            strSql.Append("ID,JBSJ,JBDW,ZT,CJR,CJSJ)");
            strSql.Append(" values (");
            strSql.Append(":ID,:JBSJ,:JBDW,:ZT,:CJR,:CJSJ)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":JBSJ", OracleType.VarChar,36),
                    new OracleParameter(":JBDW", OracleType.VarChar,36),
                    new OracleParameter(":ZT", OracleType.Int32,4),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime)};
            parameters[0].Value = inworkid;
            parameters[1].Value = assignid;
            parameters[2].Value = jbdw;
            parameters[3].Value = 1;
            parameters[4].Value = "96122";
            parameters[5].Value = DateTime.Now;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        #endregion
    }
}