using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

public partial class AzuriranjeKategorija : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    // metoda koja puni listu sa kategorijama
    private void napuniListuKategorija()
    {
        ddlKategorija.Items.Clear();
        ddlKategorija.Items.Add("-Odaberi Kategoriju-");

        string selectKategorija = "SELECT * FROM Kategorije";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectKategorija, con);
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem novaStavka = new ListItem();
                novaStavka.Text = reader["NazivKategorije"].ToString();
                novaStavka.Value = reader["KategorijaID"].ToString();
                ddlKategorija.Items.Add(novaStavka);
            }
            reader.Close();
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri citanju!";
            litRezultat.Text += xcp.Message;
        }
        finally
        {         
            con.Close();
        }

    }


    // metoda koja prikazuje podatke o prozvodima za zadati ID proizvoda 
    private void prikaziKategorije(int id)
    {
        string selectSQL =
            "SELECT * FROM Kategorije WHERE KategorijaID=@KategorijaID";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@KategorijaID", id);

        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // napuni kontrole
            tboxIDKategorije.Text = reader["KategorijaID"].ToString();
            tboxNazivKategorije.Text = reader["NazivKategorije"].ToString();
            tboxOpisKategorije.Text = reader["OpisKategorije"].ToString();

            reader.Close();
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri citanju!";
            litRezultat.Text += xcp.Message;
        }
        finally
        {
            con.Close();
        }

    }

    #region INSERT,UPDATE,DELETE

    //meteoda koja upisuje Kategoriju
    private int upisiKategoriju()
    {
        // koristimo Stored Procedure iz baze UbaciKategoriju
        string insertSQL = "sp_UbaciKategoriju";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivKategorije", SqlDbType.NVarChar, 50);
        SqlParameter param2 =
            new SqlParameter("@OpisKategorije", SqlDbType.NVarChar, 4000);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivKategorije.Text;
        param2.Value = tboxOpisKategorije.Text;


        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param3 =
            new SqlParameter("@KategorijaID", SqlDbType.Int);
        param3.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param3);

        int dodato = 0;
        int ID = 0;
        // izvrsi komandu
        try
        {
            con.Open();
            dodato = cmd.ExecuteNonQuery();

            // iscitavamo parametar koga nam je prosledila baza
            ID = Convert.ToInt32(param3.Value);
            litRezultat.Text =
                "ID upravo ubacene kategorije je: " + ID.ToString();

            
            return ID;
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri upisu: " + xcp.ToString();
            return -1;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }


    // metoda koja vrsi izmene kategorija
    private void izmeniKategoriju(int id)
    {

        // koristimo Stored Procedure iz baze IzmeniKategoriju
        string updateSQL = "sp_IzmeniKategoriju";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(updateSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivKategorije", SqlDbType.NVarChar, 50);
        SqlParameter param2 =
            new SqlParameter("@OpisKategorije", SqlDbType.NVarChar, 4000);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivKategorije.Text;
        param2.Value = tboxOpisKategorije.Text;

        SqlParameter param3 =
            new SqlParameter("@KategorijaID", SqlDbType.Int);
        cmd.Parameters.Add(param3);

        // id citamo iz ddlKategorija
        param3.Value = ddlKategorija.SelectedValue;

        // izvrsi komandu
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            litRezultat.Text =
                "Kategorija je update-ovana";
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri update-u: " + xcp.ToString();
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }



    // metoda bise Kategoriju za zadati id
    private void obrisiKategoriju(int id)
    {
        // koristimo proceduru iz baze
        string deleteSQL = "sp_ObrisiKategoriju";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(deleteSQL, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("KategorijaID", ddlKategorija.SelectedItem.Value);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            litRezultat.Text = "Zapis je obrisan iz baze.";
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri brisanju kategorije! " + xcp.ToString();
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }

    #endregion

    // metoda resetuje kontrole na formi
    private void resetujKontrole()
    {
        ddlKategorija.SelectedIndex = -1;
        tboxIDKategorije.Text = "";
        tboxNazivKategorije.Text = "";
        tboxOpisKategorije.Text = "";
        litRezultat.Text = "";
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)

        {
           if (Session["TipKorisnikaID"].ToString()=="1")
           {

               Menu m2 = (Menu)Master.FindControl("Menu2");
               m2.Visible = true;

               napuniListuKategorija();
           }
           else
           {
               Response.Redirect("Logovanje.aspx");
           }
        }
    }


    protected void ddlKategorija_SelectedIndexChanged(object sender, EventArgs e)
    {
        litRezultat.Text = "";

        if (ddlKategorija.SelectedValue == null)
        {
            litRezultat.Text = "Odaberite kategoriju iz padajuce liste.";
            return;
        }
        prikaziKategorije(Convert.ToInt32(ddlKategorija.SelectedValue));
    }


    protected void btnUbaciKategoriju_Click(object sender, EventArgs e)
    {
        int katID = upisiKategoriju();

        // ako je insert bio uspesan
        if (katID > 0)
        {
            napuniListuKategorija();
            prikaziKategorije(katID);
            ddlKategorija.SelectedValue = katID.ToString();
        }
    }


    protected void btnPromeniKategoriju_Click(object sender, EventArgs e)
    {
        int katID = Convert.ToInt32(ddlKategorija.SelectedValue);
        izmeniKategoriju(katID);
        napuniListuKategorija();
        ddlKategorija.SelectedValue = katID.ToString();
    }


    protected void btnObrisiKategoriju_Click(object sender, EventArgs e)
    {
        int katID = Convert.ToInt32(ddlKategorija.SelectedValue);
        obrisiKategoriju(katID);
        napuniListuKategorija();
        resetujKontrole();
    }


    protected void btnResetujPolja_Click(object sender, EventArgs e)
    {
        resetujKontrole();
    }

}