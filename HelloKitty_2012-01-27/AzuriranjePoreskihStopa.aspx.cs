using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AzuriranjePoreskihStopa : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    // metoda koja puni listu sa poreskim stopama
    private void napuniListuPoreskihStopa()
    {
        ddlPoreskaStopa.Items.Clear();
        ddlPoreskaStopa.Items.Add("-Odaberi Stopu-");

        string selectStopa = "SELECT * FROM PoreskeStope";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectStopa, con);
        SqlDataReader reader;       

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem novaStavka = new ListItem();
                novaStavka.Text = reader["NazivStope"].ToString();
                novaStavka.Value = reader["PoreskaStopaID"].ToString();
                ddlPoreskaStopa.Items.Add(novaStavka);
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


    // metoda koja prikazuje podatke o prozvodima za zadati ID poreske stope 
    private void prikaziPoreskeStope(int id)
    {
        string selectSQL =
            "SELECT * FROM PoreskeStope WHERE PoreskaStopaID=@PoreskaStopaID";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@PoreskaStopaID", id);

        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // napuni kontrole
            tboxIDStope.Text= reader["PoreskaStopaID"].ToString();
            tboxNazivStope.Text = reader["NazivStope"].ToString();
            tboxVrednostStope.Text=reader["VrednostStope"].ToString();

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

    #region INSERT,UPDATE,DELETE

    //meteoda koja upisuje Poresku stopu
    private int upisiPoreskuStopu()
    {
        // koristimo Stored Procedure iz baze UbaciPoreskuStopu
        string insertSQL = "sp_UbaciPoreskuStopu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivStope", SqlDbType.NVarChar, 20);
        SqlParameter param2 =
            new SqlParameter("@VrednostStope", SqlDbType.Decimal);
        

        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        

        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivStope.Text;
        param2.Value = tboxVrednostStope.Text;
       

        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param3 =
            new SqlParameter("@PoreskaStopaID", SqlDbType.Int);
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
                "ID upravo ubacene stope je: " + ID.ToString();
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
    private void izmeniPoreskuStopu(int id)
    {

        // koristimo Stored Procedure iz baze IzmeniPoreskuStopu
        string insertSQL = "sp_IzmeniPoreskuStopu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivStope", SqlDbType.NVarChar, 20);
        SqlParameter param2 =
            new SqlParameter("@VrednostStope", SqlDbType.Decimal);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNazivStope.Text;
        param2.Value = tboxVrednostStope.Text;

        SqlParameter param3 =
            new SqlParameter("@PoreskaStopaID", SqlDbType.Int);
        cmd.Parameters.Add(param3);
        
        // id citamo iz ddlPoreskaStopa
        param3.Value=ddlPoreskaStopa.SelectedValue;

        // izvrsi komandu
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            
            litRezultat.Text =
                "Poreska stopa je update-ovana";
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


    // metoda bise poresku stopu za zadati id
    private void obrisiPoreskuStopu(int id)
    {
        // koristimo proceduru iz baze
        string deleteSQL = "sp_ObrisiPoreskuStopu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(deleteSQL, con);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("PoreskaStopaID", ddlPoreskaStopa.SelectedItem.Value);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            litRezultat.Text = "Zapis je obrisan iz baze.";
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri brisanju poreske stope! " + xcp.ToString();
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
        ddlPoreskaStopa.SelectedIndex = -1;
        tboxIDStope.Text = "";
        tboxNazivStope.Text = "";
        tboxVrednostStope.Text = "";
        litRezultat.Text = "";
    }

    // load procedura strane 
    protected void Page_Load(object sender, EventArgs e)
    {

       if (!Page.IsPostBack)
       {
           if (Session["TipKorisnikaID"].ToString() == "1")
           {

               Menu m2 = (Menu)Master.FindControl("Menu2");
               m2.Visible = true;

               napuniListuPoreskihStopa();       
           }
           else
           {
               Response.Redirect("Logovanje.aspx");
           }     
       }
    }


    protected void ddlPoreskaStopa_SelectedIndexChanged(object sender, EventArgs e)
    {
        litRezultat.Text = "";

        if (ddlPoreskaStopa.SelectedIndex==0)
        {
            litRezultat.Text = "Odaberite poresku stopu iz padajuce liste.";
            return;
        }
        prikaziPoreskeStope(Convert.ToInt32(ddlPoreskaStopa.SelectedValue));
    }


    protected void btnUbaciStopu_Click(object sender, EventArgs e)
    {
        int stopaID = upisiPoreskuStopu();
   
        // ako je insert bio uspesan
        if (stopaID > 0)
        {
            napuniListuPoreskihStopa();
            prikaziPoreskeStope(stopaID);
            ddlPoreskaStopa.SelectedValue = stopaID.ToString();
        }

    }


    protected void btnPromeniStopu_Click(object sender, EventArgs e)
    {
        int stopaID = Convert.ToInt32(ddlPoreskaStopa.SelectedValue);
        izmeniPoreskuStopu(stopaID);
        napuniListuPoreskihStopa();
        ddlPoreskaStopa.SelectedValue = stopaID.ToString();
    }


    protected void btnObrisiStopu_Click(object sender, EventArgs e)
    {
        int stopaID = Convert.ToInt32(ddlPoreskaStopa.SelectedValue);
        obrisiPoreskuStopu(stopaID);
        napuniListuPoreskihStopa();
        resetujKontrole();
    }


    protected void btnResetujPolja_Click(object sender, EventArgs e)
    {
        resetujKontrole();
    }

}