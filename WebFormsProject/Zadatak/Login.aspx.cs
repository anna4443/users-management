using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new ArgumentOutOfRangeException("Testing");
            //DataRepo dataRepo = new DataRepo();
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            var repo = RepoFactory.GetRepository();
            var korisnik = repo.IsKorisnik(txtEmail.Text, txtPassword.Text);

            if (korisnik == null)
            {
                if (txtEmail.Text == "admin@email.com" && txtPassword.Text == "123")
                {
                    korisnik = new Person()
                    {
                        Name = "Admin",
                        Surname = "Admin",
                        StatusPersonID = 2
                    };

                }
                else
                {
                    return;
                }           
            }

            if (cbRemember.Checked)
            {
                if (Response.Cookies["korisnik"] != null)
                {
                    Response.Cookies.Remove("korisnik");
                }

                Response.Cookies.Add(new HttpCookie("korisnik", korisnik.FormatForFile()));
            }

            Session.Add("korisnik", korisnik);
            Response.Redirect("~/PersonList.aspx");
        }
    }
}