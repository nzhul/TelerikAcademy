using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_CodeBehind
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelCodeBehind.Text = "This messages comes from codebehind";
            this.LabelLocation.Text = "The current assembly location is: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}