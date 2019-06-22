using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web_96122
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string strRequestUrl = Request.Url.AbsolutePath.ToLower(); //得到请求路径

            if (strRequestUrl.Contains("info.asmx"))
            {
                //byte[] byts = new byte[Request.InputStream.Length];
                //Request.InputStream.Read(byts, 0, byts.Length);
                //string req = System.Text.Encoding.Default.GetString(byts);
                //Request.InputStream.Position = 0;
               // Response.Redirect("VideoXml.aspx?xmldata=" + req);
                Server.Transfer("DealAsmx.aspx");
            }
            else
            {
                // string strUrl = Request.Url.Authority+"/old_website"+ strRequestUrl;
                string strUrl ="http://"+ Request.Url.Authority + "/old_website" + strRequestUrl;
                Response.Redirect(strUrl);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}