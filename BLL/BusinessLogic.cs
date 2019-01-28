using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BusinessLogic
    {
        DataAccess da;

        public int UserId { get; set; }

        public BusinessLogic()
        {
            da = new DataAccess();
        }

        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public int LoginKontrol(string email, string sifre)
        {
            int ret = 0;

            Kullanici k = new Kullanici();
            

            bool kontrol = EmailKontrol(email);
            if ( kontrol && !string.IsNullOrEmpty(sifre))
            {
                k.Email = email;
                k.Sifre = sifre;

                UserId = da.LoginKontrol(k);
                ret = UserId;
                k.Kid = UserId;

            }
            else
            {
                da.HataVar("Uygun Email değil!!!");
                ret = -1;
            }

            return ret;
        }

        public void Logout(int Userid)
        {
            da.Logout(Userid);
        }

        public int KullaniciKaydet(string ad,string soyad,string email,string telefon,string sifre,string ilce,DateTime dogumtarihi,int cinsiyet,int[] spor)
        {
            int kayitSayisi;
            Kullanici k = new Kullanici();
            bool kontrol = EmailKontrol(email);

            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(soyad) && kontrol)
            {
                k.Ad = ad;
                k.Soyad = soyad;
                k.Email = email;
                k.Telefon = telefon;
                k.Sifre = sifre;
                k.Ilce = ilce;
                k.DogumTarihi = dogumtarihi;
                k.Cinsiyet = cinsiyet;
                kayitSayisi = da.KullaniciKaydet(k,spor);
            }

            else
            {
                kayitSayisi = -1;
            }

            return kayitSayisi;
        }

        public int EtkinlikAc(string etkinlikAd,int tipId,int mekanId,DateTime etkinlikTarihi,int kontenjan,int sporId)
        {
            int kayitSayisi;
            Etkinlikler e = new Etkinlikler();
            if (!string.IsNullOrEmpty(etkinlikAd)&& !string.IsNullOrEmpty(etkinlikTarihi.ToString()))
            {
                e.EtkinlikAdi = etkinlikAd;
                e.TipId = tipId;
                e.MekanId = mekanId;
                e.EtkinlikTarihi = etkinlikTarihi;
                e.Kontenjan = kontenjan;
                e.Sid = sporId;
                e.IsActive = 1;
                kayitSayisi = da.EtkinlikAc(e);
            }

            else
            {
                kayitSayisi = -1;
            }

            return kayitSayisi;
        }

        public int MekanAc(string mekanAdi, int ilceId)
        {
            int kayitSayisi;
            Mekanlar m = new Mekanlar();
            if (!string.IsNullOrEmpty(mekanAdi))
            {
                m.MekanAdi = mekanAdi;
               
                m.IlceId = ilceId;
                kayitSayisi = da.MekanAc(m);
            }
            else
            {
                kayitSayisi = -1;
            }

            return kayitSayisi;
        }

        public List<Sporlar> SporAl()
        {


            var spor = da.SporGetir();

            return spor;
        }

        public List<Iller> Iller()
        {


            var il = da.IlAl();

            return il;
        }

        public List<Ilce> Ilceler(int sehir)
        {
           
            
            var ilce = da.IlceAl(sehir);

            return ilce;
        }

        public List<EtkinlikGoster> EtkinlikAl()
        {
            var etkinlik = da.EtkinlikAl();
            return etkinlik;
        }
        public List<EtkinlikTip> EtkinlikTipAl()
        {
            var etip = da.EtkinlikTipAl();
            return etip;
        }
        public List<Mekanlar> MekanAl()
        {
            var mekan = da.MekanAl();
            return mekan;
        }
        
        public int Katil(int eid, int kid)
        {
            return da.Katil(eid, kid);
        }

        public int Cikis(int eid, int kid)
        {
            return da.Cikis(eid, kid);
        }

        public int EtkinlikKisiKontrol(int EtkinlikId, int UserId)
        {
            int ret = 0;

            ret = da.EtkinlikKisiKontrol(EtkinlikId, UserId);

            return ret;
        }
    }


    
}
