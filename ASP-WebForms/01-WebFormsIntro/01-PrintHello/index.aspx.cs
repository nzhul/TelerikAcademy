using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_PrintHello
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonHello_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            string greetingText = "Hello, " + name;
            this.LabelGreeting.Text = greetingText;
        }
    }
}