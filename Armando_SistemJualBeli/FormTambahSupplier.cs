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
    public partial class FormTambahSupplier : Form
    {
        public FormTambahSupplier()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier s = new Supplier(textBoxAlamat.Text, textBoxKode.Text, textBoxNama.Text);

                Supplier.TambahData(s);

                MessageBox.Show("Data Supplier telah disimpan.", "Info");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Penyimpanan gagal. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarSupplier formDaftarSupplier = (FormDaftarSupplier)this.Owner;
            formDaftarSupplier.FormDaftarSupplier_Load(buttonKeluar, e);

            this.Close();
        }

        private void FormTambahSupplier_Load(object sender, EventArgs e)
        {
            string kodeTerbaru = Supplier.GenerateKode();

            textBoxKode.Text = kodeTerbaru;
            textBoxKode.Enabled = false;
            textBoxNama.Focus();
        }
    }
}
