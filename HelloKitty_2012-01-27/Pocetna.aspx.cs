using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pocetna : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["Ulogovani"].ToString() != "")
            {
                if (Session["TipKorisnikaID"].ToString() == "1")
                {
                    Menu m2 = (Menu)Master.FindControl("Menu2");
                    m2.Visible = true;
                }
            }
        }
       
    }
}