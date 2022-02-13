using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JoesWebsite
{
    public class Security
    {
        public static int? CurrentUserID;
        public static bool IsLoggedIn
        {
            get
            {
                return CurrentUserID > 0;
            }
        }
        public static int PermissionID;
        public static bool IsAdmin
        {
            get
            {
                return PermissionID == 1;
            }
        }

        public static Response PerformLogin(User UserDetails)
        {
            Response res = new Response();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spLoginUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Username", UserDetails.Username));
                        cmd.Parameters.Add(new SqlParameter("@Password", UserDetails.Password));

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                res.ResponseID = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseID"]);
                                res.ResponseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString();
                                if (res.ResponseID == 0)
                                {
                                    CurrentUserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                                    PermissionID = Convert.ToInt32(ds.Tables[0].Rows[0]["PermissionID"]);
                                }                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.ResponseID = -1;
                res.ResponseMessage = "Error: " + ex.Message;
            }
            return res;
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }


}