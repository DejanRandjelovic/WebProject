using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO;

public partial class AzuriranjeProizvoda : System.Web.UI.Page
{
    // konekcioni string na bazu OnLineProdavnica
    private string connString = Konekcija.cnnOnLineProdavnica;

    // metoda koja puni listu sa svim proizvodima
    private void napuniListuProizvoda()
    {
        ddlProizvodi.Items.Clear();
        ddlProizvodi.Items.Add("-Odaberi Proizvod-");

        string selectProizvod = "SELECT * FROM Proizvodi";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectProizvod, con);
        SqlDataReader reader;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem novaStavka = new ListItem();
                novaStavka.Text = reader["NazivProizvoda"].ToString();
                novaStavka.Value = reader["ProizvodID"].ToString();               
                ddlProizvodi.Items.Add(novaStavka);
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


    // metoda koja puni listu sa svim kategorijama
    private void napuniListuKategorija()
    {
        ddlKategorije.Items.Clear();
        
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
                ddlKategorije.Items.Add(novaStavka);
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

    // metoda koja puni listu sa svim poreskim stopama
    private void napuniListuPoreskeStope()
    {
        ddlPoreskeStope.Items.Clear();

        string selectPorezi = "SELECT * FROM PoreskeStope";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectPorezi, con);
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
                ddlPoreskeStope.Items.Add(novaStavka);
            }

