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
    public partial class FormUbahPelanggan : Form
    {
        public FormUbahPelanggan()
        {
            InitializeComponent();
        }

        List<Pelanggan> listPelanggan = new List<Pelanggan>();

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Pelanggan p = new Pelanggan(textBoxAlamat.Text, textBoxKode.Text, textBoxNama.Text, textBoxTelepon.Text);

                Pelanggan.UbahData(p);

                MessageBox.Show("Data Pelanggan telah dubah.", "Info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormUbahPelanggan_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 2;
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

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan formDaftarPelanggan = (FormDaftarPelanggan)this.Owner;
            formDaftarPelanggan.FormDaftarPelanggan_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
