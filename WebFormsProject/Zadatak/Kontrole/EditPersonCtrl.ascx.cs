using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak.Kontrole
{
    public partial class EditPersonCtrl : System.Web.UI.UserControl
    {

        public string ValidationGroup
        {
            set
            {
                RequiredFieldValidator1.ValidationGroup = value;
                RequiredFieldValidator2.ValidationGroup = value;
                RequiredFieldValidator3.ValidationGroup = value;
                RegularExpressionValidator1.ValidationGroup = value;
                ValidationSummary1.ValidationGroup = value;
                btnEdit.ValidationGroup = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetControlsFromPerson(Person p, List<StatusPerson> statuses, List<City> cities)
        {
            hfID.Value = p.IDPerson.ToString();
            txtName.Text = p.Name;
            txtSurname.Text = p.Surname;
            txtPass.Text = p.Pass;
            txtTelephone.Text = p.Telephone;
            txtEmail.Text = p.Email.First().EmailAdress;

            ddlCity.DataSource = cities;
            ddlCity.DataBind();
            ddlCity.SelectedIndex = cities.IndexOf(p.City);

            ddlStatus.DataSource = statuses;
            ddlStatus.DataBind();
            ddlStatus.SelectedIndex = statuses.IndexOf(p.StatusPerson);

            ddlEmails.DataSource = p.Email.ToList();
            ddlEmails.DataBind();
        }

        protected void ddlEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = ddlEmails.SelectedItem.Text;
        }

        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            Email email = new Email
            {
                EmailAdress = txtEmail.Text
            };

            // na ddlu smo stavili datavaluefield da bude property IDEmail koji se nalazi na klasi email 
            int id = int.Parse(ddlEmails.SelectedValue);

            var r = RepoFactory.GetRepository();
            r.UpdateEmail(id, email);

            ddlEmails.SelectedItem.Text = txtEmail.Text;
            this.ShowToastr("E-mail uspješno ažuriran.", ToastrType.Info);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // klikom na delete user kontroli priprema se idosobe putem hidden fielda i okida se ova funkcija i pokreće modal dialog
            // pripremamo ključ osobe koja će se potencijalno obrisat, ovisi o tome hoće li korisnik potvrditi brisanje klikom na delete na modal dialog 
            Session["deleteID"] = int.Parse(hfID.Value);

            // dohvati div s klasom modal i pokreni bootstrapovu funkciju modal i prosljedi ključnu riječ za prikaz modala(show)
            string script = "$('.modal').modal('show');";

            ScriptManager.RegisterStartupScript(this, GetType(), "delete", script, true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var mejlovi = new List<Email>();

            foreach (ListItem item in ddlEmails.Items)
            {
                mejlovi.Add(new Email
                {
                    EmailAdress = item.Text,
                    IDEmail = int.Parse(item.Value)
                });
            }

            Person p = new Person
            {
                IDPerson = int.Parse(hfID.Value),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Telephone = txtTelephone.Text,
                Pass = txtPass.Text,
                StatusPersonID = int.Parse(ddlStatus.SelectedValue),
                CityID = int.Parse(ddlCity.SelectedValue),
                Email = mejlovi
            };
            
            var r = RepoFactory.GetRepository();
            r.UpdatePerson(p.IDPerson, p);
            this.ShowToastr($"{p.Name} {p.Surname}", "Podaci uspješno ažurirani.", ToastrType.Success);
        }
    }
}