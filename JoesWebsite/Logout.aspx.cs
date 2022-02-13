using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To log user out set user id to null and redirect to login page
            Security.CurrentUserID = null;
            Response.Redirect("/Login.aspx");
        }
    }
}