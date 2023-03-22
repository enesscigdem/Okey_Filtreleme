using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey_Filtreleme
{
    public class Filtreleme
    {
        // FiltreleMasa metodu, bir List<Masa>(masa listesi), bir double(bahis aralığı) ve üç tane boolean(mantıksal) parametre alır.
        public static List<Masa> FiltreleMasa(List<Masa> masalar, double bahisAraligi, bool hizli, bool tekeTek, bool rovans)
        {
            var sonuc = new List<Masa>(); // bu satırı ile boş bir List<Masa> (masa listesi) oluşturulur.
            foreach (var masa in masalar)
            {
                if (masa.BahisMin <= bahisAraligi && masa.BahisMax >= bahisAraligi && (hizli == masa.Hizli) && (tekeTek == masa.TekeTek) && (rovans == masa.Rovans))
                {
                    sonuc.Add(masa); // Bu masa, sonuç listesine eklenir 
                }
            }
            return sonuc; // filtrelenmiş masaların bulunduğu sonuç listesi geri döndürülür.
        }
    }
}