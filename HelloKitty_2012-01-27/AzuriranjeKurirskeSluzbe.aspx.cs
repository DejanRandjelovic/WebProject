using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AzurianjeKurirskeSluzbe : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    // metoda koja puni listu sa Kurirskim sluzbama
    private void napuniKurirskuSluzbu()
    {
        ddlKurirskaSluzba.Items.Clear();
        ddlKurirskaSluzba.Items.Add("-Odaberi Kurirsku-");

        string selectKurirska = "SELECT * FROM KurirskaSluzba";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectKurirska, con);
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem novaStavka = new ListItem();
                novaStavka.Text = reader["NazivFirme"].ToString();
                novaStavka.Value = reader["KurirID"].ToString();
                ddlKurirskaSluzba.Items.Add(novaStavka);
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
            // zatvaramo konekciju
            con.Close();
        }



    }


    // metoda koja prikazuje podatke o prozvodima za zadati ID Kurirske sluzbe
    private void prikaziKurirskuSluzbu(int id)
    {
        string selectSQL =
            "SELECT * FROM KurirskaSluzba WHERE KurirID=@KurirID";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@KurirID", id);

        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // napuni kontrole
            tboxIDKurirske.Text= reader["KurirID"].ToString();
            tboxNazivFirme.Text = reader["NazivFirme"].ToString();
            tboxTelefon.Text= reader["Telefon"].ToString();

            reader.Close();
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri citanju!";
            litRezultat.Text += xcp.Message;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

    }

    // metoda resetuje kontrole na formi
    private void resetujKontrole()
    {
        ddlKurirskaSluzba.SelectedIndex = -1;
        tboxIDKurirske.Text = "";
        tboxNazivFirme.Text = "";
        tboxTelefon.Text = "";
        litRezultat.Text = "";
    }

    #region INSERT,UPDATE,DELETE

    //meteoda koja upisuje kurirsku sluzbu
    private int upisiKurirskuSluzbu()
    {
        // koristimo Stored Procedure iz baze UbaciKurirskuSluzbu
        string insertSQL = "sp_UbaciKurirskuSluzbu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivFirme", SqlDbType.NVarChar, 50);
        SqlParameter param2 =
            new SqlParameter("@Telefon", SqlDbType.NChar,20);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivFirme.Text;
        param2.Value = tboxTelefon.Text;


        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param3 =
            new SqlParameter("@KurirID", SqlDbType.Int);
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
                "ID upravo ubacene kurirske sluzbe je: " + ID.ToString();
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

    // metoda koja vrsi izmene poreskih stopa
    private void izmeniKurirskuSluzbu(int id)
    {

        // koristimo Stored Procedure iz baze IzmeniKurirskuSluzbu
        string insertSQL = "sp_IzmeniKurirskuSluzbu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivFirme", SqlDbType.NVarChar, 50);
        SqlParameter param2 =
            new SqlParameter("@Telefon", SqlDbType.NChar,20);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivFirme.Text;
        param2.Value = tboxTelefon.Text;

        SqlParameter param3 =
            new SqlParameter("@KurirID", SqlDbType.Int);
        cmd.Parameters.Add(param3);

        // id citamo iz ddlPoreskaStopa
        param3.Value = ddlKurirskaSluzba.SelectedValue;

        // izvrsi komandu
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            litRezultat.Text =
                "Kurirska sluzba je update-ovana";

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


    // metoda brise kurirsku sluzbu za zadati id
    private void obrisiKurirskuSluzbu(int id)
    {
        // koristimo proceduru iz baze
        string deleteSQL = "sp_ObrisiKurirskuSluzbu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(deleteSQL, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("KurirID", ddlKurirskaSluzba.SelectedItem.Value);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            litRezultat.Text = "Zapis je obrisan iz baze.";
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri brisanju kurirske sluzbe! " + xcp.ToString();
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }


    }

    #endregion

    // load procedura strane
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["TipKorisnikaID"].ToString() == "1")
            {
                Menu m2 = (Menu)Master.FindControl("Menu2");
                m2.Visible = true;

                napuniKurirskuSluzbu();
            }
            else
            {
                Response.Redirect("Logovanje.aspx");
            }
        }
    }

    // event hendler za drop down listu
    protected void ddlKurirskaSluzba_SelectedIndexChanged(object sender, EventArgs e)
    {
        litRezultat.Text = "";

        if (ddlKurirskaSluzba.SelectedIndex == 0)
        {
            litRezultat.Text = "Odaberite Kurirsku sluzbu iz padajuce liste.";
            return;
        }
        prikaziKurirskuSluzbu(Convert.ToInt32(ddlKurirskaSluzba.SelectedValue));
    }

    // event hendler za button UbaciKurirsku
    protected void btnUbaciKurirsku_Click(object sender, EventArgs e)
    {
        int kurirID = upisiKurirskuSluzbu();

        // ako je insert bio uspesan
        if (kurirID > 0)
        {
            napuniKurirskuSluzbu();
            prikaziKurirskuSluzbu(kurirID);
            ddlKurirskaSluzba.SelectedValue = kurirID.ToString();
        }
    }

    // event hendler za butto Promeni kurirsku sluzbu
    protected void btnPromeniKurirsku_Click(object sender, EventArgs e)
    {
        int kurirID = Convert.ToInt32(ddlKurirskaSluzba.SelectedValue);
        izmeniKurirskuSluzbu(kurirID);
        napuniKurirskuSluzbu();
        ddlKurirskaSluzba.SelectedValue = kurirID.ToString();
    }

    // event hendler za button brisanje 
    protected void btnObrisiKurirsku_Click(object sender, EventArgs e)
    {
        int kurirID = Convert.ToInt32(ddlKurirskaSluzba.SelectedValue);
        obrisiKurirskuSluzbu(kurirID);
        napuniKurirskuSluzbu();
        resetujKontrole();
    }

    // event hendler za button reset polja
    protected void btnResetujPolja_Click(object sender, EventArgs e)
    {
        resetujKontrole();
    }
}