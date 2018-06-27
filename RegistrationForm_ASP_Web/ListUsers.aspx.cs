using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm_ASP_Web
{
    public partial class ListUsers : System.Web.UI.Page
    {
        private static List<UserClass> ListOfUsersPageListUsers = new List<UserClass>();
        private static List<Role> ListOfRolePageListUsers = new List<Role>();
        private static List<UserWithRole> ListOfUserWithRole = new List<UserWithRole>();
        private static Role currentRole = new Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListOfUserWithRole"] != null)
                ListOfUserWithRole = (List<UserWithRole>)Session["ListOfUserWithRole"];

            if (ListOfUsersPageListUsers.Count == 0)
                ListOfUsersPageListUsers.AddRange(new UserClass[3] { new UserClass(1, "ivanov@gmail.com", "11111", "Ivan", "Ivanov", "Kiev"), new UserClass(2, "petrov@gmail.com", "11111", "Petr", "Petrovich", "Kiev"), new UserClass(3, "sidorov@gmail.com", "11111", "Semen", "Semenovich", "Kiev") });
            if (ListOfRolePageListUsers.Count == 0)
                ListOfRolePageListUsers.AddRange(new Role[3] { new Role("guest"), new Role("admin"), new Role("user") });
            if (ListOfUserWithRole.Count == 0)
            {
                ListOfUserWithRole.AddRange(new UserWithRole[3] { new UserWithRole(ListOfUsersPageListUsers[0], ListOfRolePageListUsers[0]), new UserWithRole(ListOfUsersPageListUsers[1], ListOfRolePageListUsers[1]), new UserWithRole(ListOfUsersPageListUsers[2], ListOfRolePageListUsers[2]) });
                Session["ListOfUserWithRole"] = ListOfUserWithRole;
            }
            

            if (PreviousPage != null)
            {
                if (!PreviousPage.IsValid)
                    Response.Redirect(Request.UrlReferrer.AbsolutePath + "?err=true");


                if (PreviousPage is Default)
                {
                    Default PageWithRegistrUser = PreviousPage as Default;
                    if (PageWithRegistrUser != null)
                    {
                        if (PageWithRegistrUser.HiddenValue == "null")
                        {
                            UserClass newUser = new UserClass();
                            newUser.Email = PageWithRegistrUser.Email;
                            newUser.Password = PageWithRegistrUser.Password;
                            newUser.FirstName = PageWithRegistrUser.FirstName;
                            newUser.LastName = PageWithRegistrUser.LastName;
                            newUser.Id = ListOfUsersPageListUsers.Count+1;
                            newUser.City = PageWithRegistrUser.City;
                            ListOfUsersPageListUsers.Add(newUser);

                            UserWithRole CompleteUser = new UserWithRole(newUser, new Role(PageWithRegistrUser.RoleUsr));
                            ListOfUserWithRole.Add(CompleteUser);

                            Session["ListOfUserWithRole"] = ListOfUserWithRole;
                        }

                        // записываем новые значения при передаче данных через Button(используя свойства)
                        if (PageWithRegistrUser.HiddenValue != "null")
                        {
                            UserClass newUser = new UserClass();
                            newUser.Email = PageWithRegistrUser.Email;
                            newUser.Password = PageWithRegistrUser.Password;
                            newUser.FirstName = PageWithRegistrUser.FirstName;
                            newUser.LastName = PageWithRegistrUser.LastName;
                            newUser.Id = Convert.ToInt32(PageWithRegistrUser.HiddenValue);
                            newUser.City = PageWithRegistrUser.City;
                            ListOfUsersPageListUsers[Convert.ToInt32(PageWithRegistrUser.HiddenValue)] = newUser;
                          
                            UserWithRole CompleteUser = new UserWithRole(newUser, new Role(PageWithRegistrUser.RoleUsr));
                            ListOfUserWithRole[Convert.ToInt32(PageWithRegistrUser.HiddenValue)] = CompleteUser;
                            PageWithRegistrUser.HiddenValue = "null";

                            Session["ListOfUserWithRole"] = ListOfUserWithRole;
                        }

                        // заполнение выпадающего списка Пользователями
                        CheckBoxListUsers.Items.Clear();
                        for (int i = 0; i < ListOfUsersPageListUsers.Count; i++)
                        {
                            CheckBoxListUsers.Items.Add(ListOfUsersPageListUsers[i].Email.ToString());
                            ListItem one = new ListItem();
                            one.Text = "Изменить";
                            BulletedList1.Items.Add(one);
                        }
                    }
                }
            }

            // Заполнение CheckBoxListUsers при загрузки страницы
            if (CheckBoxListUsers.Items.Count == 0)
            {
                CheckBoxListUsers.Items.Clear();
                for (int i = 0; i < ListOfUsersPageListUsers.Count; i++)
                {
                    CheckBoxListUsers.Items.Add(ListOfUsersPageListUsers[i].Email.ToString());
                    ListItem one = new ListItem();
                    one.Text = "Изменить";
                    BulletedList1.Items.Add(one);
                }
            }
        }


        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {
            string recordId = null;
            string recordFirstname = null;
            string recordLastname = null;
            string recordEmail = null;
            string recordPassword = null;
            string recordCity = null;
            string recordRole = null;
            int res = 0;

            recordId = e.Index.ToString();
            bool result = Int32.TryParse(recordId, out res);

            if (result)
            {
                recordFirstname = ListOfUsersPageListUsers[res].FirstName;
                recordLastname = ListOfUsersPageListUsers[res].LastName;
                recordEmail = ListOfUsersPageListUsers[res].Email;
                recordPassword = ListOfUsersPageListUsers[res].Password;
                recordRole = ListOfUserWithRole[res].Role_UserWithRole.Name;
                recordCity = ListOfUsersPageListUsers[res].City;

                string tt = null;
                for (int i = 0; i < ListOfRolePageListUsers.Count; i++)
                {
                    if (i == ListOfRolePageListUsers.Count-1)
                    {
                        tt += ListOfRolePageListUsers[i].Name;
                        break;
                    }
                    tt += ListOfRolePageListUsers[i].Name + " ";
                }

                Response.Redirect("Default.aspx?recordId=" + recordId.ToString() + "&" +
                    "recordFirstname=" + recordFirstname + "&" + "recordLastname=" + recordLastname + "&" +
                    "recordEmail=" + recordEmail + "&" + "recordPassword=" + recordPassword + "&" +
                    "recordRole=" + recordRole + "&" + "recordCity=" + recordCity + "&" + "recordListRole=" + tt);
            }

            if (!result)
            {
                Response.Redirect("Default.aspx?recordId=" + recordId.ToString());
            }
        }


        protected void DelUsers_Click(object sender, EventArgs e)
        {
            List<ListItem> listItemsSelected = new List<ListItem>();
            for (int i = 0; i < CheckBoxListUsers.Items.Count; i++)
            {
                if ((CheckBoxListUsers.Items[i] as ListItem).Selected)
                    listItemsSelected.Add((CheckBoxListUsers.Items[i] as ListItem));
            }

            for (int i = 0; i < CheckBoxListUsers.Items.Count; i++)
            {
                for (int j = 0; j < listItemsSelected.Count; j++)
                {
                    if (CheckBoxListUsers.Items[i] as ListItem == listItemsSelected[j])
                    {
                        CheckBoxListUsers.Items.RemoveAt(i);
                        ListOfUsersPageListUsers.RemoveAt(i);
                        ListOfRolePageListUsers.RemoveAt(i);
                        ListOfUserWithRole.RemoveAt(i);
                        BulletedList1.Items.RemoveAt(i);

                        Session["ListOfUserWithRole"] = ListOfUserWithRole;
                    }
                }
            }
        }

        protected void CheckBoxListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxListUsers.SelectedItem != null)
                btnDelUsers.Enabled = true;
            if (CheckBoxListUsers.SelectedItem == null)
                btnDelUsers.Enabled = false;

        }

        public List<Role> ListRolesFormPgListUsers
        {
            get
            {
                return ListOfRolePageListUsers;
            }
            set
            {
                ListRolesFormPgListUsers = value;
            }
        }
    }
}