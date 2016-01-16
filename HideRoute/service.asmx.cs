using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace HideRoute
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, XmlSerializeString = false, UseHttpGet = true)]
        public void SetRouteCookie()
        {
            if (HttpContext.Current.Request.QueryString["href"] != null)
            {
                string href = HttpContext.Current.Request.QueryString["href"];
                HttpCookie c = new HttpCookie("CurrentRoute", href);
                c.Expires = DateTime.Now.AddHours(1);
                HttpContext.Current.Response.Cookies.Add(c);

                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write("{\"status\":\"ok\"}");

            }
        }
    }
}
