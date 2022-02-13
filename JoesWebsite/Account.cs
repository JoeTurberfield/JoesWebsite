using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JoesWebsite
{
    public class Account
    {
        public static bool GetForgottenUserName(string firstName, string lastName, string email, out string username, out int responseID, out string responseMessage)
        {
            // Get the username based on Account params
            username = String.Empty;
            responseID = -1;
            responseMessage = String.Empty;

            if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(email))
            {
                responseID = -1;
                responseMessage = "Please make sure all fields are filled out: First Name, Last Name & Email.";
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("spGetUsername", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
                            cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                            cmd.Parameters.Add(new SqlParameter("@Email", email));

                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                sda.Fill(ds);

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    responseID = (int)ds.Tables[0].Rows[0]["ResponseID"];
                                    responseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString();

                                    if (responseID == 0)
                                    {
                                        username = ds.Tables[0].Rows[0]["Username"].ToString();

                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    responseID = -1;
                    responseMessage = "Error: " + ex.Message;
                }
            }

            return false;
        }
    }
}