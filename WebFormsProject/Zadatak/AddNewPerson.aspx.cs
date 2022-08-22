using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak
{
    public partial class AddNewPerson : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // postback je "refreshanje" stranice, IsPostback govori je li stranica vec bila ucitana, ak se prvi put ucitava, IsPostback je false, ako je refreshas s npr. klikom na neki gumb, onda se opet ucitava ista stranica i IsPostback je true
            if (!IsPostBack)
            {
                var rp = RepoFactory.GetRepository();
                ddlCities.DataSource = rp.GetCities();
                ddlStatusPerson.DataSource = rp.GetStatusPeople();

                DataBind();
            }

            if(Session["addedUser"] != null)
            {
                var p = (Person)Session["addedUser"];
                this.ShowToastr($"{p.Name} {p.Surname} - osoba uspješno dodana.", ToastrType.Success);
            }
        }

        protected void btnAddEmails_Click(object sender, EventArgs e)
        {
            if (!txtEmail2.Visible)
            {
                txtEmail2.Visible = true;
            }

            else if (!txtEmail3.Visible)
            {
                txtEmail3.Visible = true;
                btnAddEmails.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var mejlovi = new List<Email>();

            // provjeriti za svaki mail jel je prazan ili nije, uprotivnom baca ex jer pokusava stavit u bazu osobu s praznim emailom
                if (!string.IsNullOrEmpty(txtEmail1.Text))
                mejlovi.Add(new Email { EmailAdress = txtEmail1.Text });
            if (!string.IsNullOrEmpty(txtEmail2.Text))
                mejlovi.Add(new Email { EmailAdress = txtEmail2.Text });
            if (!string.IsNullOrEmpty(txtEmail3.Text))
                mejlovi.Add(new Email { EmailAdress = txtEmail3.Text });

            var r = RepoFactory.GetRepository();
            var p = new Person
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = mejlovi,
                Telephone = txtTelephone.Text,
                CityID = int.Parse(ddlCities.SelectedValue),
                StatusPersonID = int.Parse(ddlStatusPerson.SelectedValue),
                Pass = txtPassword.Text
            };
            r.InsertPerson(p);

            Session["addedUser"] = p;
            
            Response.Redirect(Request.RawUrl);
        }
    }
}