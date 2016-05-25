using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bundesliga.Web
{
    public partial class AngularScripts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "globalJsConfig", GetGlobalJsConfig(), true);
        }

        public static string GetGlobalJsConfig()
        {
            return "var globalConfig = {ApiBaseUrl: '" + ConfigurationManager.AppSettings["ApiBaseUrl"] + "'};";
        }
    }
}