using eWallet.Models;
using eWallet.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eWallet.Inside
{
    public partial class Transaction : System.Web.UI.Page
    {
        ProfileRepository repository = new ProfileRepository();
        TransactionRepository transactionRepository = new TransactionRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserAccount"] == null)
            {
                Response.Redirect("../Accounts/Login.aspx");
            }
            UserAccount userAccount = (UserAccount)Session["UserAccount"];
            int userId = userAccount.Id;

            List<TransactionModel> transactions = transactionRepository.GetAllMyTransaction(userId);

            List<TransactionViewModel> viewModels = new List<TransactionViewModel>();

            foreach (var item in transactions)
            {
                TransactionViewModel view = new TransactionViewModel
                {
                    Amount = item.Amount,
                    DateCreated = item.DateCreated,
                    Id = item.Id
                };
                if (item.Status == 1)
                    view.Status = "Open";
                if (item.Status == 2)
                    view.Status = "Payment Uploaded";
                if (item.Status == 3)
                    view.Status = "Payment Confirmed";
                if (item.Status == 4)
                    view.Status = "Transaction Failed";

                viewModels.Add(view);
            }


            GridViewMyTransactions.DataSource = viewModels;
            GridViewMyTransactions.DataBind();
        }

        protected void btnSell_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = (UserAccount)Session["UserAccount"];



            UserProfile userProfile = repository.GetUserProfileByUserId(userAccount.Id);

            decimal amount = Convert.ToDecimal(txtAmount.Value);

            decimal minimumBalance = Convert.ToDecimal(ConfigurationManager.AppSettings["minimumBalance"]);
            
            if (amount > userProfile.Balance)
            {
                lblSellResponse.InnerHtml = "<span style='color:red'>You have insufficient balance for this transaction</span>";
                sellsection.Visible = true;
                return;
            }
            if ((userProfile.Balance-amount) < minimumBalance)
            {
                lblSellResponse.InnerHtml = "<span style='color:red'>You have insufficient balance for this transaction</span>";
                sellsection.Visible = true;
                return;
            }


            TransactionModel model = new TransactionModel
            {
                Amount = amount,
                BuyerUserId = null,
                DateCreated = DateTime.Now,
                DateUpdated = null,
                Evidence = null,
                InitiatorUserId = userAccount.Id,
                Status = 1
            };

            Tuple<string, bool> response = transactionRepository.Create(model);
            if (response.Item2)
            {
                lblSellResponse.InnerHtml = $"<span style='color:green'>{response.Item1}</span>";

            }
            else
            {
                lblSellResponse.InnerHtml = $"<span style='color:red'>{response.Item1}</span>";
            }

            Page_Load(sender, e);

        }
    }
}