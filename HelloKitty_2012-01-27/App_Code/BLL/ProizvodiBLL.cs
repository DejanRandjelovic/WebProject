using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnLineShopTableAdapters;
using System.ComponentModel;


[DataObject] 
public class ProizvodiBLL
{
    private ProizvodiTableAdapter proizvodiAdapter = null;
    
    // definisemo get property
    protected ProizvodiTableAdapter Adapter
    {
        get
        {
            if (proizvodiAdapter == null)
                proizvodiAdapter = new ProizvodiTableAdapter();
            return proizvodiAdapter;
        }
    }

    // definisemo select komandu koja vraca tipiziranu tabelu proizvoda
    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public OnLineShop.ProizvodiDataTable GetProizvodi()
    {
        return Adapter.GetProizvodi();
    }

    // select komanda koja vraca tabelu proizvoda za ulazni ID kategorije
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public OnLineShop.ProizvodiDataTable GetProizvodiByKategorijaID(int kat_ID)
    {
        return Adapter.GetProizvodiByKategorijaID(kat_ID);
    }



    // select komanda koja vraca tabelu koja se sastoji iz jednog reda
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public OnLineShop.ProizvodiDataTable GetProizvodByProizvodID(int p_ID)
    {
        return Adapter.GetProizvodByProizvodID(p_ID);
    }

    // select komanda koja vraca tabelu sa jednim redom i binarnim podacima slike
    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
    public OnLineShop.ProizvodiDataTable GetProizvodWithBinaryDataByProizvodID(int p_ID)
    {
        return Adapter.GetProizvodWithBinaryDataByProizvodID(p_ID);
    }

    [DataObjectMethodAttribute(DataObjectMethodType.Insert, false)]
    public void insertProizvod(string sifra, string barKod, int poreskaStopa, string nazivProizvoda, decimal jedinicnaCena, int kategorijaID, string opisProizvoda, int naStanju, bool jeAktivan,  bool Akcija, DateTime datumAzuriranja, string brosuraPath, byte[] malaSlika)
    {
        Adapter.Insert(sifra, barKod, poreskaStopa, nazivProizvoda, jedinicnaCena, kategorijaID, opisProizvoda, naStanju, jeAktivan, Akcija, datumAzuriranja, brosuraPath, malaSlika);
    }


    [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
   public OnLineShop.ProizvodiDataTable GetKorpaProizvodByProizvodID(int p_ID)
   {
        return Adapter.GetKorpaProizvodByProizvodID(p_ID);
   }

}