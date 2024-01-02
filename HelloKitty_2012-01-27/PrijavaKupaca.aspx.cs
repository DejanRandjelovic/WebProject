using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class PrijavaKupaca : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;


    //metoda koja upisuje podatke kupca
    private int upisiPodatkeKupca()
    {
        // koristimo Stored Procedure iz baze UbaciKategoriju
        string insertSQL = "sp_UbaciPodatkeKupca";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@KorisnickoIme", SqlDbType.NVarChar, 20);
        SqlParameter param2 =
            new SqlParameter("@Sifra", SqlDbType.NVarChar, 50);
        SqlParameter param3 =
            new SqlParameter("@Email", SqlDbType.NVarChar, 50);
        SqlParameter param4 =
            new SqlParameter("@ImePrimaoca", SqlDbType.NVarChar, 50);
        SqlParameter param5 =
            new SqlParameter("@PrezimePrimaoca", SqlDbType.NVarChar, 50);
        //SqlParameter param6 =
        //    new SqlParameter("@JMBG", SqlDbType.NVarChar, 13);       
        SqlParameter param7 =
            new SqlParameter("@AdresaPrimaoca", SqlDbType.NVarChar, 50);
        SqlParameter param8 =
            new SqlParameter("@GradPrimaoca", SqlDbType.NVarChar, 50);
        SqlParameter param9 =
            new SqlParameter("@BPostePrimaoca", SqlDbType.NChar, 10);
        SqlParameter param10 =
            new SqlParameter("@DrzavaPrimaoca", SqlDbType.NVarChar, 50);
        SqlParameter param11 =
            new SqlParameter("@Telefon1", SqlDbType.VarChar, 20);
        SqlParameter param12 =
           new SqlParameter("@Telefon2", SqlDbType.VarChar, 20);
        SqlParameter param13 =
           new SqlParameter("@Poruka", SqlDbType.NVarChar, 4000);
        SqlParameter param15 =
            new SqlParameter("@TipKorisnikaID", SqlDbType.Int);

        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        //cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);
        cmd.Parameters.Add(param8);
        cmd.Parameters.Add(param9);
        cmd.Parameters.Add(param10);
        cmd.Parameters.Add(param11);
        cmd.Parameters.Add(param12);
        cmd.Parameters.Add(param13);
        cmd.Parameters.Add(param15);

        // parametri uzimaju vrednosti iz kontrola

        param1.Value = tboxKorisnickoIme.Text;
        param2.Value = tboxSifra.Text;
        param3.Value = tboxEmail.Text;
        param4.Value = tboxIme.Text;
        param5.Value = tboxPrezime.Text;
        //param6.Value = tboxJMBG.Text;
        param7.Value = tboxAdresa.Text;
        param8.Value = tboxGrad.Text;
        param9.Value = tboxBrojPoste.Text;
        param10.Value = tboxDrzava.Text;
        param11.Value = tboxTelefon1.Text;
        param12.Value = tboxTelefon2.Text;
        param13.Value = tboxPoruka.Text;

        // postavljam default vrednost za prava korisnika
        param15.Value = "2";

        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param14 =
            new SqlParameter("@KupacID", SqlDbType.Int);
        param14.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param14);

        int dodato = 0;
        int ID = 0;
        // izvrsi komandu
        try
        {
            con.Open();
            dodato = cmd.ExecuteNonQuery();

            // iscitavamo parametar koga nam je prosledila baza
            ID = Convert.ToInt32(param14.Value);
            lblRezultat.Text =
                "ID upravo ubacenog kupca je: " + ID.ToString();
            return ID;
        }
        catch (Exception xcp)
        {
            lblRezultat.Text = "Greska pri upisu ili korisničko ime " + "'" + tboxKorisnickoIme.Text + "' " + "postoji u bazi!";
            return -1;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }

    // metoda koja resetuje polja za unos
    private void resetujPolja()
    {
        tboxKorisnickoIme.Text = "";
        tboxSifra.Text = "";
        tboxPotvrdiSifru.Text = "";
        tboxEmail.Text = "";
        tboxPrezime.Text = "";
        tboxIme.Text = "";
        //tboxJMBG.Text = "";
        tboxAdresa.Text = "";
        tboxGrad.Text = "";
        tboxBrojPoste.Text = "";
        tboxDrzava.Text = "";
        tboxTelefon1.Text = "";
        tboxTelefon2.Text = "";
        tboxPoruka.Text = "";
        lblRezultat.Text = "";
    }

    // load procedura strane
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //event hendler za btnPrijava
    protected void btnPrijava_Click(object sender, EventArgs e)
    {
        upisiPodatkeKupca();
    }


    // event hendler za btnPonisti
    protected void btnPonisti_Click(object sender, EventArgs e)
    {
        resetujPolja();
    }
}