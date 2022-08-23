using eWallet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eWallet.Repository
{
    public class TransactionRepository
    {
        public Tuple<string, bool> Create(TransactionModel model)
        {
            if (HttpContext.Current.Session["UserAccount"] == null)
            {
                return new Tuple<string, bool>("User session has timed out", false);
            }

            UserAccount userAccount = (UserAccount)HttpContext.Current.Session["UserAccount"];

            int rowsAffected = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string insertQuery = $"insert into Transactions values ({model.InitiatorUserId},{model.Amount},NULL,NULL,1,getdate(),NULL)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                using (cmd)
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
            {
                return new Tuple<string, bool>("Your order has been created successfully.", true);
            }
            return new Tuple<string, bool>("An error occurred while trying to create your profile.", false);

        }

        public List<TransactionModel> GetAllMyTransaction(int userId)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select s.Id, s.Amount, s.DateCreated, s.Status from Transactions s where InitiatorUserId={userId}";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        TransactionModel model = new TransactionModel
                        {
                            Amount = Convert.ToDecimal(row["Amount"]),
                            Id = Convert.ToInt64(row["Id"]),
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            Status = Convert.ToInt32(row["Status"])
                        };

                        transactions.Add(model);
                    }
                }
            }
            return transactions;
        }
    }
}