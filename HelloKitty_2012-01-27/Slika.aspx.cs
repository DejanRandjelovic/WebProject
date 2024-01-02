using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Slika : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProizvodID"] == null)
        {
            Response.Redirect("Pocetna.aspx");
        }

        int proizvodID = Convert.ToInt32(Request.QueryString["ProizvodID"]);

        ProizvodiBLL proizvodiAPI = new ProizvodiBLL();
        OnLineShop.ProizvodiDataTable proizvodi = 
            proizvodiAPI.GetProizvodWithBinaryDataByProizvodID(proizvodID);
        
        OnLineShop.ProizvodiRow proizvod = proizvodi[0];

        // info o binarnim podacima
        Response.ContentType = "image/jpg";

        // posalji binarne podatka
        Response.BinaryWrite(proizvod.MalaSlika);
    }
}