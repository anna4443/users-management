using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak
{
    public partial class MainMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUser.Visible = Page is MyPage;
            btnLogout.Visible = Page is MyPage;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("korisnik");
            Session.Remove("korisnik");
            Response.Redirect("~/Login.aspx");
        }

        public void SetTextButton(string name) => btnUser.Text = name;

        public void SetRepoText(string repo) => lblRepo2.Text = repo;
    }
}