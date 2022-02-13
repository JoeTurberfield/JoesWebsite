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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetStatusPosts", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    string html = "<div class=\"row mt-4\"><div class=\"col-md-8 status-container\" data-statusid=\"" + row["StatusID"] + "\">"
                                            + "<label class=\"status-username\">" + row["Username"].ToString() + "</label><br />"
                                            + "<label class=\"status-message\">" + row["Status"].ToString() + "</label><br />"
                                            + "<label>Posted on: </label><label class=\"status-date\">" + row["PostedDate"].ToString() + "</label>"
                                            + "<label class=\"status-remove float-right\">Remove</label>"
                                            + "</div></div><hr/>";

                                    dvStatusPost.InnerHtml += html;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string html = "<div class=\"row mt-4\"><div class=\"col-md-8\">"
                                            + "<label class=\"status-username\">An unexpected error occured retrieving posts: " + ex.Message + "</label><br />"
                                            + "</div></div><hr/>";


                dvStatusPost.InnerHtml += html;
            }
        }

        [WebMethod]
        public static Response SaveStatus(string status)
        {
            Response res = new Response();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spPostNewStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserID", Security.CurrentUserID));
                        cmd.Parameters.Add(new SqlParameter("@Status", status));

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                res.ResponseID = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseID"]);
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

            return res;
        }

        [WebMethod]
        public static Response DeleteStatus(int statusID)
        {
            Response res = new Response();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["JoesWebsiteConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spDeleteStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserID", Security.CurrentUserID));
                        cmd.Parameters.Add(new SqlParameter("@StatusID", statusID));

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                res.ResponseID = Convert.ToInt32(ds.Tables[0].Rows[0]["ResponseID"]);
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

            return res;
        }
    }

}