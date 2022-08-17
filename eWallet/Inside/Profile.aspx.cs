using eWallet.Models;
using eWallet.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eWallet.Inside
{
    public partial class Profile : System.Web.UI.Page
    {
        ProfileRepository repository = new ProfileRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable stateDataTable = repository.GetAllStates();

                StateDropDownList.DataSource = stateDataTable;
                StateDropDownList.DataTextField = "Name";
                StateDropDownList.DataValueField = "Id";

                StateDropDownList.DataBind();

                ListItem listItem = new ListItem
                {
                    Text = "Select State",
                    Value = ""
                };
                StateDropDownList.Items.Insert(0, listItem);

            }


            if (Session["UserAccount"] == null)
            {
                Response.Redirect("../Accounts/Login.aspx");
            }

            UserAccount userAccount = (UserAccount)Session["UserAccount"];



            UserProfile userProfile = repository.GetUserProfileByUserId(userAccount.Id);
            if (userProfile != null)
            {
                txtFirstname.Value = userProfile.FirstName;
                txtLastname.Value = userProfile.LastName;
                txtPhone.Value = userProfile.Phone;
                txtAddress.Value = userProfile.Address;


                GenderRadioButtonList.SelectedIndex = (userProfile.Gender == 1) ? 0 : 1;
                StateDropDownList.SelectedIndex = userProfile.StateId;
                btnSubmitProfile.Text = "Update Profile";
            }

            
        }

        protected void btnSubmitProfile_Click(object sender, EventArgs e)
        {
            

            UserProfile profile = new UserProfile
            {
                Address = txtAddress.Value,
                FirstName = txtFirstname.Value,
                Gender = Convert.ToInt32(GenderRadioButtonList.SelectedItem.Value),
                LastName = txtLastname.Value,
                Phone = txtPhone.Value,
                StateId = Convert.ToInt32(StateDropDownList.SelectedItem.Value)
            };

            Tuple<string,bool> response = repository.Create(profile);
            if (response.Item2)
            {
                lblStatus.InnerHtml = $"<span style='background-color:green'>{response.Item1}</span>";
            }
            else
            {
                if(response.Item1.Contains("User session has timed out"))
                {
                    Response.Redirect("../Accounts/Login.aspx");
                }
                else
                {
                    lblStatus.InnerHtml = $"<span style='background-color:red'>{response.Item1}</span>";
                }
            }
        }
    }
}