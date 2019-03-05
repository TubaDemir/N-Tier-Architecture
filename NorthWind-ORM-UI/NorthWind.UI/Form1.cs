using NorthWind.ORM.Entity;
using NorthWind.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void KategoriListele()
        {
            dataGridView1.DataSource = Categories.Select();
            dataGridView1.Columns["CategoryID"].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KategoriListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.CategoryName = txtAdi.Text;
            c.Description = txtTanim.Text;
            bool sonuc = Categories.Insert(c);
            if (sonuc)
            {
                MessageBox.Show("Kayit basariyla eklenmistir.");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Kayit eklenirken hata olusmustur.");
            }
        }
    }
}
