using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Zabranjeno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Zabranjeno"] != null)
        {
            HttpCookie obj = Request.Cookies["Zabranjeno"];
            lblPorukaIP.Text = "Vaša IP adresa je: " + obj["nemaPravo"].ToString();
        }
    }
}