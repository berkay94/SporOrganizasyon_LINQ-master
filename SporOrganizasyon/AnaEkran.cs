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

namespace SporOrganizasyon
{
    public partial class AnaEkran : Form
    {
        public string Username { get; set; }
        public int Userid { get; set; }

        BusinessLogic bl;
        Linq linq;

        public AnaEkran(string username, int userid)
        {
            InitializeComponent();
            bl = new BusinessLogic();
            linq = new Linq();
            Username = username;
            Userid = userid;
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            //DapperEtkinlikYukle();

            LinqEtkinlikYukle();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[6].HeaderText = "Ilce";

        }

        private void AnaEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void buttonMekan_Click(object sender, EventArgs e)
        {
            Mekan mekan = new Mekan();
            this.Hide();
            mekan.ShowDialog();
            this.Show();
        }

        private void buttonEtkinlik_Click(object sender, EventArgs e)
        {

           // DapperEtkinlikAl();

            LinqEtkinlikGetir();
           
           
        }

        private void buttonKatil_Click(object sender, EventArgs e)
        {
            
            try
            {
                //DapperEtkinlikKatil();
                LinqEtkinlikKatil();
            }
            catch
            {
                MessageBox.Show("Lütfen etkinllik seçin!");
            }
        }

       

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            buttonKatil.Enabled = true;
            buttonEtkinlikCik.Enabled = true;
        }

        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //bl.Logout(Userid);
            
            linq.Logout(Userid);
        }

        private void buttonEtkinlikCik_Click(object sender, EventArgs e)
        {
            try
            {
               //DapperEtkinlikCik();

              LinqEtkinlikCik();
            }
            catch
            {
                MessageBox.Show("Lütfen etkinllik seçin!");
            }

        }

        public void DapperEtkinlikYukle()
        {
            dataGridView1.DataSource = bl.EtkinlikAl();
            dataGridView1.Columns["EtkinlikId"].Visible = false;
            labelGiris.Text = Username;
        }

        public void LinqEtkinlikYukle()
        {
            dataGridView1.DataSource = linq.EtkinlikGetir();
            dataGridView1.Columns["EtkinlikId"].Visible = false;
            labelGiris.Text = Username;
        }

        public void DapperEtkinlikAl()
        {

            Etkinlik etkinlik = new Etkinlik();
            this.Hide();
            etkinlik.ShowDialog();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.EtkinlikAl();
            dataGridView1.Columns["EtkinlikId"].Visible = false;
            this.Show();
        }

        public void LinqEtkinlikGetir()
        {
            Etkinlik etkinlik = new Etkinlik();
            this.Hide();
            etkinlik.ShowDialog();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = linq.EtkinlikGetir();
            dataGridView1.Columns["EtkinlikId"].Visible = false;
            this.Show();
        }

        public void DapperEtkinlikKatil()
        {
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["Kontenjan"].Value) <= Convert.ToInt32(dataGridView1.CurrentRow.Cells["Katilanlar"].Value))
            {
                MessageBox.Show("Yer Yok");
            }
            else
            {

                if (bl.EtkinlikKisiKontrol(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid) > 0)
                {
                    MessageBox.Show("Bu Etkinliğe önceden Kayit olmuşsunuz...");
                }

                else
                {

                    int k = bl.Katil(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid);
                    if (k > 0)
                    {
                        MessageBox.Show("Etkinliğe Katıldınız");
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = linq.EtkinlikGetir();
                        dataGridView1.Columns["EtkinlikId"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Problem Oluştu");
                    }
                }

            }
        }

        public void DapperEtkinlikCik()
        {
            if (bl.Cikis(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid) > 0)
            {
                MessageBox.Show("Bu Etkinlikten Çıktınız...");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.EtkinlikAl();
                dataGridView1.Columns["EtkinlikId"].Visible = false;
            }
            else
            {
                MessageBox.Show("Zaten Bu Olaya Katilmamışsınız...");
            }
        }

        public void LinqEtkinlikKatil()
        {
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["Kontenjan"].Value) <= Convert.ToInt32(dataGridView1.CurrentRow.Cells["Katilanlar"].Value))
            {
                MessageBox.Show("Yer Yok");
            }
            else
            {
                if (linq.EtkinlikKisiKontrol(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid) > 0)
                {
                    MessageBox.Show("Bu Etkinliğe önceden Kayit olmuşsunuz...");
                }
                else
                {
                    int k = linq.Katil(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid);
                    if (k > 0)
                    {
                        MessageBox.Show("Etkinliğe Katıldınız");
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = linq.EtkinlikGetir();
                        dataGridView1.Columns["EtkinlikId"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Problem Oluştu");
                    }
                }
            }
        }

        public void LinqEtkinlikCik()
        {
            if (linq.Cikis(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), Userid) > 0)
            {
                MessageBox.Show("Bu Etkinlikten Çıktınız...");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = linq.EtkinlikGetir();
                dataGridView1.Columns["EtkinlikId"].Visible = false;
            }
            else
            {
                MessageBox.Show("Zaten Bu Olaya Katilmamışsınız...");
            }
        }

       




    }
}
