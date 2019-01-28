using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Etkinlikler
    {
        public int EtkinlikId { get; set; }
        public string EtkinlikAdi { get; set; }
        public int TipId { get; set; }
        public int MekanId { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public int Kontenjan { get; set; }
        public int IsActive { get; set; }
        public int Sid { get; set; }
    }
}
