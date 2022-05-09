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
    public partial class FormDaftarKategori : Form
    {
        public FormDaftarKategori()
        {
            InitializeComponent();
        }

        public List<Kategori> listKategori = new List<Kategori>();

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKategori tambahKategori = new FormTambahKategori();
            tambahKategori.Owner = this;
            tambahKategori.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKategori ubahKategori = new FormUbahKategori();
            ubahKategori.Owner = this;
            ubahKategori.Show();

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKategori hapusKategori = new FormHapusKategori();
            hapusKategori.Owner = this;
            hapusKategori.Show();
        }

        public void FormDaftarKategori_Load(object sender, EventArgs e)
        {
            listKategori = Kategori.BacaDataKategori("", "");

            if(listKategori.Count > 0)
            {
                dataGridViewKategori.DataSource = listKategori;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }

        private void textBoxKategori_TextChanged(object sender, EventArgs e)
        {
            if(comboBoxKategori.Text == "Kode Kategori")
            {
                listKategori = Kategori.BacaDataKategori("KodeKategori", textBoxKategori.Text);
            }
            else if(comboBoxKategori.Text == "Nama Kategori")
            {
                listKategori = Kategori.BacaDataKategori("Nama", textBoxKategori.Text);
            }

            if(listKategori.Count > 0)
            {
                dataGridViewKategori.DataSource = listKategori;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }
    }
}
