using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Armando_ClassJualBeli;

namespace Armando_SistemJualBeli
{
    public partial class FormDaftarSupplier : Form
    {
        public FormDaftarSupplier()
        {
            InitializeComponent();
        }

        public List<Supplier> listSupplier = new List<Supplier>();

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSupplier tambahSupplier = new FormTambahSupplier();
            tambahSupplier.Owner = this;
            tambahSupplier.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahSupplier ubahSupplier = new FormUbahSupplier();
            ubahSupplier.Owner = this;
            ubahSupplier.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusSupplier hapusSupplier = new FormHapusSupplier();
            hapusSupplier.Owner = this;
            hapusSupplier.Show();
        }

        public void FormDaftarSupplier_Load(object sender, EventArgs e)
        {
            listSupplier = Supplier.BacaDataSupplier("", "");

            if (listSupplier.Count > 0)
            {
                dataGridViewSupplier.DataSource = listSupplier;
            }
            else
            {
                dataGridViewSupplier.DataSource = null;
            }
        }

        private void textBoxSupplier_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSupplier.Text == "Kode Supplier")
            {
                listSupplier = Supplier.BacaDataSupplier("KodeSupplier", textBoxSupplier.Text);
            }
            else if (comboBoxSupplier.Text == "Nama Supplier")
            {
                listSupplier = Supplier.BacaDataSupplier("Nama", textBoxSupplier.Text);
            }
            else if (comboBoxSupplier.Text == "Alamat Supplier")
            {
                listSupplier = Supplier.BacaDataSupplier("Alamat", textBoxSupplier.Text);
            }

            if (listSupplier.Count > 0)
            {
                dataGridViewSupplier.DataSource = listSupplier;
            }
            else
            {
                dataGridViewSupplier.DataSource = null;
            }
        }
    }
}
