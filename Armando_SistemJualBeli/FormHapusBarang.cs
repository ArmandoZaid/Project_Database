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
    public partial class FormHapusBarang : Form
    {
        public FormHapusBarang()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus, Apakah anda yakin ?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (konfirmasi == System.Windows.Forms.DialogResult.Yes)
                {
                    Kategori kategoriDipilih = (Kategori)comboBoxBarang.SelectedItem;
                    Barang b = new Barang( textBoxBarcode.Text,int.Parse(textBoxHargaJual.Text), textBoxKodeBarang.Text, textBoxNamaBarang.Text, int.Parse(textBoxStok.Text), kategoriDipilih);
                    Barang.HapusData(b);
                    MessageBox.Show("Data Barang telah terhapus", "Info");
                }
                else
                {
                    MessageBox.Show("Data Barang tidak jadi di hapus", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penghapusan gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormHapusBarang_Load(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarBarang formDaftarBarang = (FormDaftarBarang)this.Owner;
            formDaftarBarang.FormDaftarBarang_Load(buttonKeluar, e);
            formDaftarBarang.Enabled = true;
            this.Close();
        }
    }
}
