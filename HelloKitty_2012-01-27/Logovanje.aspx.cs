using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

public partial class Logovanje : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["brojPokusaja"]=0;
        }
    }

    // metoda za pronalazenje kupca iz baze
    private int nadjiKupca()
    {
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("sp_NadjiKupca", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter param1 = new SqlParameter("@KorisnickoIme", SqlDbType.NVarChar, 20);
        SqlParameter param2 = new SqlParameter("@Sifra", SqlDbType.NVarChar, 50);

        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter("@KupacID", SqlDbType.Int);
        param3.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param3);

        SqlParameter param4 = new SqlParameter("@TipKorisnikaID", SqlDbType.Int);
        param4.Direction = ParameterDirection.Output;        
        cmd.Parameters.Add(param4);

        try
        {
            param1.Value = tboxKorisnickoIme.Text;
            param2.Value = tboxSifra.Text;

            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception xcp)
        {

            lblGreska.Text = "Greska pri konekciji na bazu: " + xcp.Message;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

        int kupacId = Convert.ToInt32(param3.Value);

        // lblGreska.Text="Ovde smo: "+ kupacId.ToString();

        // ako vrati ID kupca da je > 0 postoji korisnik u bazi
        if (kupacId > 0)
        {
            Session["Ulogovani"] = param1.Value;
            Session["Password"] = param2.Value;
            Session["UserID"] = param3.Value;
            Session["TipKorisnikaID"]= param4.Value;

        }

        return kupacId;
    }

    protected void btnLogujSe_Click(object sender, EventArgs e)
    {

        int kupacID = nadjiKupca();

        // ako procitani ID > 0 postoji korisnik u bazi
        if (kupacID > 0)
        {          
            FormsAuthentication.RedirectFromLoginPage(tboxKorisnickoIme.Text, cbZapamtiMe.Checked);         
        }
        else
        {
            ViewState["brojPokusaja"] = Convert.ToInt32(ViewState["brojPokusaja"])+1;
            lblGreska.Text = "Pogresno korisnicko ime ili sifra. Neuspešan pokušaj broj: " +
                ViewState["brojPokusaja"].ToString();
            if (Convert.ToInt32(ViewState["brojPokusaja"])>2)
            {
                HttpCookie zab = new HttpCookie("Zabranjeno");
                zab["nemaPravo"] = Request.UserHostAddress;
                zab.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Add(zab);
                Server.Transfer("Zabranjeno.aspx");
            }

        }


    }
}