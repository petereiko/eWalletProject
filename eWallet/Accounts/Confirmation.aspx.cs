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
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["token"] == null)
            {
                Response.Redirect("Register.aspx");
            }
            string emailAddress = Request.QueryString["token"].ToString();

            UserAccountRepository repository = new UserAccountRepository();

            UserAccount model = repository.GetUserByEmail(emailAddress);

            model.IsActive = true;
            model.EmailConfirmed = true;

            bool isUpdated = repository.Update(model);
            if (isUpdated)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }
    }
}