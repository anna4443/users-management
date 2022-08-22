using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadatak.Kontrole;

namespace Zadatak
{
    public partial class EditData : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string editID = Request.QueryString["editID"];

            var repo = RepoFactory.GetRepository();

            List<Person> people = repo.GetPeople();
            List<City> cities = repo.GetCities();
            List<StatusPerson> statuses = repo.GetStatusPeople();

            if (editID == null)
            {
                int counter = 1;

                // foreacham kroz osobe iz repozitorija (za svaku osobu se kreira zasebna kontrola koja služi za uređivanje osobe)
                // counter služi da svaka kontrola ima jedinstvenu validacijsku grupu (kada se stisne edit da se validira samo trenutna kontrola)
                foreach (var person in people)
                {
                    var control = LoadControl("~/Kontrole/EditPersonCtrl.ascx") as EditPersonCtrl;

                    control.ValidationGroup = $"Group{counter++}";
                    control.SetControlsFromPerson(person, statuses, cities);

                    pnlControls.Controls.Add(control);
                }
            }
            else
            {
                int id = int.Parse(editID);
                Person person = people.First(p => p.IDPerson == id);

                var control = LoadControl("~/Kontrole/EditPersonCtrl.ascx") as EditPersonCtrl;
                control.SetControlsFromPerson(person, statuses, cities);
                pnlControls.Attributes["style"] = "margin: auto; width: max-content; float: none;";
                pnlControls.Controls.Add(control);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // korisnik potvrdio brisanje osobe
            // dohvaćamo id iz sessiona i brišemo korisnika iz baze
            int deleteID = (int)Session["deleteID"];

            var r = RepoFactory.GetRepository();
            r.DeletePerson(deleteID);
            Response.Redirect(Request.RawUrl); //refresh, redirect na url s kojeg je došao
        }
    }
}