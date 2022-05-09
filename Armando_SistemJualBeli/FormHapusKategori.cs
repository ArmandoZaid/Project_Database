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
    public partial class FormHapusKategori : Form
    {
        public FormHapusKategori()
        {
            InitializeComponent();
        }

        List<Kategori> listKategori = new List<Kategori>();

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data kategori akan terhapus, Apakah anda yakin? ", "Konfirmasi", MessageBoxButtons.YesNo);
            if(konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Kategori k = new Kategori(textBoxKodeKategori.Text, textBoxNamaKategori.Text);
                    Kategori.HapusData(k);

                    MessageBox.Show("Data kategori telah dihapus", "Info");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Penghapusan telah gagal, Pesan kesalahan : " + ex.Message, "Kesalahan");
                }
            }
        }

        private void textBoxKodeKategori_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodeKategori.Text.Length == textBoxKodeKategori.MaxLength)
            {
                listKategori = Kategori.BacaDataKategori("KodeKategori", textBoxKodeKategori.Text);

                if (listKategori.Count > 0)
                {
                    textBoxNamaKategori.Text = listKategori[0].Nama;
                    textBoxNamaKategori.Enabled = false;
                    textBoxNamaKategori.Focus();
                }
                else
                {
                    MessageBox.Show("Kode Kategori Tidak ditemukan", "Kesalahan");
                    textBoxKodeKategori.Text = "";
                }
            }
        }

        private void FormHapusKategori_Load(object sender, EventArgs e)
        {
            textBoxKodeKategori.MaxLength = 2;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKategori formDaftarKategori = (FormDaftarKategori)this.Owner;
            formDaftarKategori.FormDaftarKategori_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
