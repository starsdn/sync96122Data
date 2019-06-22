using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace web_96122.webService
{
    /// <summary>
    /// 访问webservice基类
    /// </summary>
    public abstract class WebServiceCaller
    {
        /// <summary>
        /// 请求WebService
        /// </summary>
        /// <param name="URL">WebService的路径</param>
        /// <param name="MethodName">方法名</param>
        /// <param name="Pars">参数</param>
        /// <returns></returns>
        abstract public System.Xml.XmlDocument RequestWebService(ResquestParams rp);

        /// <summary>
        /// 设置凭证与超时时间
        /// </summary>
        /// <param name="request"></param>
        public static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
        }

        /// <summary>
        /// 读取响应输出流
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static XmlDocument ReadXmlResponse(WebResponse response)
        {
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }

        public static String ParsToString(Hashtable Pars)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string k in Pars.Keys)
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }
                sb.Append(HttpUtility.UrlEncode(k) + "=" + HttpUtility.UrlEncode(Pars[k].ToString()));
            }
            return sb.ToString();
        }
    }

    public class ResquestParams
    {
        /// <summary>
        /// WebService地址
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// web方法
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 方法参数
        /// </summary>
        public Hashtable Parames { get; set; }
    }
}