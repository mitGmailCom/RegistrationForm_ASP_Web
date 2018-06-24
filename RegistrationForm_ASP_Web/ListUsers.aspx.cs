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
        //static List<UserClass> ListOfUsers = new List<UserClass>() { new UserClass(1, "ivanov@gmail.com", "11111", "Ivan", "Ivanov"), new UserClass(2, "petrov@gmail.com", "11111", "Petr", "Petrovich"), new UserClass(3, "sidorov@gmail.com", "11111", "Semen", "Semenovich") };
        //static CheckBoxList checkBxL = new CheckBoxList();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (ListOfUsersPageListUsers.Count == 0)
                ListOfUsersPageListUsers.AddRange(new UserClass[3] { new UserClass(1, "ivanov@gmail.com", "11111", "Ivan", "Ivanov", "Kiev"), new UserClass(2, "petrov@gmail.com", "11111", "Petr", "Petrovich", "Kiev"), new UserClass(3, "sidorov@gmail.com", "11111", "Semen", "Semenovich", "Kiev") });
            if (ListOfRolePageListUsers.Count == 0)
                ListOfRolePageListUsers.AddRange(new Role[3] { new Role("guest"), new Role("admin"), new Role("user") });
            if (ListOfUserWithRole.Count == 0)
                ListOfUserWithRole.AddRange(new UserWithRole[3] { new UserWithRole(ListOfUsersPageListUsers[0], ListOfRolePageListUsers[0]), new UserWithRole(ListOfUsersPageListUsers[1], ListOfRolePageListUsers[1]), new UserWithRole(ListOfUsersPageListUsers[2], ListOfRolePageListUsers[2]) });


            if (PreviousPage != null)
            {
                if (!PreviousPage.IsValid)
                    Response.Redirect(Request.UrlReferrer.AbsolutePath + "?err=true");



                if (PreviousPage is Default)
                {
                    Default PageWithRegistrUser = PreviousPage as Default;
                    bool ff = PageWithRegistrUser.FlagIsChangeingProfile;
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

                            Role newRoleUser = new Role();
                            newRoleUser.Name = PageWithRegistrUser.RoleUsr;
                            ListOfRolePageListUsers.Add(newRoleUser);

                            UserWithRole CompleteUser = new UserWithRole(newUser, newRoleUser);
                            ListOfUserWithRole.Add(CompleteUser);
                        }

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

                            Role newRoleUser = new Role();
                            newRoleUser.Name = PageWithRegistrUser.RoleUsr;
                            ListOfRolePageListUsers[Convert.ToInt32(PageWithRegistrUser.HiddenValue)] = newRoleUser;

                            UserWithRole CompleteUser = new UserWithRole(newUser, newRoleUser);
                            ListOfUserWithRole[Convert.ToInt32(PageWithRegistrUser.HiddenValue)] = CompleteUser;
                            PageWithRegistrUser.FlagIsChangeingProfile = false;
                            PageWithRegistrUser.HiddenValue = "null";
                        }



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

                    //LinkButton hyperlinkBtn = new LinkButton();
                    //hyperlinkBtn.ID = "HLBtn" + $"{ListOfUsers[i].Email}";
                    //hyperlinkBtn.Text = "Изменить";
                    //hyperlinkBtn.Click += HyperlinkBtn_Click;
                    ////hyperlinkBtn.PostBackUrl = "~/Default.aspx.cs";
                    //this.form1.Controls.Add(hyperlinkBtn);
                    //tableRow_0Col_2.Controls.Add(hyperlinkBtn);
                    //tableRow_0Col_2.Controls.Add();
                    ListItem one = new ListItem();
                    one.Text = "Изменить";
                    BulletedList1.Items.Add(one);

                    //this.form1.Controls.Add(hyperlink);
                }
            }
        }

        //private void HyperlinkBtn_Click(object sender, EventArgs e)
        //{
        //    LinkButton templBtn = new LinkButton();
        //    templBtn = sender as LinkButton;
        //    string recordEmail =  templBtn.ID.Substring(5);
        //    Response.Redirect("Default.aspx?recordEmail=" + recordEmail.ToString());
        //}


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
                recordRole = ListOfRolePageListUsers[res].Name;
                recordCity = ListOfUsersPageListUsers[res].City;
                Response.Redirect("Default.aspx?recordId=" + recordId.ToString() + "&" +
                    "recordFirstname=" + recordFirstname + "&" + "recordLastname=" + recordLastname + "&" +
                    "recordEmail=" + recordEmail + "&" + "recordPassword=" + recordPassword + "&" +
                    "recordRole=" + recordRole + "&" + "recordCity=" + recordCity);
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
                    }
                }
            }
        }

        
    }
}