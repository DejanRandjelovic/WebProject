using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class StavkaKorpa
{
    private ProizvodKorpa proizvod;
    private int kolicina;

    public ProizvodKorpa Proizvod
    {
        get { return proizvod; }
        set { proizvod = value; }
    }

  
    public int Kolicina
    {
        get { return kolicina; }
        set { kolicina = value; }
    }

    // metoda koja prikazuje stavku u korpi
    public string prikazi()
    {
        string t = proizvod.NazivProizvoda + " (" + kolicina.ToString()
            + " kom. " + proizvod.JedinicnaCena.ToString() +" RSD"+ "  svaki)";


        // prikazuje jedinicnu cenu sa lokalnom valutom podesenom na PC-ju
        //string t = proizvod.NazivProizvoda + " (" + kolicina.ToString()
        //   + " kom. " + proizvod.JedinicnaCena.ToString("c") + " svaki)";

        return t;
    }
	

}