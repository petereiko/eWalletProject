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
    public class ProfileRepository
    {
        public DataTable GetAllStates()
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select s.Id, s.Name from States s";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                return table;
            }
        }

        public Tuple<string, bool> Create(UserProfile model)
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
                string insertQuery = $"insert into UserProfiles values ('{model.FirstName}','{model.LastName}',{model.Gender},'{model.Phone}','{model.Address}',{model.StateId},20000,{userAccount.Id},getdate(),NULL,1)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                using (cmd)
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
            {
                return new Tuple<string, bool>("Profile has been created successfully.", true);
            }
            return new Tuple<string, bool>("An error occurred while trying to create your profile.", false);
            
        }

        public UserProfile GetUserProfileByUserId(int userId)
        {
            UserProfile userProfile = null;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            using (conn)
            {
                string selectQuery = $"select u.FirstName, u.LastName, u.Gender, u.Phone, u.[Address], u.StateId from userprofiles u where UserId={userId}";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable table = new DataTable();
                using (da)
                {
                    da.Fill(table);
                }
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
                    userProfile = new UserProfile
                    {
                        Address = row["Address"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Gender = Convert.ToInt32(row["Gender"]),
                        Phone = row["Phone"].ToString(),
                        StateId = Convert.ToInt32(row["StateId"])
                    };
                }

                return userProfile;

            }
        }
    }
}