            ddlPoreskeStope.SelectedIndex = -1;
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

 
    // metoda koja prikazuje podatke o prozvodima za zadati ID proizvoda 
    private void prikaziPodatke(string id)
    {
        string selectSQL =
            "SELECT * FROM Proizvodi WHERE ProizvodID=@ProizvodID";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@ProizvodID", id);

        SqlDataReader reader;
        
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // napuni kontrole
            tboxID.Text= reader["ProizvodID"].ToString();
            tboxSifra.Text= reader["Sifra"].ToString();
            tboxNaziv.Text=reader["NazivProizvoda"].ToString();
            tboxOpis.Text=reader["OpisProizvoda"].ToString();
            tboxBarKod.Text=reader["BarKod"].ToString();

            ddlKategorije.SelectedValue = reader["KategorijaID"].ToString();
            ddlPoreskeStope.SelectedValue=reader["PoreskaStopaID"].ToString();

            tboxJednicnaCena.Text=reader["JedinicnaCena"].ToString();
            tboxKolicina.Text=reader["NaStanju"].ToString();
            cboxAktivan.Checked=(bool)reader["JeAktivan"];
            cboxNaAkciji.Checked=(bool)reader["Akcija"];
            tboxDatumAzuriranja.Text=reader["DatumAzuriranja"].ToString();
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

    // metoda koja za zadati BarKod vraca ID proizvoda
    private int vratiIdZaZadatiBarKod(string barKod)
    {
        string selectSQL =
            "SELECT  ProizvodID, BarKod FROM Proizvodi WHERE BarKod=@BarKod";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@BarKod", barKod);

        SqlDataReader reader;

        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param10 =
            new SqlParameter("@ProizvodID", SqlDbType.Int);
        param10.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param10);

        // int dodato = 0;
        int ID = 0;
        // izvrsi komandu
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            
            ID = Convert.ToInt32(reader["ProizvodID"]); 
            litRezultat.Text =
                "ID upravo pronadjenog artikla je: " + ID.ToString();
            
            reader.Close();
            return ID;
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska ne postoji barkod: " + xcp.ToString();
            return -1;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }
    }


    // metoda koja prikazuje podatke o prozvodima za zadati BarKod proizvoda 
    private int prikaziProizvodPoBarKodu(string barKod)
    {
        string selectSQL =
            "SELECT * FROM Proizvodi WHERE BarKod=@BarKod";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.AddWithValue("@BarKod", barKod);

        SqlDataReader reader;

        int rez = 0;

        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();

            // napuni kontrole
            ddlProizvodi.SelectedIndex = Convert.ToInt32(reader["ProizvodID"].ToString());
            tboxID.Text = reader["ProizvodID"].ToString();
            tboxSifra.Text = reader["Sifra"].ToString();
            tboxNaziv.Text = reader["NazivProizvoda"].ToString();
            tboxOpis.Text = reader["OpisProizvoda"].ToString();
            tboxBarKod.Text = reader["BarKod"].ToString();

            //  ddlProizvodi.SelectedValue= reader["NazivProizvoda"].ToString();
            

            ddlKategorije.SelectedValue = reader["KategorijaID"].ToString();
            ddlPoreskeStope.SelectedValue = reader["PoreskaStopaID"].ToString();

            tboxJednicnaCena.Text = reader["JedinicnaCena"].ToString();
            tboxKolicina.Text = reader["NaStanju"].ToString();
            cboxAktivan.Checked = (bool)reader["JeAktivan"];
            cboxNaAkciji.Checked = (bool)reader["Akcija"];
            tboxDatumAzuriranja.Text = reader["DatumAzuriranja"].ToString();


            litRezultat.Text = "ID proizvoda je:  " + reader["ProizvodID"].ToString();
            reader.Close();

            rez = 1;
            return rez;
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri citanju!";
            litRezultat.Text += xcp.Message;
            rez = -1;
            return rez;
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

    }


    // metoda koja resetuje sadrzaj kontrola
    private void resetuj()
    {
        ddlProizvodi.SelectedIndex = -1;
        tboxID.Text = "";
        tboxNaziv.Text = "";
        tboxSifra.Text = "";
        tboxOpis.Text = "";
        tboxBarKod.Text = "";

        ddlKategorije.SelectedIndex = -1;
        ddlPoreskeStope.SelectedIndex = -1;

        tboxJednicnaCena.Text = "";
        tboxKolicina.Text = "";
        cboxAktivan.Checked = false;
        cboxNaAkciji.Checked = false;
        tboxDatumAzuriranja.Text = "";
    }

    #region INSERT,UPDATE,DELETE

    //meteoda koja upisuje Proizvod
    private int upisiProizvod()
    {
        // koristimo proceduru iz baze
        string insertSQL = "sp_UbaciProizvod";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;

        // definisemo parametre
        SqlParameter param1 =
            new SqlParameter("@NazivProizvoda", SqlDbType.NVarChar, 50);
        SqlParameter param2 =
            new SqlParameter("@OpisProizvoda", SqlDbType.NVarChar, 4000);
        SqlParameter param3 =
            new SqlParameter("@BarKod", SqlDbType.NChar, 13);
        SqlParameter param4 =
            new SqlParameter("@KategorijaID", SqlDbType.Int);
        SqlParameter param5 =
            new SqlParameter("@PoreskaStopaID", SqlDbType.Int);
        SqlParameter param6 =
            new SqlParameter("@JedinicnaCena", SqlDbType.Decimal);
        SqlParameter param7 =
            new SqlParameter("@NaStanju", SqlDbType.Int);
        SqlParameter param8 =
            new SqlParameter("@JeAktivan", SqlDbType.Bit);
        SqlParameter param9 =
            new SqlParameter("@DatumAzuriranja", SqlDbType.SmallDateTime);
        SqlParameter param12 =
            new SqlParameter("@Akcija", SqlDbType.Bit);
        SqlParameter param13 =
            new SqlParameter("@Sifra", SqlDbType.NVarChar, 30);


        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        cmd.Parameters.Add(param3);
        cmd.Parameters.Add(param4);
        cmd.Parameters.Add(param5);
        cmd.Parameters.Add(param6);
        cmd.Parameters.Add(param7);
        cmd.Parameters.Add(param8);
        cmd.Parameters.Add(param9);
        cmd.Parameters.Add(param12);
        cmd.Parameters.Add(param13);

        // parametri uzimaju vrednosti iz kontrola
        param1.Value = tboxNaziv.Text;
        param2.Value = tboxOpis.Text;
        param3.Value = tboxBarKod.Text;
        param4.Value = ddlKategorije.SelectedValue;
        param5.Value = ddlPoreskeStope.SelectedValue;
        param6.Value = tboxJednicnaCena.Text;
        param7.Value = tboxKolicina.Text;
        param8.Value = cboxAktivan.Checked;
        param9.Value = DateTime.Now;
        param12.Value = cboxNaAkciji.Checked;
        param13.Value = tboxSifra.Text;

        // dodajemo izlazni parametar koji generise baza nakon upisa
        SqlParameter param10 =
            new SqlParameter("@ProizvodID", SqlDbType.Int);
        param10.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param10);

        int dodato = 0;
        int ID = 0;
        // izvrsi komandu
        try
        {
            con.Open();
            dodato = cmd.ExecuteNonQuery();

            // iscitavamo parametar koga nam je prosledila baza
            ID = Convert.ToInt32(param10.Value);
            litRezultat.Text =
                "ID upravo ubacenog artikla je: " + ID.ToString();
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

    // metoda za izmenu podataka o proizvodima
    private void izmeniProizvod(int id)
    {
        // koristimo proceduru iz baze
        string updateSQL = "sp_IzmeniProizvod";
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(updateSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                // definisemo parametre
                SqlParameter param1 =
                    new SqlParameter("@NazivProizvoda", SqlDbType.NVarChar, 50);
                SqlParameter param2 =
                    new SqlParameter("@OpisProizvoda", SqlDbType.NVarChar, 4000);
                SqlParameter param3 =
                    new SqlParameter("@BarKod", SqlDbType.NChar, 13);
                SqlParameter param4 =
                    new SqlParameter("@KategorijaID", SqlDbType.Int);
                SqlParameter param5 =
                    new SqlParameter("@PoreskaStopaID", SqlDbType.Int);
                SqlParameter param6 =
                    new SqlParameter("@JedinicnaCena", SqlDbType.Decimal);
                SqlParameter param7 =
                    new SqlParameter("@NaStanju", SqlDbType.Int);
                SqlParameter param8 =
                    new SqlParameter("@JeAktivan", SqlDbType.Bit);
                SqlParameter param9 =
                    new SqlParameter("@DatumAzuriranja", SqlDbType.SmallDateTime);
                SqlParameter param12 =
                    new SqlParameter("@Akcija", SqlDbType.Bit);
                SqlParameter param13 =
                   new SqlParameter("@Sifra", SqlDbType.NVarChar, 30);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);
                cmd.Parameters.Add(param8);
                cmd.Parameters.Add(param9);
                cmd.Parameters.Add(param12);
                cmd.Parameters.Add(param13);

                // parametri uzimaju vrednosti iz kontrola
                param1.Value = tboxNaziv.Text;
                param2.Value = tboxOpis.Text;
                param3.Value = tboxBarKod.Text;
                param4.Value = ddlKategorije.SelectedValue;
                param5.Value = ddlPoreskeStope.SelectedValue;
                param6.Value = tboxJednicnaCena.Text;
                param7.Value = tboxKolicina.Text;
                param8.Value = cboxAktivan.Checked;
                param9.Value = DateTime.Now;
                param12.Value = cboxNaAkciji.Checked;
                param13.Value = tboxSifra.Text;

                // zadajemo vrednost za id proizvoda koji se menja
                SqlParameter param11 =
                    new SqlParameter("@ProizvodID", SqlDbType.Int);
                cmd.Parameters.Add(param11);
                param11.Value = ddlProizvodi.SelectedValue;

                int updated = 0;
                // izvrsi komandu
                try
                {
                    con.Open();
                    updated = cmd.ExecuteNonQuery();

                    litRezultat.Text = "Uspesan update proizvoda.";
                }
                catch (Exception xcp)
                {
                    litRezultat.Text = "Greska: " + xcp.ToString();
                }
                finally
                {
                    // zatvaramo konekciju
                    con.Close();
                }
               
            }

    // metoda brise proizvod iz baze
    private void obrisiProizvod(int id)
    {
        // koristimo proceduru iz baze
        string deleteSQL = "sp_ObrisiProizvod";
        SqlConnection con = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(deleteSQL, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("ProizvodID", id );

        int deleted = 0;
        try
        {
            con.Open();
            deleted = cmd.ExecuteNonQuery();
            litRezultat.Text = "Zapis je obrisan iz baze.";
        }
        catch (Exception xcp)
        {
            litRezultat.Text = "Greska pri brisanju proizvoda! " + xcp.ToString();
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

        // osvezi listu proizvoda
        if (deleted > 0)
        {
            napuniListuProizvoda();
            ddlProizvodi.SelectedIndex = 0;
            resetuj();
        }
    }

    #endregion

    // loada procedura strane
    protected void Page_Load(object sender, EventArgs e)
    {
     // prilikom prvog ucitavanja strane punimo sve liste
        if (!Page.IsPostBack)
        {
            if (Session["TipKorisnikaID"].ToString() == "1")
            {
                Menu m2 = (Menu)Master.FindControl("Menu2");
                m2.Visible = true;

                napuniListuProizvoda();
                napuniListuKategorija();
                napuniListuPoreskeStope();

                //rblistIzbor.SelectedIndex = 1;
                //ddlProizvodi.Enabled = false;
                //tboxPoBarKodu.Enabled = true;

                //int izbor;
                //izbor = rblistIzbor.SelectedIndex;

                //switch (izbor)
                //{
                //    case 0:
                //        tboxPoBarKodu.Enabled = false;
                //        break;

                //    case 1:
                //        ddlProizvodi.Enabled = false;
                //        break;
                //    default:
                //        tboxPoBarKodu.Enabled = true;
                //        ddlProizvodi.Enabled = false;
                //        break;
                //}
            }
            else
            {
                Response.Redirect("Logovanje.aspx");
            }               
        }
    }


    // event hendler za ddlProizvodi_SelectedIndexChanged 
    protected void ddlProizvodi_SelectedIndexChanged(object sender, EventArgs e)
    {
        litRezultat.Text = "";
        
        // prikazuje podatke u poljima zavisno od selektovane vrednosti ddlProizvodi
        if (ddlProizvodi.SelectedIndex == 0)
        {
            litRezultat.Text = "Odaberite stavku iz padajuce liste.";
            return;            
        }

        prikaziPodatke(ddlProizvodi.SelectedValue);
    }


    // event hendler za button Resetuj
    protected void btnResetujProizvode_Click(object sender, EventArgs e)
    {
        resetuj();
    }

    
    // event hendler za button UbaciProizvod
    protected void btnUbaciProizvod_Click(object sender, EventArgs e)
    {

        int p = upisiProizvod();
        snimiSliku(p);
        snimiBrosuru(p);

        // ako je insert bio uspesan
        if (p>0)
        {
        napuniListuProizvoda();
        ddlProizvodi.SelectedValue = p.ToString();
        }
    }

    // event hendler za button PromeniProizvod
    protected void btnPromeniProizvod_Click(object sender, EventArgs e)
    {
        int p = Convert.ToInt32(ddlProizvodi.SelectedValue);
        
        izmeniProizvod(p);
        snimiSliku(p);
        //snimiBrosuru(p);
        napuniListuProizvoda();
        ddlProizvodi.SelectedValue = p.ToString();
    }

    protected void btnObrisiProizvod_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddlProizvodi.SelectedItem.Value);
        obrisiProizvod(id);

    }

    

    #region Rad sa Slikama


    // metoda koja snima Sliku u tabelu Proizvodi
    private void snimiSliku(int idProizvoda)
    {
        if (FileUploadSlika.PostedFile != null && FileUploadSlika.PostedFile.FileName != "")
        {
            string strExtenzija = System.IO.Path.GetExtension(FileUploadSlika.FileName);

            if ((strExtenzija.ToUpper() == ".JPG") | (strExtenzija.ToUpper() == ".GIF")
                | (strExtenzija.ToUpper() == ".PNG"))
            {
                // smanjujemo sliku pre upisa
                System.Drawing.Image imageToBeResized =
                    System.Drawing.Image.FromStream(FileUploadSlika.PostedFile.InputStream);
                int imageHeight = imageToBeResized.Height;
                int imageWidth = imageToBeResized.Width;
                //int maxHeight = 200;
                //int maxWidth = 200;
                int maxHeight = 150;
                int maxWidth = 150;


                imageHeight = (imageHeight * maxWidth) / imageWidth;
                imageWidth = maxWidth;

                if (imageHeight > maxHeight)
                {
                    imageWidth = (imageWidth * maxHeight) / imageHeight;
                    imageHeight = maxHeight;
                }

                Bitmap bitmap = new Bitmap(imageToBeResized, imageWidth, imageHeight);
                MemoryStream stream = new MemoryStream(); // dodat namespace System.IO
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte [] image= new byte[stream.Length + 1];
                stream.Read(image,0,image.Length);

                        

                SqlConnection con = new SqlConnection(Konekcija.cnnOnLineProdavnica);
                SqlCommand cmd = new SqlCommand("sp_UbaciSliku", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProizvodID",SqlDbType.Int);
                cmd.Parameters["@ProizvodID"].Value = idProizvoda;
                cmd.Parameters.Add("@MalaSlika", SqlDbType.Image);
                cmd.Parameters["@MalaSlika"].Value= image;

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    litRezultat.Text += " Slika je ubacena";
                }
                catch (Exception xcp)
                {
                    litRezultat.Text += " Greska pri upisu slike: " + xcp.ToString();
                }
                finally
                {
                    // zatvaramo konekciju
                    con.Close();
                }

            }
        }
    }


    // metoda koja vraca sliku iz baze
    private byte[] prikaziSlikuProizvoda(int id)
    {
        SqlConnection con = new SqlConnection(Konekcija.cnnOnLineProdavnica);
        SqlCommand cmd = new SqlCommand("sp_VratiSliku", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter param = new SqlParameter("@ProizvodID", SqlDbType.Int);
        param.Value = id;
        cmd.Parameters.Add(param);

        try
        {
            con.Open();
            byte[] imgdata = (byte[])cmd.ExecuteScalar();
            return imgdata;
        }
        catch (Exception xcp)
        {
            throw new Exception(xcp.Message, xcp);
        }
        finally
        {
            // zatvaramo konekciju
            con.Close();
        }

    }

    #endregion


    #region Rad sa Brosurama
    // metoda koja smima brosuru i putanju brosure u bazi
    private void snimiBrosuru(int idProizvoda)
    {
        
        if (FileUploadBrosura.HasFile)
        {
            string strExtenzija = System.IO.Path.GetExtension(FileUploadBrosura.FileName);

            // samo pdf fajlove 
            if (strExtenzija.ToUpper() == ".PDF")
            {
                const string folder= "~/Brosure/";
                string putanjaBrosure = folder + FileUploadBrosura.FileName;
                string imeFajlaBezEkstenzije =
                    Path.GetFileNameWithoutExtension(FileUploadBrosura.FileName);

                int br = 1;

                // ako postoji fajl preimenujemo ga
                while (File.Exists(Server.MapPath(putanjaBrosure)))
                {
                    putanjaBrosure = string.Concat(folder, imeFajlaBezEkstenzije,"-",br,".pdf");
                    br++;
                }

                // sacuvaj fajl na folder ~/Brosure/
                FileUploadBrosura.SaveAs(Server.MapPath(putanjaBrosure));
            
                SqlConnection con = new SqlConnection(Konekcija.cnnOnLineProdavnica);
                SqlCommand cmd = new SqlCommand("sp_UbaciBrosuru",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProizvodID", SqlDbType.Int);
                cmd.Parameters["@ProizvodID"].Value = idProizvoda;
                cmd.Parameters.Add("@BrosuraPath", SqlDbType.VarChar);
                cmd.Parameters["@BrosuraPath"].Value = putanjaBrosure;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    litRezultat.Text += "Putanja brosure je ubacena u bazu.";
                }
                catch (Exception xcp)
                {
                    litRezultat.Text += " Greska pri upisu brosure. " + xcp.ToString();
                }
                finally
                {
                    // zatvaramo konekciju
                    con.Close();
                }

            }
            else
            {
                litRezultat.Text += "Brosure mogu biti samo pdf dokumenti.";
            }
        }
        

    }

    #endregion


    protected void btnTraziPoBarKodu_Click(object sender, EventArgs e)
    {
        int idPronadjeni = 0;

        if (tboxNadjiPoBarKodu.Text != "")
        {
            // brisemo text labele
            litRezultat.Text = "";

            idPronadjeni = vratiIdZaZadatiBarKod(tboxNadjiPoBarKodu.Text);
            litRezultat.Text = "Pronadjen je ID: " + idPronadjeni.ToString();

            ddlProizvodi.SelectedValue = idPronadjeni.ToString();
            prikaziPodatke(idPronadjeni.ToString());


            if (idPronadjeni == -1)
            {
                litRezultat.Text = "Bar kod nije pronadjen!!!";
                ddlProizvodi.ClearSelection();
            }


            // prikaziPodatke(id.ToString());
        }
        else
        {
            resetuj();
            ddlProizvodi.ClearSelection();
        }

        
    }
    protected void rblistIzbor_SelectedIndexChanged(object sender, EventArgs e)
    {
        int izbor;
        izbor = rblistIzbor.SelectedIndex;

        switch (izbor)
        {
            case 0:

                tboxNadjiPoBarKodu.Enabled = false;
                btnTraziPoBarKodu.Enabled = false;
                ddlProizvodi.Enabled = true;
                break;

            case 1:
                ddlProizvodi.Enabled = false;
                tboxNadjiPoBarKodu.Enabled = true;
                btnTraziPoBarKodu.Enabled = true;
                break;

            default:
                tboxNadjiPoBarKodu.Enabled = true;
                btnTraziPoBarKodu.Enabled = true;
                ddlProizvodi.Enabled = false;
                break;
        }
    }
    
}