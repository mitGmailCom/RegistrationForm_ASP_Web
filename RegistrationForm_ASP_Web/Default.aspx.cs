using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm_ASP_Web
{
    public partial class Default : System.Web.UI.Page
    {
        //static List<Role> ListStringRole = new List<Role>();
        //static List<ListItem> ListItems = new List<ListItem>();
        string recordId;
        string recordFirstname;
        string recordLastname;
        string recordEmail;
        string recordPassword;
        string recordCity;
        string recordRole;
        string recordListRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Role> ListStringRole = new List<Role>();
            List<ListItem> ListItems = new List<ListItem>();


            if (Request.QueryString["recordId"] != null)
            {
                recordId = Request.QueryString["recordId"];
                recordFirstname = Request.QueryString["recordFirstname"];
                recordLastname = Request.QueryString["recordLastname"];
                recordEmail = Request.QueryString["recordEmail"];
                recordPassword = Request.QueryString["recordPassword"];
                recordCity = Request.QueryString["recordCity"];
                recordRole = Request.QueryString["recordRole"];
                recordListRole = Request.QueryString["recordListRole"];
            }


            if (PreviousPage != null)
            {
                ManageRoles prevPage = new ManageRoles();
                if (ListStringRole.Count == 0)
                {
                    ListStringRole = prevPage.ListOfRolesChanged;
                }
                for (int i = 0; i < ListStringRole.Count; i++)
                {
                    ListItems.Add((new ListItem((ListStringRole[i] as Role).Name)));
                }
            }


            //заполнение массива ListStringRole
            if (ListStringRole.Count == 0 && recordRole == null)
            {
                ListStringRole.AddRange(new Role[] { new Role("guest"), new Role("admin"), new Role("user") });

                for (int i = 0; i < ListStringRole.Count; i++)
                {
                    ListItems.Add((new ListItem((ListStringRole[i] as Role).Name)));
                }
            }


            if (ListStringRole.Count == 0 && recordRole != null)
            {
                ManageRoles prevPage = new ManageRoles();
                if (ListStringRole.Count == 0)
                {
                    string[] tempMasRoles = recordListRole.Split();
                    for (int i = 0; i < tempMasRoles.Length; i++)
                    {
                        ListStringRole.Add(new Role(tempMasRoles[i]));
                    }
                }
                for (int i = 0; i < ListStringRole.Count; i++)
                {
                    ListItems.Add((new ListItem((ListStringRole[i] as Role).Name)));
                }
            }

            drdlRoleUser.Items.AddRange(ListItems.ToArray());

            if (Request.QueryString["err"] != null)
                Page.Validate();

            if (recordId != null)
            {
                txbCityUser.Text = recordCity;
                txbFirstnameUser.Text = recordFirstname;
                txbLastnameUser.Text = recordLastname;
                //txbPasswordUser.TextMode = TextBoxMode.SingleLine;
                txbPasswordUser.Text = recordPassword;
                //txbPasswordUser.Attributes["onfocus"] = $"alert({recordPassword});";
                txbPasswordUser.ToolTip = $"{recordPassword}";
                txbEmailUser.Text = recordEmail;
                drdlRoleUser.ClearSelection();
                drdlRoleUser.Items.FindByText(recordRole).Selected = true;
                HiddenField1.Value = recordId;
            }
        }



        public string FirstName
        {
            get { return txbFirstnameUser.Text; }
        }

        public string LastName
        {
            get { return txbLastnameUser.Text; }
        }

        public string City
        {
            get { return txbCityUser.Text; }
        }

        public string Email
        {
            get { return txbEmailUser.Text; }
        }

        public string Password
        {
            get { return txbPasswordUser.Text; }
        }

        public string RoleUsr
        {
            get { return drdlRoleUser.SelectedItem.Text; }
        }

        public string Id
        {
            get { return recordId; }
        }

        public string HiddenValue
        {
            get { return HiddenField1.Value; }
            set { HiddenField1.Value = value; }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
        }
    }
}