﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eWallet.Inside
{
    public partial class Inside : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Accounts/Login.aspx");
        }
    }
}