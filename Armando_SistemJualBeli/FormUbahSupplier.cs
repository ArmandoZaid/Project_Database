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
    public partial class FormUbahSupplier : Form
    {
        public FormUbahSupplier()
        {
            InitializeComponent();
        }

        List<Supplier> listSupplier = new List<Supplier>();

        private void buttonUbah_Click(object sender, EventArgs e)
        {

            try
            {
                Supplier s = new Supplier(textBoxAlamat.Text, textBoxKode.Text, textBoxNama.Text);

                Supplier.TambahData(s);

                MessageBox.Show("Data Supplier telah diubah.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormUbahSupplier_Load(object sender, EventArgs e)
        {
            textBoxKode.MaxLength = 2;
        }

        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKode.Text.Length <= textBoxKode.MaxLength)
            {
                listSupplier = Supplier.BacaDataSupplier("KodeSupplier", textBoxKode.Text);

                if (listSupplier.Count > 0)
                {
                    textBoxNama.Text = listSupplier[0].Nama;
                    textBoxAlamat.Text = listSupplier[0].Alamat;
                    textBoxNama.Enabled = true;
                    textBoxAlamat.Enabled = true;

                    textBoxNama.Focus();
                }
                else
                {
                    MessageBox.Show("Kode Supplier Tidak ditemukan", "Kesalahan");
                    textBoxKode.Text = "";
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier formDaftarSupplier = (FormDaftarSupplier)this.Owner;
            formDaftarSupplier.FormDaftarSupplier_Load(buttonKeluar, e);

            this.Close();
        }
    }
}
