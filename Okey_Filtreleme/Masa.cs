using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey_Filtreleme
{
    public class Masa
    {
        //Masa değişkenleri tanımlanır. 
        public int BahisMin { get; set; }
        public int BahisMax { get; set; }
        public bool Hizli { get; set; }
        public bool TekeTek { get; set; }
        public bool Rovans { get; set; }

        // Burada, MasaTipi adında bir enum tanımlanmıştır. Bu enum sabitleri, None, Hizli, TekeTek ve Rovans olmak üzere dört tane vardır. Bu sabitlerin değerleri, sırasıyla 0, 1, 2 ve 3 olarak atanmıştır.
        [Flags]
        public enum MasaTipi
        {
            None = 0,
            Hizli = 1,
            TekeTek = 2,
            Rovans = 3
        }
    }
}
