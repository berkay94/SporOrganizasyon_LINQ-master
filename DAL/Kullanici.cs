using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Kullanici
    {
        public int Kid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public string Ilce{ get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Cinsiyet { get; set; }
        public int IsLogin { get; set; }

    }
}
