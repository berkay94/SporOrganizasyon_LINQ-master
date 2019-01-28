using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EtkinlikGoster
    {
        public int EtkinlikId { get; set; }
        public string EtkinlikAdi { get; set; }
        public string SporAdi { get; set; }
        public string Tip { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public string MekanAdi { get; set; }
        public string Ad { get; set; }
        public string Sehir { get; set; }
        public int Kontenjan { get; set; }
        public int Katilanlar { get; set; }
    }
}
