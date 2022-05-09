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
    public partial class FormDaftarPelanggan : Form
    {
        public FormDaftarPelanggan()
        {
            InitializeComponent();
        }

        public List<Pelanggan> listPelanggan = new List<Pelanggan>();

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPelanggan tambahPelanggan = new FormTambahPelanggan();
            tambahPelanggan.Owner = this;
            tambahPelanggan.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPelanggan ubahPelanggan = new FormUbahPelanggan();
            ubahPelanggan.Owner = this;
            ubahPelanggan.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPelanggan hapusPelanggan = new FormHapusPelanggan();
            hapusPelanggan.Owner = this;
            hapusPelanggan.Show();
        }

        public void FormDaftarPelanggan_Load(object sender, EventArgs e)
        {
            listPelanggan = Pelanggan.BacaDataPelanggan("", "");

            if (listPelanggan.Count > 0)
            {
                dataGridViewPelanggan.DataSource = listPelanggan;
            }
            else
            {
                dataGridViewPelanggan.DataSource = null;
            }
        }

        private void textBoxPelanggan_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxPelanggan.Text == "Kode Pelanggan")
            {
                listPelanggan = Pelanggan.BacaDataPelanggan("KodePelanggan", textBoxPelanggan.Text);
            }
            else if (comboBoxPelanggan.Text == "Nama Pelanggan")
            {
                listPelanggan = Pelanggan.BacaDataPelanggan("Nama", textBoxPelanggan.Text);
            }
            else if(comboBoxPelanggan.Text == "Alamat Pelanggan")
            {
                listPelanggan = Pelanggan.BacaDataPelanggan("Alamat", textBoxPelanggan.Text);
            }
            else if(comboBoxPelanggan.Text == "Telepon Pelanggan")
            {
                listPelanggan = Pelanggan.BacaDataPelanggan("Telepon", textBoxPelanggan.Text);
            }

            if (listPelanggan.Count > 0)
            {
                dataGridViewPelanggan.DataSource = listPelanggan;
            }
            else
            {
                dataGridViewPelanggan.DataSource = null;
            }
        }
    }
}
