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
    public partial class FormTambahBarang : Form
    {
        public FormTambahBarang()
        {
            InitializeComponent();
        }

        List<Kategori> listKategori = new List<Kategori>();

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Kategori selectedKategori = (Kategori)comboBoxTambahBarang.SelectedItem;

                Barang b = new Barang(textBoxBarcode.Text, int.Parse(textBoxHargaJual.Text), textBoxKodeBarang.Text, textBoxNamaBarang.Text, int.Parse(textBoxStok.Text), selectedKategori);

                Barang.TambahData(b);

                MessageBox.Show("Data barang berhasil ditambahkan", "informasi");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gagal menambah data. Pesan kesalahan" + ex.Message);
            }
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            //batasan chara yang diinputkan
            textBoxKodeBarang.MaxLength = 5;
            textBoxBarcode.MaxLength = 12;
            textBoxNamaBarang.MaxLength = 45;

            //agar harga jual dan stok rata kanan
            textBoxHargaJual.TextAlign = HorizontalAlignment.Right;
            textBoxStok.TextAlign = HorizontalAlignment.Right;

            //membaca data dari tabel
            listKategori = Kategori.BacaDataKategori("", "");
            //show semua data kategori pada combobox
            //gunakan data binding
            comboBoxTambahBarang.DataSource = listKategori;
            comboBoxTambahBarang.DisplayMember = "Nama";

            comboBoxTambahBarang.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKodeBarang.Text = "";
            textBoxBarcode.Text = "";
            textBoxHargaJual.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxStok.Text = "";
            comboBoxTambahBarang.Focus();
        }

        private void comboBoxTambahBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mendapatkan kategori yang dipilih user dari comboBox
            Kategori selectedKategori = (Kategori)comboBoxTambahBarang.SelectedItem;

            //generate kode barang sesuai kategori yang dipilih
            string kodeBarang = Barang.GenerateKode(selectedKategori);

            //tampilkan ditextBox
            textBoxKodeBarang.Text = kodeBarang;
            textBoxKodeBarang.Enabled = false;
            textBoxBarcode.Focus();
        }
    }
}
