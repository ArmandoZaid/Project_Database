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
    public partial class FormTambahPelanggan : Form
    {
        public FormTambahPelanggan()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Pelanggan p = new Pelanggan(textBoxAlamat.Text, textBoxKode.Text, textBoxNama.Text, textBoxTelepon.Text);

                Pelanggan.TambahData(p);

                MessageBox.Show("Data Pelanggan telah disimpan.", "Info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarPelanggan formDaftarPelanggan = (FormDaftarPelanggan)this.Owner;
            formDaftarPelanggan.FormDaftarPelanggan_Load(buttonKeluar, e);

            this.Close();
        }

        private void FormTambahPelanggan_Load(object sender, EventArgs e)
        {
            string kodeTerbaru = Pelanggan.GenerateKode();

            textBoxKode.Text = kodeTerbaru;
            textBoxKode.Enabled = false;
            textBoxNama.Focus();
        }
    }
}
