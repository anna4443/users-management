using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Zadatak
{
    public class MyPage : System.Web.UI.Page
    {
        protected Person logedInPerson;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Response.Cookies["korisnik"].Value == null && Session["korisnik"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            else if (Response.Cookies["korisnik"].Value != null)
            {
                logedInPerson = Person.ParseFromFile(Response.Cookies["korisnik"].Value);
            }

            else if (Session["korisnik"] != null)
            {
                logedInPerson = (Person)Session["korisnik"];
            }

            if (logedInPerson.StatusPersonID != 2 && !Request.RawUrl.Contains("PersonList"))
            {
                Response.Redirect("~/PersonList.aspx");
            }

            if (logedInPerson != null)
            {
                (Page.Master as MainMaster).SetTextButton($"{logedInPerson.Name} {logedInPerson.Surname}");
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (Request.Cookies["theme"] != null)
            {
                var tema = Request.Cookies["theme"].Value;
                if (tema != "0")
                {//Ako je odabrana bilo koja od one ---odaberi
                    Theme = tema;
                }
            }

            if (Request.Cookies["repo"] != null)
            {
                var r = Request.Cookies["repo"].Value;
                
                if (r != "0")
                {
                    bool useDataRepo = r == "2";

                    RepoFactory.UseDataRepo = useDataRepo;

                    (Master as MainMaster).SetRepoText(useDataRepo ? "Database" : "Text File");
                }
            }
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            if (Request.Cookies["language"] != null)
            {
                var culture = Request.Cookies["language"].Value;
                if (culture != "0")
                {
                    //globalizacija
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

                    //lokalizacija
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
            }
        }
    }
}