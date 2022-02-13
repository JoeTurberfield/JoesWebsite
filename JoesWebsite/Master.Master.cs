using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected bool IsAdmin = Security.IsAdmin;
        protected void Pre_Init(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Security.IsLoggedIn)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        
    }
}