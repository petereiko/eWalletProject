using eWallet.Models;
using eWallet.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                profileId.Value = userProfile.Id.ToString();

                txtFirstname.Value = userProfile.FirstName;
                txtLastname.Value = userProfile.LastName;
                txtPhone.Value = userProfile.Phone;
                txtAddress.Value = userProfile.Address;
                passportContainer.Src = $"../Content/passports/{userProfile.Passport}";

                GenderRadioButtonList.SelectedIndex = (userProfile.Gender == 1) ? 0 : 1;
                StateDropDownList.SelectedIndex = userProfile.StateId;
                btnSubmitProfile.Text = "Update Profile";
                string color = "red";
                if (userProfile.Balance > 5000)
                    color = "green";
                lblBalance.InnerHtml = $"Balance: ₦<span style='color:{color}; font-weight:'bold'>{userProfile.Balance.ToString("N2")}</span>";
            }


        }

        protected void btnSubmitProfile_Click(object sender, EventArgs e)
        {

            HttpPostedFile file = passportFile.PostedFile;
            string uniqueFileName = string.Empty;
            if (file != null)
            {
                string extension = Path.GetExtension(file.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + extension;
                string relativePath = "~/Content/passports/";
                string physicalPath = Server.MapPath(relativePath);
                string fullPath = Path.Combine(physicalPath, uniqueFileName);

                file.SaveAs(fullPath);
            }

            string profileid = profileId.Value;
            Tuple<string, bool> response = null;

            UserProfile profile = new UserProfile
            {
                Address = txtAddress.Value,
                FirstName = txtFirstname.Value,
                Gender = Convert.ToInt32(GenderRadioButtonList.SelectedItem.Value),
                LastName = txtLastname.Value,
                Phone = txtPhone.Value,
                StateId = Convert.ToInt32(StateDropDownList.SelectedItem.Value),
                Passport = uniqueFileName
            };
            if (string.IsNullOrEmpty(profileid))
            {
                response = repository.Create(profile);
            }
            else
            {
                profile.Id = Convert.ToInt32(profileid);
                if (file != null)
                {
                    profile.Passport = uniqueFileName;
                }
                response = repository.Update(profile);
            }


            if (response.Item2)
            {
                lblStatus.InnerHtml = $"<span style='background-color:green'>{response.Item1}</span>";
            }
            else
            {
                if (response.Item1.Contains("User session has timed out"))
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