using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegistrationForm_ASP_Web
{
    public partial class ManageRoles : System.Web.UI.Page
    {
        static List<Role> ListRolesPgManageRoles = new List<Role>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListUsers prevPage = new ListUsers();

            if (!IsPostBack && PreviousPage == null)
            {
                List<ListItem> Items = new List<ListItem>();

                for (int i = 0; i < ListRolesPgManageRoles.Count; i++)
                {
                    ListItem item = new ListItem(ListRolesPgManageRoles[i].Name);
                    Items.Add(item);
                }
                ListBoxRoles.Items.Clear();
                ListBoxRoles.Items.AddRange(Items.ToArray());
            }

            if (HiddenField1.Value == "add")
            {
                string counter;
                counter = (string)ViewState["Counter"];
                Role newRole = new Role(counter);
                ListRolesPgManageRoles.Add(newRole);
            }

            if (PreviousPage != null)
            {
                if (PreviousPage is ListUsers)
                {
                    prevPage = PreviousPage as ListUsers;
                    ListRolesPgManageRoles = prevPage.ListRolesFormPgListUsers;
                    List<ListItem> Items = new List<ListItem>();

                    for (int i = 0; i < ListRolesPgManageRoles.Count; i++)
                    {
                        ListItem item = new ListItem(ListRolesPgManageRoles[i].Name);
                        Items.Add(item);
                    }

                    ListBoxRoles.Items.AddRange(Items.ToArray());
                }
            }
            //HiddenField1.Value = "";
        }


        protected void Add_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnExecute.Enabled = true;
            TextBoxExAdd.Enabled = true;
            btnExecute.Visible = true;
            TextBoxExAdd.Visible = true;

            HtmlGenericControl spanInfo = new HtmlGenericControl("span")
            {
                InnerHtml = "<br />"
            };
        }




        protected void Edit_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnExecuteEdit.Enabled = true;
            TextBoxExEdit.Enabled = true;
            btnExecuteEdit.Visible = true;
            TextBoxExEdit.Visible = true;
            if (ListBoxRoles.SelectedItem != null)
                TextBoxExEdit.Text = ListBoxRoles.SelectedItem.Text;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (ListBoxRoles.SelectedItem != null)
            {
                for (int i = 0; i < ListRolesPgManageRoles.Count; i++)
                {
                    if (ListRolesPgManageRoles[i].Name == ListBoxRoles.SelectedItem.Text)
                        ListRolesPgManageRoles.RemoveAt(i);
                }
            }
            Response.Redirect(Request.RawUrl);
        }


        protected void btnExecute_Click(object sender, EventArgs e)
        {
            Role newRole = new Role(TextBoxExAdd.Text);
            ListRolesPgManageRoles.Add(newRole);
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnExecute.Enabled = false;
            btnExecute.Visible = false;
            TextBoxExAdd.Enabled = false;
            TextBoxExAdd.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void btnExecuteEdit_Click(object sender, EventArgs e)
        {
            if (ListBoxRoles.SelectedItem != null)
            {
                ListRolesPgManageRoles[ListBoxRoles.SelectedIndex].Name = TextBoxExEdit.Text;

            }


            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnExecuteEdit.Enabled = false;
            TextBoxExEdit.Enabled = false;
            btnExecuteEdit.Visible = false;
            TextBoxExEdit.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        public List<Role> ListOfRolesChanged
        {
            get
            {
                return ListRolesPgManageRoles;
            }
        }
            

    }
}