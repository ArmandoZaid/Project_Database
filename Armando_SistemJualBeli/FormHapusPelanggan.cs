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
    public partial class FormHapusPelanggan : Form
    {
        public FormHapusPelanggan()
        {
            InitializeComponent();
        }

        List<Pelanggan> listPelanggan = new List<Pelanggan>();

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data Pelanggan akan terhapus, Apakah anda yakin? ", "Konfirmasi", MessageBoxButtons.YesNo);
            if(konfirmasi == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Pelanggan p = new Pelanggan(textBoxAlamat.Text, textBoxKode.Text, textBoxNama.Text, textBoxTelepon.Text);

                    Pelanggan.UbahData(p);

                    MessageBox.Show("Data Pelanggan telah diHapus.", "Info");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Penghapusan telah gagal, Pesan kesalahan : " + ex.Message, "Kesalahan");
                }
            }
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length <= textBoxKode.MaxLength)
            {
                listPelanggan = Pelanggan.BacaDataPelanggan("KodePelanggan", textBoxKode.Text);

                if (listPelanggan.Count > 0)
                {
                    textBoxNama.Text = listPelanggan[0].Nama;
                    textBoxAlamat.Text = listPelanggan[0].Alamat;
                    textBoxTelepon.Text = listPelanggan[0].Telepon;
                    textBoxNama.Enabled = true;
                    textBoxAlamat.Enabled = true;
                    textBoxTelepon.Enabled = true;

                    textBoxNama.Focus();
                }
                else
                {
                    MessageBox.Show("Kode Pelanggan Tidak ditemukan", "Kesalahan");
                    textBoxKode.Text = "";
                }
            }
        }

        private void FormHapusPelanggan_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 2;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan formDaftarPelanggan = (FormDaftarPelanggan)this.Owner;
            formDaftarPelanggan.FormDaftarPelanggan_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
