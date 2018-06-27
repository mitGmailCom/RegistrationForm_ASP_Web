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
        private static List<Role> ListRolesPgManageRoles = new List<Role>();
        string tempRoleOld = null;
        string tempRoleNew = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListUsers prevPage = new ListUsers();

            // заполняем ListBoxRoles Ролями, если пришли не с другой страницы
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

            // заполняем ListBoxRoles Ролями, если пришли с другой страницы
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
        }


        protected void Add_Click(object sender, EventArgs e)
        {
            MethodEnabled(false, btnDelete, btnEdit, btnAdd);
            MethodEnabled(true, btnExecute, TextBoxExAdd);
            MethodVisible(true, btnExecute, TextBoxExAdd);
        }


        protected void Edit_Click(object sender, EventArgs e)
        {
            MethodEnabled(false, btnDelete, btnEdit, btnAdd);
            MethodEnabled(true, btnExecuteEdit, TextBoxExEdit);
            MethodVisible(true, btnExecuteEdit, TextBoxExEdit);

            if (ListBoxRoles.SelectedItem != null)
                TextBoxExEdit.Text = ListBoxRoles.SelectedItem.Text;
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            if (ListBoxRoles.SelectedItem != null)
            {
                List<UserWithRole> tempLUserWithRole = new List<UserWithRole>();
                if (Session["ListOfUserWithRole"] != null)
                {
                    tempLUserWithRole = (List<UserWithRole>)Session["ListOfUserWithRole"];
                    for (int i = 0; i < tempLUserWithRole.Count; i++)
                    {
                        if (tempLUserWithRole[i].Role_UserWithRole.Name == ListBoxRoles.SelectedItem.Text)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Чтобы удалить эту запись поменяйте сперва Роль в Профиле, где она присутствует" + "');", true);
                            return;
                        }
                    }
                }

                for (int i = 0; i < ListRolesPgManageRoles.Count; i++)
                {
                    if (ListRolesPgManageRoles[i].Name == ListBoxRoles.SelectedItem.Text)
                    {
                        ListRolesPgManageRoles.RemoveAt(i);
                        Session["ListRoles"] = ListRolesPgManageRoles;
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }


        protected void btnExecute_Click(object sender, EventArgs e)
        {
            Role newRole = new Role(TextBoxExAdd.Text);
            ListRolesPgManageRoles.Add(newRole);
            MethodEnabled(true, btnDelete, btnEdit, btnAdd);
            MethodEnabled(false, btnExecute, TextBoxExAdd);
            MethodVisible(false, btnExecute, TextBoxExAdd);
            Session["ListRoles"] = ListRolesPgManageRoles;
            Response.Redirect(Request.RawUrl);
        }

        protected void btnExecuteEdit_Click(object sender, EventArgs e)
        {
            tempRoleOld = null;
            tempRoleNew = null;
            if (ListBoxRoles.SelectedItem != null)
            {
                tempRoleOld = ListRolesPgManageRoles[ListBoxRoles.SelectedIndex].Name;
                ListRolesPgManageRoles[ListBoxRoles.SelectedIndex].Name = TextBoxExEdit.Text;
                tempRoleNew = ListRolesPgManageRoles[ListBoxRoles.SelectedIndex].Name;
                Session["ListRoles"] = ListRolesPgManageRoles;
            }
            MethodEnabled(true, btnDelete, btnEdit, btnAdd);
            MethodEnabled(false, btnExecuteEdit, TextBoxExEdit);
            MethodVisible(false, btnExecuteEdit, TextBoxExEdit);
            List<UserWithRole> tempLUserWithRole = new List<UserWithRole>();

            if (Session["ListOfUserWithRole"] != null)
            {
                tempLUserWithRole = (List<UserWithRole>)Session["ListOfUserWithRole"];
                for (int i = 0; i < tempLUserWithRole.Count; i++)
                {
                    if (tempLUserWithRole[i].Role_UserWithRole.Name == tempRoleOld)
                        tempLUserWithRole[i].Role_UserWithRole.Name = tempRoleNew;
                }

                Session["ListOfUserWithRole"] = tempLUserWithRole;
            }
            Response.Redirect(Request.RawUrl);
        }

        public List<Role> ListOfRolesChanged
        {
            get
            {
                return ListRolesPgManageRoles;
            }
        }
            

        private void MethodEnabled(bool flag, params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i] is Button)
                    ((Button)obj[i]).Enabled = flag;
                if (obj[i] is TextBox)
                    ((TextBox)obj[i]).Enabled = flag;
            }
        }

        private void MethodVisible(bool flag, params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i] is Button)
                    ((Button)obj[i]).Visible = flag;
                if (obj[i] is TextBox)
                    ((TextBox)obj[i]).Visible = flag;
            }
        }
    }
}