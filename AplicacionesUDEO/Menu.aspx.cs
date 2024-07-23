using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionesUDEO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RediCalc_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calculator.aspx");
        }

        protected void RediProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("CRUD.aspx");
        }

        //IE1

    }
}