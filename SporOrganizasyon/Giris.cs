using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using LINQ;
using System.Text.RegularExpressions;

namespace SporOrganizasyon
{
    public partial class Giris : Form
    {
        BusinessLogic bl;
        Linq linq;
        public Giris()
        {
            InitializeComponent();
            bl = new BusinessLogic();
            linq = new Linq();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

           // DapperLoginKontrol();

            LinqLoginKontrol();
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            Kaydol form = new Kaydol();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        private void txtKullanici_Click(object sender, EventArgs e)
        {
            if(txtKullanici.Text=="Kullanıcı Adı")
            txtKullanici.Clear();
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            txtSifre.Clear();
            txtSifre.PasswordChar = '*';
            
            
        }

       
        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
                txtSifre.Clear();
            txtSifre.PasswordChar = '*';
        }


        public void DapperLoginKontrol()
        {
            int id = bl.LoginKontrol(txtKullanici.Text, txtSifre.Text);
            bool kontrol = EmailKontrol(txtKullanici.Text);
            if (id > 0)
            {

                MessageBox.Show("Giriş Başarılı");
                this.Hide();
                AnaEkran anaEkran = new AnaEkran(txtKullanici.Text, id);
                anaEkran.ShowDialog();
                this.Close();
            }
            else if (!kontrol)
            {
                MessageBox.Show("Email düzgün biçimde değil");
            }
            else if (id == -2)
            {
                MessageBox.Show("Böyle Bir Kullanici Şu Anda Online. Çıkış Yapmadan Giremezsin");
            }

            
            else
                MessageBox.Show("Giriş Başarısız");
        }

        public void LinqLoginKontrol()
        {

            int id = linq.LoginKontrol(txtKullanici.Text, txtSifre.Text);
            bool kontrol = EmailKontrol(txtKullanici.Text);
            if (id > 0)
            {
                MessageBox.Show("Giriş Başarılı");
                this.Hide();
                AnaEkran anaEkran = new AnaEkran(txtKullanici.Text, id);
                anaEkran.ShowDialog();
                this.Close();
            }
            else if(!kontrol)
            {
                MessageBox.Show("Email düzgün biçimde değil");
            }

            else if (id == -2)
            {
                MessageBox.Show("Böyle Bir Kullanici Şu Anda Online. Çıkış Yapmadan Giremezsin");
            }
            else
                MessageBox.Show("Giriş Başarısız");
        }

        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

       

    } 
}
