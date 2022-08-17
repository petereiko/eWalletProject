using eWallet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace eWallet.Repository
{
    public class UserAccountRepository
    {
        public bool Create(UserAccount model)
        {
            int rowsAffected = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string insertQuery = $"insert into UserAccounts values ('{model.Email}',0,'{model.Password}',0,getdate())";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                using (cmd)
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(UserAccount model)
        {
            int rowsAffected = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                int _emailConfirmed = model.EmailConfirmed ? 1 : 0;
                int _isActive = model.IsActive ? 1 : 0;

                string updateQuery = $"update UserAccounts set Email='{model.Email}', EmailConfirmed={_emailConfirmed}, IsActive={_isActive} where Id={model.Id}";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                using (cmd)
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public UserAccount Get(int id)
        {
            UserAccount userAccount = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.Id, u.Email, u.EmailConfirmed, u.IsActive, u.DateCreated from UserAccounts u where Id={id}";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    userAccount = new UserAccount
                    {
                        DateCreated = Convert.ToDateTime(row["DateCreated"]),
                        Email = row["Email"].ToString(),
                        EmailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        Id = Convert.ToInt32(row["Id"])
                    };
                }

                return userAccount;

            }
        }

        public UserAccount GetUserByEmail(string email)
        {
            UserAccount userAccount = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.Id, u.Email, u.EmailConfirmed, u.IsActive, u.DateCreated from UserAccounts u where Email='{email}'";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    userAccount = new UserAccount
                    {
                        DateCreated = Convert.ToDateTime(row["DateCreated"]),
                        Email = row["Email"].ToString(),
                        EmailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        Id = Convert.ToInt32(row["Id"])
                    };
                }

                return userAccount;

            }
        }

        public bool EmailExists(string email)
        {
            bool status = false;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.Id, u.Email, u.EmailConfirmed, u.IsActive, u.DateCreated from UserAccounts u where Email='{email}'";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    status = true;
                }
                return status;

            }
        }

        public bool SendEmail(string email)
        {
            bool isSent = false;
            //Send email via SMTP.
            SmtpClient Client = new SmtpClient()
            {
                //Using GMail SMTP
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "peterjolomisan@gmail.com", //Returns valid Gmail address.
                    Password = "gmail@securityr&d1984"  //Password to access email above. 
                }
            };

            MailAddress FromeMail = new MailAddress("peterjolomisan@gmail.com", "From");
            MailAddress ToeMail = new MailAddress(email, "To");

            string body = $"<h3>Dear User,</h3>";
            body += "<div>Please click the link provided to activate your account</div>";
            body += $"<a href='https://localhost:44323/Accounts/Confirmation.aspx?token={email}'>Click here</a>";

            MailMessage Message = new MailMessage()
            {
                From = FromeMail,
                Subject = "Account Creation",
                Body = body,
                IsBodyHtml = true
            };

            Message.To.Add(ToeMail);

            try
            {
                Client.Send(Message);
                isSent = true;
            }
            catch (Exception ex)
            {
                isSent = false;
            }
            return isSent;
        }

        public List<UserAccount> GetAll()
        {
            List<UserAccount> userAccounts = new List<UserAccount>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.Id, u.Email, u.EmailConfirmed, u.IsActive, u.DateCreated from UserAccounts u";
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
                        UserAccount userAccount = new UserAccount
                        {
                            DateCreated = Convert.ToDateTime(row["DateCreated"]),
                            Email = row["Email"].ToString(),
                            EmailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Id = Convert.ToInt32(row["Id"])
                        };

                        userAccounts.Add(userAccount);
                    }

                }

                return userAccounts;

            }
        }

        public UserAccount Authenticate(LoginModel model)
        {
            UserAccount userAccount = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.Id, u.Email, u.EmailConfirmed, u.IsActive, u.DateCreated from UserAccounts u where Email='{model.email}' and Password='{model.password}'";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    userAccount = new UserAccount
                    {
                        DateCreated = Convert.ToDateTime(row["DateCreated"]),
                        Email = row["Email"].ToString(),
                        EmailConfirmed = Convert.ToBoolean(row["EmailConfirmed"]),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        Id = Convert.ToInt32(row["Id"])
                    };
                }

                return userAccount;

            }
        }
    }
}