using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["u"] != null)
            {
                txtUsername.Value = Request["u"].ToString();
            }
        }

        [WebMethod]
        public static Response LoginUser(User UserDetails)
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

            if (!isError)
            {
                res = Security.PerformLogin(UserDetails);
            }

            return res;
        }
    }
}