using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnLineShopTableAdapters;
using System.ComponentModel;

[DataObject]
public class KategorijeBLL
{
    private KategorijeTableAdapter kategorijeAdapter = null;

    protected KategorijeTableAdapter katAdapter
    {
        get
        {
            if (kategorijeAdapter == null)
                kategorijeAdapter = new KategorijeTableAdapter();
            return kategorijeAdapter;
        }
    }

    // definisemo select komandu koja vraca tipiziranu tabelu
    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public OnLineShop.KategorijeDataTable GetKategorije()
    {
        return katAdapter.GetKategorije();
    }
	
}