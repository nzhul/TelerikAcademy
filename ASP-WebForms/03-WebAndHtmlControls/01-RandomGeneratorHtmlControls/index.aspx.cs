using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_RandomGeneratorHtmlControls
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.TextBoxFrom.Value);
                int to = int.Parse(this.TextBoxTo.Value);
                Random rand = new Random();
                int theNumber = rand.Next(from, to + 1);
                this.LabelRandomNumberResult.InnerText = theNumber.ToString();
            }
            catch (Exception ex)
            {
                this.LabelRandomNumberResult.InnerText = ex.Message;
            }
        }
    }
}