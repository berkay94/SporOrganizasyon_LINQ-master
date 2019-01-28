using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL;
using BLL;
using LINQ;


namespace SporOrganizasyon
{ 

    public partial class Mekan : Form
    {
        BusinessLogic bl;
        Linq linq;
        public Mekan()
        {
            InitializeComponent();
            bl = new BusinessLogic();
            linq = new Linq();
           
        }

        private void Mekan_Load(object sender, EventArgs e)
        {
            // DapperIlveIlceGetir();

            LinqIlveIlceGetir();
     
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // DapperMekanEkle();

            LinqMekanEkle();
        }


        public void DapperIlveIlceGetir()
        {
            foreach (DAL.Iller il in bl.Iller())
            {
                TreeNode node = new TreeNode(il.Sehir);
                node.Tag = il.Id;
                treeViewKonum.Nodes.Add(node);
                foreach (Ilce ilce in bl.Ilceler(il.Id))
                {
                    TreeNode Altnode = new TreeNode(ilce.Ad);
                    Altnode.Tag = ilce.Id;
                    node.Nodes.Add(Altnode);
                }
            }
        }

        public void LinqIlveIlceGetir()
        {
            foreach (LINQ.Iller il in linq.IlGetir())
            {
                TreeNode node = new TreeNode(il.Sehir);
                node.Tag = il.Id;
                treeViewKonum.Nodes.Add(node);
                foreach (LINQ.Ilceler ilce in linq.IlceGetir(il.Id))
                {
                    TreeNode Altnode = new TreeNode(ilce.Ad);
                    Altnode.Tag = ilce.Id;
                    node.Nodes.Add(Altnode);
                }
            }
        }

        public void DapperMekanEkle()
        {
            int k = bl.MekanAc(txtMekanAdi.Text, Convert.ToInt32(treeViewKonum.SelectedNode.Tag));

            if (k > 0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }
            else if (k < 0)
            {
                MessageBox.Show("Mekan adini girin!");
            }
            else
            {

                MessageBox.Show("Girilen Değerlerde Eksiklik Var!!");
            }

        }

        public void LinqMekanEkle()
        {
            int k = linq.MekanAc(txtMekanAdi.Text, Convert.ToInt32(treeViewKonum.SelectedNode.Tag));

            if (k > 0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }

            else if(k<0)
            {
                MessageBox.Show("Mekan adini girin!");
            }
            else
            {

                MessageBox.Show("Girilen Değerlerde Eksiklik Var!!");
            }
        }
    }
}
