using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Security.IsAdmin)
            {
                Response.Redirect("/Index.aspx");
            }
        }

        [WebMethod]
        public static Response CreateNewUser(User UserDetails)
        {
            Response res = new Response();
            bool isError = false;
            res.ResponseID = -1;

            if (String.IsNullOrWhiteSpace(UserDetails.Username))
            {
                isError = true;
                res.ResponseMessage += "Please enter a username<br/>";
            }
            if (String.IsNullOrWhiteSpace(UserDetails.Password))
            {
                isError = true;
                res.ResponseMessage += "Please enter a password<br/>";
            }
            if (String.IsNullOrWhiteSpace(UserDetails.ConfirmPassword))
            {
                isError = true;
                res.ResponseMessage += "Please enter a confirm password<br/>";
            }
            if (UserDetails.Password != UserDetails.ConfirmPassword)
            {
                isError = true;
                res.ResponseMessage += "Passwords do not match<br/>";
            }

            if(!isError)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spCreateNewUser", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Username", UserDetails.Username));
                            cmd.Parameters.Add(new SqlParameter("@Password", UserDetails.Password));
                            cmd.Parameters.Add(new SqlParameter("@ConfirmPassword", UserDetails.ConfirmPassword));

                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                sda.Fill(ds);

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    res.ResponseID = Convert.ToInt32(ds.Tables[0].Rows[0]["Response"]);
                                    res.ResponseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString();
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
            }

            return res;
        }
    }


}