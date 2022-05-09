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
    public partial class FormUbahPegawai : Form
    {
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        List<Pegawai> listPegawai = new List<Pegawai>();
        List<Jabatan> listJabatan = new List<Jabatan>();

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Jabatan jabatan = (Jabatan)comboBoxJabatan.SelectedItem;
                Pegawai p = new Pegawai(textBoxAlamat.Text, int.Parse(textBoxGaji.Text), int.Parse(textBoxKodePegawai.Text), textBoxNamaPegawai.Text, textBoxPassword.Text, dateTimePickerTanggalLahir.Value, textBoxUsername.Text, jabatan);
                Pegawai.UbahPegawai(p);
                MessageBox.Show("Data Pegawai berhasil diUbah.", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ubah data gagal. Pesan Kesalahan : " + ex.Message, "Informasi");
            }
        }

        private void textBoxKodePegawai_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKodePegawai.Text.Length <= textBoxKodePegawai.MaxLength)
            {
                listPegawai = Pegawai.BacaData("KodePegawai", textBoxKodePegawai.Text);
                if (listPegawai.Count > 0)
                {
                    textBoxNamaPegawai.Text = listPegawai[0].Nama;
                    textBoxGaji.Text = listPegawai[0].Gaji.ToString();
                    textBoxUsername.Text = listPegawai[0].Username;
                    textBoxPassword.Text = listPegawai[0].Password;
                    textBoxAlamat.Text = listPegawai[0].Alamat;
                    dateTimePickerTanggalLahir.Value = listPegawai[0].TanggalLahir;
                }
            }
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            textBoxKodePegawai.MaxLength = 5;
            textBoxNamaPegawai.MaxLength = 45;

            listJabatan = Jabatan.BacaData("", "");

            comboBoxJabatan.DataSource = listJabatan;
            comboBoxJabatan.DisplayMember = "NamaJabatan";

            comboBoxJabatan.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
