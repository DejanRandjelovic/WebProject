using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnLineShopTableAdapters;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public partial class Korpa1 : System.Web.UI.Page
{
    private ProizvodKorpa odabraniProizvod;
    private string connString = Konekcija.cnnOnLineProdavnica;

    // metoda koja iscitava ili kreira potrosacku korpu
    private SortedList CitajKorpu()
    {
        if (Session["Korpa"] == null)
        {
            //ako je korpa prazna kreiramo je
            Session.Add("Korpa", new SortedList());
        }
        return (SortedList)Session["Korpa"];
    }

    // metoda dodaje proizvod u korpu i sabira iste proizvode
    private void DodajStavkuUKorupu(StavkaKorpa st)
    {
        SortedList korpa = CitajKorpu();
        int proizvodID = odabraniProizvod.ProizvodID;

        if (korpa.ContainsKey(proizvodID))
        {
            StavkaKorpa postojecaStavka = (StavkaKorpa)korpa[proizvodID];
            postojecaStavka.Kolicina += st.Kolicina;
        }
        else
        {
            // kljuc je ID proizvoda, a vrednost sama Stavka
            korpa.Add(proizvodID,st);
        }
    }

    private ProizvodKorpa CitajProizvodKorpe()
    {
        string ID = ddlProizKorpa.SelectedValue;
         

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proizvodi",connString);
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        DataSet ds = new DataSet();
        da.Fill(ds,"Proizvodi");
        DataTable tbl=ds.Tables["Proizvodi"];
        DataRow row = tbl.Rows.Find(ID);

        ProizvodKorpa p = new ProizvodKorpa();
        p.ProizvodID=(int)row["ProizvodID"];
        p.NazivProizvoda = row["NazivProizvoda"].ToString();
        p.OpisProizvoda = row["OpisProizvoda"].ToString();
        p.BarKod = row["BarKod"].ToString();
        p.JedinicnaCena=(decimal)row["JedinicnaCena"];
        p.Slika=(byte[])row["MalaSlika"];
        p.NaStanju=(int)row["NaStanju"];
        p.JeAktivan=(bool)row["JeAktivan"];


        return p;


    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            tboxKolicina.Text = "1";
        }
   

    }

    protected void btnDodajUKorpu_Click(object sender, EventArgs e)
    {
        // ako je korisnik logovan idemo na kupovinu ako ne saljemo ga na logovanje
        if ((Session["Ulogovani"] != null) && (Session["Ulogovani"] != ""))

        {
            if (Page.IsValid)
            {
                odabraniProizvod = CitajProizvodKorpe();
                StavkaKorpa st = new StavkaKorpa();
                st.Proizvod = odabraniProizvod;
                st.Kolicina = Convert.ToInt32(tboxKolicina.Text);

                if (st.Kolicina > 0)
                {
                    DodajStavkuUKorupu(st);
                    lblKorpaPoruka.Text = "Proizvod " + st.Proizvod.NazivProizvoda + " dodat u korpu.";
                }
                else
                {
                    lblKorpaPoruka.Text = "Kolicina mora biti > 0";
                }
            }
        }
        else
        {
            Response.Redirect("Logovanje.aspx");
        }
        
    }

    protected void ddlProizKorpa_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblKorpaPoruka.Text = "";      
    }

    protected void btnPregledKorpe_Click(object sender, EventArgs e)
    {
        // ako je korisnik logovan ide se na stranu PregledKorpe u suprotnom na Logovanje
        if (Session["Ulogovani"]!="")
        {
            Response.Redirect("PregledKorpe.aspx");
        }

        Response.Redirect("Logovanje.aspx");
    }
    protected void ddlKategorijaKorpa_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProizKorpa.Items.Clear();
        //ddlProizKorpa.Items.Add("Odaberi proizvod");
    }
}