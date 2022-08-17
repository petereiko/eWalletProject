using eWallet.Models;
using eWallet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eWallet.Accounts
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            UserAccountRepository repository = new UserAccountRepository();

            UserAccount model = new UserAccount
            {
                DateCreated = DateTime.Now,
                Email = txtEmail.Value,
                EmailConfirmed = false,
                IsActive = false,
                Password = txtPassword.Value
            };

            bool emailExists = repository.EmailExists(txtEmail.Value);

            if (emailExists)
            {
                lblResult.InnerHtml = "<span style='color:red'>The email address has been registered.</span>";
                return;
            }
            bool status = repository.Create(model);

            if (status)
            {
                string body = $"<h3>Dear User,</h3>";
                body += "<div>Please click the link provided to activate your account</div>";
                body += $"<a href='https://localhost:44323/Accounts/Confirmation.aspx?token={txtEmail.Value}'>Click here</a>";



                lblResult.InnerHtml = body;
                lblResult.Style.Add("color", "white");


                //bool isSent = repository.SendEmail(txtEmail.Value);
                //if (isSent)
                //{
                //    lblResult.InnerHtml = "<span style='color:white'>Your profile has been created successfully! Please check your registered email address to confirm your account.</span>";
                //}
                //else
                //{

                //}
            }
            else
            {
                lblResult.InnerHtml = "<span style='color:red'>An error occurred while trying to create your account. Please contact the Administrators!</span>";
            }
        }
    }
}