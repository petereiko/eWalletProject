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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserAccountRepository repository = new UserAccountRepository();

            LoginModel model = new LoginModel
            {
                email = txtEmail.Value,
                password = txtPassword.Value
            };

            UserAccount userAccount = repository.Authenticate(model);
            if(userAccount == null)
            {
                lblResult.InnerHtml = "<span style='color:red'>Invalid Email/Password</span>";
                return;
            }

            Session["UserAccount"] = userAccount;
            Response.Redirect("../Inside/Dashboard.aspx");
        }
    }
}