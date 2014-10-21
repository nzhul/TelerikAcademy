using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_AllEvents
{
    public partial class index : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            Response.Write("ON INIT invoked" + "<br/>");
            base.OnInit(e);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init invoked" + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender invoked" + "<br/>");
        }

        protected void ButtonDump_Click(object sender, EventArgs e)
        {
            Response.Write("ButtonDump_Click invoked" + "<br/>");
        }

        protected void ButtonDump_Init(object sender, EventArgs e)
        {
            Response.Write("ButtonDump_Init invoked" + "<br/>");
        }

        protected void ButtonDump_Load(object sender, EventArgs e)
        {
            Response.Write("ButtonDump_Load invoked" + "<br/>");
        }

        protected void ButtonDump_PreRender(object sender, EventArgs e)
        {
            Response.Write("ButtonDump_PreRender invoked" + "<br/>");
        }
    }
}