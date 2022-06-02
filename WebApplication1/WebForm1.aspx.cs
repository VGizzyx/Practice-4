using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            GridView3.DataSource = client.GetCustomers();
            GridView3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView3.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView3.Visible = false;
        }


        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(GridView3.SelectedRow.Cells[1].Text);
            ServiceReference1.Service1Client order = new ServiceReference1.Service1Client();
            GridView2.DataSource = order.GetOrders(id);
            GridView2.DataBind();
        }
    }
}