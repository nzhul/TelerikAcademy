using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_HtmlEscaping
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonDisplay_Click(object sender, EventArgs e)
        {
            string userInput = this.TextBoxInput.Text;
            string escapedText = this.Server.HtmlEncode(userInput);
            this.TextBoxResult.Text = escapedText;
        }
    }
}