using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace JoesWebsite
{
    public partial class AndrewsGame : System.Web.UI.Page
    {
        // Connect to the web service
        //JoesServiceReference.JoesWebServiceSoapClient joesWS = new JoesServiceReference.JoesWebServiceSoapClient();

        List<int> numbersList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            int number = !String.IsNullOrEmpty(txtFirstNo.Value) ? Convert.ToInt32(txtFirstNo.Value) : 0;
            
            int length = 10;


            for (int i = 0; i < length; i++)
            {               
                if (number > 10)
                {
                    number--;
                }
                else if (number < 1)
                {
                    number++;
                }

                //if (numbersList.Contains(number))
                //{
                //    number++;

                //    //// Do loop again
                //    //i--;
                //    //continue;
                //}

                if (numbersList.Count > 0)
                {
                    int fn = numbersList[i - 1];
                    int sn = numbersList[i];

                    int nextnum = fn - sn;
                    
                    numbersList.Add(nextnum);
                    lblNumbers.InnerText += nextnum.ToString();
                }
                else
                {
                    numbersList.Add(number);
                    lblNumbers.InnerText += number.ToString();
                }

               

                if (i == 0 || i == 2 || i == 5)
                {
                    lblNumbers.InnerText += ",,\n";
                }

                number = 1;
            }

        }


    }

}