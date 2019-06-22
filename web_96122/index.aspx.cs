using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_96122
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUrl ="http://"+ Request.Url.Authority + "/old_website/" ;
            // Server.Transfer(strUrl);
            Response.Redirect(strUrl);
        }
    }
}