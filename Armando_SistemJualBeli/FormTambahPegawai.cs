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
    public partial class FormTambahPegawai : Form
    {
        public FormTambahPegawai()
        {
            InitializeComponent();
        }

        List<Jabatan> listJabatan = new List<Jabatan>();

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Jabatan jabatan = (Jabatan)comboBoxJabatan.SelectedItem;
                Pegawai p = new Pegawai(textBoxAlamat.Text, int.Parse(textBoxGaji.Text), int.Parse(textBoxKodePegawai.Text), textBoxNamaPegawai.Text, textBoxPassword.Text, dateTimePickerTanggalLahir.Value, textBoxUsername.Text, jabatan);
                Pegawai.TambahPegawai(p);
                MessageBox.Show("Data Pegawai berhasil ditambahkan.", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data pegawai gagal ditambahkan, Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void FormTambahPegawai_Load(object sender, EventArgs e)
        {
            listJabatan = Jabatan.BacaData("", "");

            comboBoxJabatan.DataSource = listJabatan;
            comboBoxJabatan.DisplayMember = "NamaJabatan";

            comboBoxJabatan.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                if(comboBoxJabatan.SelectedIndex != 1)
                {
                    Jabatan jabatan = (Jabatan)comboBoxJabatan.SelectedItem;
                    string kode = Pegawai.GeneratorKode(jabatan);

                    textBoxKodePegawai.Text = kode;
                    textBoxKodePegawai.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Melakukan generate kode. Pesan kesalahan : " + ex.Message);
            }
            textBoxKodePegawai.MaxLength = 11;
            textBoxNamaPegawai.MaxLength = 45;
            textBoxAlamat.MaxLength = 100;
        }
    }
}
