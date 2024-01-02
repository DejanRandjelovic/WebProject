using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


public partial class PregledKorpe : System.Web.UI.Page
{
    

    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    private SortedList korpa;

    // metoda koja cita sadrzaj korpe
    private void citajKorpu()
    {
        if (Session["Korpa"]==null)
        {
            Session.Add("Korpa", new SortedList());
        }
        korpa=(SortedList)Session["Korpa"];
    }

    //metoda koja prikazuje sadrzaj korpe unutar ListBox kontrole
    private void prikaziKorpu()
    {
        ListBoxUKorpi.Items.Clear();
        StavkaKorpa st;
        foreach (DictionaryEntry unos in korpa)
        {
            st=(StavkaKorpa)unos.Value;
            ListBoxUKorpi.Items.Add(st.prikazi());
        }
    }

    // metoda koja upisuje novi racun u bazu za logovanog kupca
    private int ubaciRacun(int kupacId)
    {
        // koristimo Stored Procedure iz baze UbaciRacun
        string insertSQL = "sp_UbaciRacun";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@KupacID", SqlDbType.Int);
        SqlParameter param2 =
            new SqlParameter("@DatumNarucivanja", SqlDbType.DateTime);
        SqlParameter param4 =
            new SqlParameter("@Medjuzbir", SqlDbType.Decimal);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param4);


        decimal suma = 0m;
        if (korpa!=null)
        {
           foreach (DictionaryEntry unos in korpa)
            {
                StavkaKorpa st = (StavkaKorpa)unos.Value;
                suma += (st.Proizvod.JedinicnaCena)*st.Kolicina;

                //lblPoruka.Text = "Ukupna vrednost porudzbine je: " + suma.ToString("c");
            }
        }


        // parametri uzimaju vrednosti iz kontrola
        param1.Value = kupacId;
        param2.Value = DateTime.Now;
        param4.Value=suma;


        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param3 =
            new SqlParameter("@RacunID", SqlDbType.Int);
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
            litRezultat.Text = "Uspešno slanje Porudzbine.";
            //litRezultat.Text +=
            //    "ID upravo ubacenog racuna je: " + ID.ToString();           
            return ID;
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri upisu.";
            //litRezultat.Text = "Greska pri upisu: " + xcp.ToString();
            return -1;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }

    // metoda ubacuje porudzbinu u tabelu ZaIsporuku
    private int ubaciPorudzbinu(int racID)
    {
        // koristimo Stored Procedure iz baze UbaciPorudzbinu
        string insertSQL = "sp_UbaciPorudzbinu";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@RacunID", SqlDbType.Int);
        SqlParameter param2 =
            new SqlParameter("@ProizvodID", SqlDbType.Int);
        SqlParameter param3 =
            new SqlParameter("@JedinicnaCena", SqlDbType.Decimal);
        SqlParameter param4 =
            new SqlParameter("@Kolicina", SqlDbType.Int);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);


        // parametri uzimaju vrednosti
        param1.Value = racID;

        int dodato = 0;

        foreach (DictionaryEntry ulaz in korpa)
        {
            StavkaKorpa stavkaIzKorpe = (StavkaKorpa)ulaz.Value;
            param2.Value = stavkaIzKorpe.Proizvod.ProizvodID;
            param3.Value = stavkaIzKorpe.Proizvod.JedinicnaCena;
            param4.Value = stavkaIzKorpe.Kolicina;

       
        // izvrsi komandu
        try
        {
            con.Open();
            dodato = cmd.ExecuteNonQuery();

        }
        catch (Exception xcp)
        {
            //litRezultat.Text = "Greska pri upisu: " + xcp.ToString();
            litRezultat.Text = "Greska pri upisu!";
            dodato = -1;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

        }
        // vraca 0 ako nema konekciju, 1 ako je uspesan upis, -1 neuspesan upis
        return dodato;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        citajKorpu();
        if (!Page.IsPostBack)
        {
            prikaziKorpu();
        }
    }

    protected void btnIsprazniKorpu_Click(object sender, EventArgs e)
    {
        korpa.Clear();
        ListBoxUKorpi.Items.Clear();
        lblPoruka.Text = "";     
    }

    protected void btnUkloniStavku_Click(object sender, EventArgs e)
    {
        if (korpa.Count>0)
        {
            if (ListBoxUKorpi.SelectedIndex > -1)
            {
                korpa.RemoveAt(ListBoxUKorpi.SelectedIndex);
                prikaziKorpu();

                // prikazuje trenutni iznos korpe
                if (korpa != null)
                {
                    decimal suma = 0m;
                    foreach (DictionaryEntry unos in korpa)
                    {
                        StavkaKorpa st = (StavkaKorpa)unos.Value;
                        suma += (st.Proizvod.JedinicnaCena) * st.Kolicina;

                        lblPoruka.Text = "Ukupna vrednost porudzbine je: " + suma.ToString();
                       // lblPoruka.Text = "Ukupna vrednost porudzbine je: " + suma.ToString("c");
                    }
                }

            }
            else
            {
                lblPoruka.Text = "Odaberite stavku za brisanje iz korpe.";
            }
        }
    }

    protected void btnNastaviKupovinu_Click(object sender, EventArgs e)
    {
        Response.Redirect("Korpa.aspx");
    }

    protected void btnUkupnaSuma_Click(object sender, EventArgs e)
    {
        lblPoruka.Text = "";
        if (korpa!=null)
        {
            decimal suma = 0m;
            foreach (DictionaryEntry unos in korpa)
            {
                StavkaKorpa st = (StavkaKorpa)unos.Value;
                suma += (st.Proizvod.JedinicnaCena)*st.Kolicina;

                lblPoruka.Text = "Ukupna vrednost porudzbine je: " + suma.ToString();
               // lblPoruka.Text = "Ukupna vrednost porudzbine je: " + suma.ToString("c");
            }
        }
    }

    protected void btnPosaljiPorudzbinu_Click(object sender, EventArgs e)
    {
        if ((korpa.Count>0)&&(Session["UserID"]!=null))
        {
            int ulogovaniID = Convert.ToInt32(Session["UserID"]);
            int racunID = ubaciRacun(ulogovaniID);
            int rez = ubaciPorudzbinu(racunID);

            //lblPoruka.Text += " Rezultat izvrsavanja je: " + rez.ToString();
            // isprazni korupu
            korpa.Clear();
            ListBoxUKorpi.Items.Clear();


            //Response.Redirect("PrijavaKupaca.aspx");

        }
        else
        {
            lblPoruka.Text = "Vasa korpa je prazna.";
            litRezultat.Text = "";
            return;
        }
        
    }
}