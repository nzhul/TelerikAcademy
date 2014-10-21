using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_RandomGeneratorWebControls
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.TextBoxFrom.Text);
                int to = int.Parse(this.TextBoxTo.Text);
                Random rand = new Random();
                int theNumber = rand.Next(from, to + 1);
                this.LabelRandomNumberResult.Text = theNumber.ToString();
            }
            catch (Exception ex)
            {
                this.LabelRandomNumberResult.Text = ex.Message;
            }
        }
    }
}