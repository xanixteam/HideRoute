using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HideRoute
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region process route

            if (HttpContext.Current.Request.Cookies["CurrentRoute"] != null)
            {
                var route = HttpContext.Current.Request.Cookies["CurrentRoute"].Value.ToString();
                string pageName = GetPageName(route);
                Placeholder1.Controls.Add(LoadControl("/ctrls/" + pageName + ".ascx"));
            }
            else
            {
                Placeholder1.Controls.Add(LoadControl("/ctrls/default.ascx"));
            }

            #endregion

        }

        public string GetPageName(string href)
        {
            int index = href.IndexOf("&");
            if (index == -1)
                return href.Trim('/');
            else
            {
                return href.Substring(0, index).Trim('/');
            }
        }
            
    }
}