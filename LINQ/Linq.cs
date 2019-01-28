using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQ
{
    public class Linq
    {
        SporODataContext sc;
        public Linq()
        {
            sc = new SporODataContext();
        }

        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public int KullaniciKaydet(string ad, string soyad, string email, string telefon, string sifre, string ilce, DateTime dogumtarihi, int cinsiyet, int[] s)
        {
            int kayitSayisi = 0;
            try
            {
                Kullanici k = new Kullanici();
                bool kontrol = EmailKontrol(email);
                if (kontrol && !string.IsNullOrEmpty(sifre))
                {
                    k.Ad = ad;
                    k.Soyad = soyad;
                    k.Email = email;
                    k.Telefon = telefon;
                    k.Sifre = sifre;
                    k.Ilce = ilce;
                    k.DogumTarihi = dogumtarihi;
                    k.Cinsiyet = cinsiyet;
                    k.isLogin = 1;
                    sc.Kullanicis.InsertOnSubmit(k);
                    sc.SubmitChanges();
                    KullaniciSpor(s);
                    kayitSayisi = 1;
                }
                else
                {
                    HataVar("Email uygun değil!!");
                    kayitSayisi = -1;
                }
            }
            catch (Exception ex)
            {
                Hata(ex);
            }
            return kayitSayisi;
        }

        public void KullaniciSpor(int[] spor)
        {
            try
            {
                KullaniciSpor ks = new KullaniciSpor();
                foreach (int s in spor)
                {
                    int kullanici = Convert.ToInt32(sc.SonKullanici().ToString());

                    ks.Kid = kullanici;
                    ks.Sid = s;
                    sc.KullaniciSporEkle(kullanici, s);
                    sc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Hata(ex);
            }
        }

        public int LoginKontrol(string email, string sifre)
        {
            int kayitSayisi = 0;
          
            try
            {

                var login = from lgn in sc.Kullanicis where lgn.Email == email && lgn.Sifre == sifre select lgn;
               

                if (login.Count() > 0)
                {
                    kayitSayisi = 1;

                    foreach (var item in login.ToList())
                    {
                        if (item.isLogin == 2)
                        {
                            kayitSayisi = -2;
                        }
                        else
                        {
                            try
                            {
                                sc.IsLoginUser(item.Kid);
                                sc.SubmitChanges();

                            }
                            catch (Exception ex)
                            {
                                Hata(ex);
                            }
                            finally
                            {
                                kayitSayisi = item.Kid;
                            }

                        }
                    }
                }

                else
                {
                    HataVar("Bilgiler Hatali");
                }
            }
            catch (Exception ex)
            {
                Hata(ex);
            }

            return kayitSayisi;
        }

        public void Logout(int UserId)
        {
            try
            {
                var query = (from k in sc.Kullanicis where k.Kid == UserId select k).Single();
                query.isLogin = 1;
                sc.SubmitChanges();

            }
            catch (Exception ex)
            {

                Hata(ex);
            }
        }

        public int EtkinlikAc(string etkinlikAd, int tipId, int mekanId, DateTime etkinlikTarihi, int kontenjan, int sporId)
        {
            int kayitSayisi = 0;
            try
            {
                Etkinlik e = new Etkinlik();
                if (!string.IsNullOrEmpty(etkinlikAd) && !string.IsNullOrEmpty(etkinlikTarihi.ToString()) && !string.IsNullOrEmpty(kontenjan.ToString()))
                    {

                    e.EtkinlikAdi = etkinlikAd;
                    e.TipId = tipId;
                    e.MekanID = mekanId;
                    e.EtkinlikTarihi = etkinlikTarihi;
                    e.Kontenjan = kontenjan;
                    e.Sid = sporId;
                    e.isActive = 1;
                    sc.Etkinliks.InsertOnSubmit(e);
                    sc.SubmitChanges();
                    kayitSayisi = 1;

                   }
                else
                {
                    HataVar("Lütfen boş alanlara değer girin!");
                    kayitSayisi = -1;
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return kayitSayisi;
        }

        public int MekanAc(string mekanAdi, int ilceId)
        {
            int kayitSayisi = 0;
            try
            {
                Mekan m = new Mekan();
                if (!string.IsNullOrEmpty(mekanAdi))
                {
                    m.MekanAdi = mekanAdi;
                    m.IlceId = ilceId;
                    sc.Mekans.InsertOnSubmit(m);
                    sc.SubmitChanges();
                    kayitSayisi = 1;
                }
                else
                {
                    
                    kayitSayisi = -1;
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return kayitSayisi;
        }

        public int Katil(int eid, int kid)
        {
            int kayitSayisi = 0;
            try
            {
                Katilanlar k = new Katilanlar();
                k.Eid = eid;
                k.Kid = kid;
                sc.Katilanlars.InsertOnSubmit(k);
                sc.SubmitChanges();
                kayitSayisi = 1;

            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return kayitSayisi;
        }

        public int Cikis(int EtkinlikId, int UserId)
        {
            int kayitSayisi = 0;
            try
            {
                var query = (from k in sc.Katilanlars where k.Eid == EtkinlikId select k).ToList();
                foreach (Katilanlar katilan in query)
                {
                    if (katilan.Kid == UserId)
                    {
                        var delete = (from k in sc.Katilanlars where k.Eid == EtkinlikId && k.Kid == UserId select k).Single();
                        sc.Katilanlars.DeleteOnSubmit(delete);
                        sc.SubmitChanges();
                        kayitSayisi = 1;
                    }
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return kayitSayisi;
        }

        public int EtkinlikKisiKontrol(int EtkinlikId, int UserId)
        {
            int ret = 0;
            try
            {
                var query = (from k in sc.Katilanlars where k.Eid == EtkinlikId select k).ToList();
                foreach (Katilanlar kisi in query)
                {
                    if (kisi.Kid == UserId)
                    {
                        ret = 1;
                    }
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }
            return ret;
        }

        public IEnumerable<Sporlar> SporGetir()
        {
            IEnumerable<Sporlar> sporlar = null;
            try
            {
                var query = from s in sc.Sporlars select s;
                sporlar = query.ToList<Sporlar>();

                if (sporlar.Count() > 0)
                {
                    return sporlar;
                }
                else
                {
                    HataVar("Kayitli Spor Yok");
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return sporlar;
        }

        public IEnumerable<Iller> IlGetir()
        {
            IEnumerable<Iller> ıller = null;
            try
            {
                var query = from i in sc.Illers select i;
                ıller = query.ToList<Iller>();
                if (ıller.Count() > 0)
                {
                    return ıller;
                }
                else
                {
                    HataVar("Kayıtlı il bulunamadı");
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return ıller;
        }

        public IEnumerable<Ilceler> IlceGetir(int sehirId)
        {
            IEnumerable<Ilceler> ılceler = null;
            try
            {
                var query = from i in sc.Ilcelers
                            where i.Sehir == sehirId
                            select i;

                ılceler = query.ToList<Ilceler>();

                if (ılceler.Count() > 0)
                {
                    return ılceler;
                }
                else
                {
                    HataVar("Kayıtlı ilçe bulunamadı");
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return ılceler;
        }

        public IEnumerable<EtkinlikAlResult> EtkinlikGetir()
        {
            IEnumerable<EtkinlikAlResult> etkinlikler = null;
            try
            {
                etkinlikler = sc.EtkinlikAl().ToList();
                if (etkinlikler.Count() > 0)
                {
                    return etkinlikler;
                }

                else
                {
                    HataVar("Kayıtlı etkinlik bulunamadı");
                }

            }
            catch (Exception ex)
            {

                Hata(ex);
            }
            return etkinlikler;
        }

        public IEnumerable<EtkinlikTipi> EtkinlikTipGetir()
        {
            IEnumerable<EtkinlikTipi> etkinlikTipler = null;
            try
            {
                var query = from etip in sc.EtkinlikTipis select etip;
                etkinlikTipler = query.ToList<EtkinlikTipi>();
                if (etkinlikTipler.Count() > 0)
                {
                    return etkinlikTipler;
                }

                else
                {
                    HataVar("Kayıtlı etkinliktipi bulunamadı");
                }

            }
            catch (Exception ex)
            {

                Hata(ex);
            }

            return etkinlikTipler;
        }

        public IEnumerable<Mekan> MekanGetir()
        {
            IEnumerable<Mekan> mekanlar = null;
            try
            {
                var query = from m in sc.Mekans select m;
                mekanlar = query.ToList<Mekan>();
                if (mekanlar.Count() > 0)
                {
                    return mekanlar;
                }
                else
                {
                    HataVar("Kayıtlı mekan bulunamadı");
                }
            }
            catch (Exception ex)
            {

                Hata(ex);
            }
            return mekanlar;
        }

        public void Hata(Exception ex)
        {
            StackTrace stack = new StackTrace(true);
            foreach (StackFrame frame in stack.GetFrames())
            {
                if (!string.IsNullOrEmpty(frame.GetFileName()))
                {
                    HataLoglari hata = new HataLoglari();
                    hata.DosyaAdi = Path.GetFileName(frame.GetFileName());
                    hata.MethodAdi = frame.GetMethod().ToString();
                    hata.LineNumber = frame.GetFileLineNumber();
                    hata.ColumnNumber = frame.GetFileColumnNumber();
                    hata.Message = ex.Message.ToString();
                    sc.HataLoglaris.InsertOnSubmit(hata);
                    sc.SubmitChanges();


                }
            }
        }

        public void HataVar(string mesaj)
        {
            StackTrace stack = new StackTrace(true);
            foreach (StackFrame frame in stack.GetFrames())
            {
                if (!string.IsNullOrEmpty(frame.GetFileName()))
                {
                    HataLoglari hata = new HataLoglari();
                    hata.DosyaAdi = Path.GetFileName(frame.GetFileName());
                    hata.MethodAdi = frame.GetMethod().ToString();
                    hata.LineNumber = frame.GetFileLineNumber();
                    hata.ColumnNumber = frame.GetFileColumnNumber();
                    hata.Message = mesaj;
                    sc.HataLoglaris.InsertOnSubmit(hata);
                    sc.SubmitChanges();

                }
            }
        }
    }
}
