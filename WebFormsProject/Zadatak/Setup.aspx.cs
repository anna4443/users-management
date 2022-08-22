using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak
{
    public partial class Setup : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("theme");
            cookie.Value = ddlTheme.SelectedValue;
            Response.Cookies.Add(cookie);

            //refreshamo je zbog primjenjivanja teme,zato overridamo preeint u MyPage klasi
            Response.Redirect(Request.Url.AbsolutePath);//Trenutna adresa na kojoj jesmo!
        }

        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = ddlLanguages.SelectedValue;
            Response.Cookies.Add(cookie);

            //refreshamo je zbog primjenjivanja teme,zato overridamo preeint
            Response.Redirect(Request.Url.AbsolutePath);//Trenutna adresa na kojoj jesmo!

        }

        protected void ddlRepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("repo");
            cookie.Value = ddlRepo.SelectedIndex.ToString();
            Response.Cookies.Add(cookie);
            
            //refreshamo je zbog promjene repoa,zato overridamo preeint
            Response.Redirect(Request.Url.AbsolutePath);//Trenutna adresa na kojoj jesmo!
        }
    }
}