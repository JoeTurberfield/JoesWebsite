using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class RecoverAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isUser = Request["u"] != null ? Convert.ToBoolean(Request["u"]) : false;
                bool isPassword = Request["p"] != null ? Convert.ToBoolean(Request["p"]) : false;

                if (isUser)
                {
                    // Show full name and email to search for account
                    dvRecoverUsername.Visible = true;
                }
                else if (isPassword)
                {
                    // Only admin can do this.
                    if (Security.IsAdmin)
                    {
                        // Provide account name and set new password
                        dvRecoverPassword.Visible = false;
                    }
                    else
                    {
                        // Please contact admin
                    }
                }
            }
            
        }

        protected void btnGetUsername_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text,
            lastName = txtLastName.Text,
            email = txtEmail.Text;

            if(Account.GetForgottenUserName(firstName, lastName, email, out string username, out int responseID, out string responseMessage))
            {
                lblRetreivedUsername.Text = username;
                hypLnkLogin.NavigateUrl = "Login.aspx?u=" + username;
                dvUsernameSuccess.Visible = true;

                lblError.Text = String.Empty;
                lblError.Visible = false;
            }
            else
            {
                dvUsernameSuccess.Visible = false;

                lblError.Text = String.IsNullOrWhiteSpace(responseMessage) ? "An error occured searching for the User. Please check your details and try again or contact " +
                    "the Administrator." : responseMessage;
                lblError.Visible = true;
            }
        }
    }
}