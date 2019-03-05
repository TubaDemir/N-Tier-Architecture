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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboKategori.DisplayMember = "CategoryName";
            comboKategori.ValueMember = "CategoryID";
            comboKategori.DataSource = Categories.Select();

            comboTedarikci.DisplayMember = "CompanyName";
            comboTedarikci.ValueMember = "SupplierID";
            comboTedarikci.DataSource = Suppliers.Select();
            dataGridView1.DataSource = Products.Select();
        }

        private void UrunListele()
        {
            dataGridView1.DataSource = Products.Select();
            dataGridView1.Columns["ProductID"].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = txtProductName.Text;
            p.UnitPrice = nudFiyat.Value;
            p.UnitsInStock = Convert.ToInt16( nudStok.Value );
            p.CategoryID = (int)comboKategori.SelectedValue;
            p.SupplierID = (int)comboTedarikci.SelectedValue;
            if (Products.Insert(p))
            {
                MessageBox.Show("Kayit basariyla eklenmistir.");
                UrunListele();
            }
            else
            {
                MessageBox.Show("Kayit eklenirken hata olusmustur.");
            }
        }
    }
}
