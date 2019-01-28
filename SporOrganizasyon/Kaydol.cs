using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using LINQ;


namespace SporOrganizasyon
{
    public partial class Kaydol : Form
    {
        BusinessLogic bl;
        Linq linq;
        DataAccess dal;
        
        public Kaydol()
        {
            InitializeComponent();
            bl = new BusinessLogic();
            dal = new DataAccess();
            linq = new Linq();
        }

        private void groupBoxKullanici_Enter(object sender, EventArgs e)
        {

        }
        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void Kaydol_Load(object sender, EventArgs e)
        {

           // DapperSporAl();

            LinqSporGetir();
            
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
           //  DapperKaydol();

            LinqKaydol();
            
        }

        private void comboBoxCins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCins.SelectedIndex==0)
            {
                comboBoxCins.ValueMember = "0";
            }
            else
            {
                comboBoxCins.ValueMember = "1";
            }
        }

        public void DapperSporAl()
        {
            foreach (var spor in bl.SporAl())
            {
                checkedListBoxSpor.Items.Add(spor);

                checkedListBoxSpor.DisplayMember = "SporAdi";
            }
        }

        public void LinqSporGetir()
        {
            foreach (var spor in linq.SporGetir())
            {
                checkedListBoxSpor.Items.Add(spor);

                checkedListBoxSpor.DisplayMember = "SporAdi";
            }
        }

        public void DapperKaydol()
        {
            int[] sporlar = new int[checkedListBoxSpor.CheckedItems.Count];
            for (int i = 0; i < sporlar.Length; i++)
            {
                DAL.Sporlar castedItem = checkedListBoxSpor.CheckedItems[i] as DAL.Sporlar;
                sporlar[i] = castedItem.SporId;
            }

            int k = bl.KullaniciKaydet(txtAd.Text, txtSoyad.Text, txtEmail.Text, maskedTelefon.Text, txtSifre.Text, txtIlce.Text, Convert.ToDateTime(dateTimeTrh.Text), Convert.ToInt32(comboBoxCins.ValueMember), sporlar);

            bool kontrol = EmailKontrol(txtEmail.Text);

            if (k > 0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }
            else if (!kontrol)
            {
                MessageBox.Show("Email uygun biçimde değil!");
            }
            else
            {

                MessageBox.Show("Girilen Değerlerde Eksiklik Var!!");
            }
        }

        public void LinqKaydol()
        {
            int[] sporlar = new int[checkedListBoxSpor.CheckedItems.Count];
            for (int i = 0; i < sporlar.Length; i++)
            {
                LINQ.Sporlar castedItem = checkedListBoxSpor.CheckedItems[i] as LINQ.Sporlar;
                sporlar[i] = castedItem.SporId;
            }

           
            int k = linq.KullaniciKaydet(txtAd.Text, txtSoyad.Text, txtEmail.Text, maskedTelefon.Text, txtSifre.Text, txtIlce.Text, Convert.ToDateTime(dateTimeTrh.Text), Convert.ToInt32(comboBoxCins.ValueMember), sporlar);

            bool kontrol = EmailKontrol(txtEmail.Text);

            if (k > 0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }

            else if(!kontrol)
            {
                MessageBox.Show("Email uygun biçimde değil!");
            }
            else
            {

                MessageBox.Show("Girilen Değerlerde Eksiklik Var!!");
            }
        }


    }
}
