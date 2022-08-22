using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak
{
    public partial class PersonList : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var people = SetDataSource();
                repeater.DataSource = people;
                repeater.DataBind();
            }
        }

        private List<Person> SetDataSource()
        {
            var r = RepoFactory.GetRepository();
            var people = r.GetPeople();
            mojGV.DataSource = people;
            mojGV.DataBind();
            return people;
        }

        public List<StatusPerson> GetStatuses()
        {
            var r = RepoFactory.GetRepository();
            return r.GetStatusPeople();
        }

        protected void mojGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            mojGV.EditIndex = e.NewEditIndex;
            var people = SetDataSource();


            var row = mojGV.Rows[e.NewEditIndex];

            var person = people[e.NewEditIndex];

            DropDownList ddl = row.Cells[4].Controls[1] as DropDownList;

            ddl.SelectedValue = person.StatusPersonID.ToString();
        }

        protected void mojGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var r = RepoFactory.GetRepository();
            var p = r.GetPeople()[e.RowIndex];
            var row = mojGV.Rows[e.RowIndex];

            List<Email> mejlovi = p.Email.ToList();

            TextBox txtName = (TextBox)row.Cells[0].Controls[0];
            TextBox txtSurname = (TextBox)row.Cells[1].Controls[0];
            TextBox txtTelephone = (TextBox)row.Cells[3].Controls[0];
            DropDownList ddlStatus = (DropDownList)row.Cells[4].Controls[1];

            Repeater repeater = (Repeater)row.Cells[2].Controls[1];
            for(int i = 0; i < repeater.Controls.Count; i++)
            {
                RepeaterItem item = (RepeaterItem)repeater.Controls[i];
                TextBox txt = (TextBox)item.Controls[1];

                mejlovi[i].EmailAdress = txt.Text;
            }

            p.Name = txtName.Text;
            p.Surname = txtSurname.Text;
            p.Email = mejlovi;
            p.Telephone = txtTelephone.Text;
            p.StatusPersonID = int.Parse(ddlStatus.SelectedValue);

            r.UpdatePerson(p.IDPerson, p);
            this.ShowToastr($"{p.Name} {p.Surname}", "Podaci uspješno ažurirani.", ToastrType.Success);

            mojGV.EditIndex = -1;
            SetDataSource();
        }

        protected void mojGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            mojGV.EditIndex = -1;
            SetDataSource();
        }

        protected void mojGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var person = e.Row.DataItem as Person;

            if (person == null)
                return;

            DropDownList ddl = e.Row.Cells[4].Controls[1] as DropDownList;

            ddl.SelectedValue = person.StatusPersonID.ToString();
        }

        protected void repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var r = RepoFactory.GetRepository();
            var p = r.GetPeople()[e.Item.ItemIndex];

            Response.Redirect("~/EditData.aspx?editID=" + p.IDPerson);
        }
    }
}