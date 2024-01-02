using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProizvodKorpa
{
    private int proizvodID;
    private string nazivProizvoda;
    private string opisProizvoda;
    private string barKod;
    private decimal jedinicnaCena;
    private byte[] slika;
    private int naStanju;
    private bool jeAktivan;
    private string sifra;

   

   

    // definisemo propertije
    public int ProizvodID
    {
        get { return proizvodID; }
        set { proizvodID = value; }
    }
    

    public string NazivProizvoda
    {
        get { return nazivProizvoda; }
        set { nazivProizvoda = value; }
    }
   

    public string OpisProizvoda
    {
        get { return opisProizvoda; }
        set { opisProizvoda = value; }
    }
    

    public string BarKod
    {
        get { return barKod; }
        set { barKod = value; }
    }
   

    public decimal JedinicnaCena
    {
        get { return jedinicnaCena; }
        set { jedinicnaCena = value; }
    }
    

    public byte[] Slika
    {
        get { return slika; }
        set { slika = value; }
    }

    public int NaStanju
    {
        get { return naStanju; }
        set { naStanju = value; }
    }

    public bool JeAktivan
    {
        get { return jeAktivan; }
        set { jeAktivan = value; }
    }

    public string Sifra
    {
        get { return sifra; }
        set { sifra = value; }
    }


}