using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PregledPorudzbina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["TipKorisnikaID"].ToString() == "1")
            {
                LabelPoruka.Text = "Dobrodosli na pregled porudzbina:" + Session["Ulogovani"].ToString();

                Menu m2 = (Menu)Master.FindControl("Menu2");
                m2.Visible = true;

            }
            else
            {
                Response.Redirect("Logovanje.aspx");
            }
        }        
    }
}