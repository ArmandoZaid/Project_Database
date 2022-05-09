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
    public partial class FormHapusPegawai : Form
    {
        public FormHapusPegawai()
        {
            InitializeComponent();
        }

        List<Pegawai> listPegawai = new List<Pegawai>();
        List<Jabatan> listJabatan = new List<Jabatan>();

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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Data Pegawai akan terhapus, Apakah anda yakin ?", "Konfirmasi", MessageBoxButtons.YesNo);
            if(DialogResult != DialogResult.No)
            {
                try
                {
                    Jabatan jabatan = (Jabatan)comboBoxJabatan.SelectedItem;
                    Pegawai p = new Pegawai(textBoxAlamat.Text, int.Parse(textBoxGaji.Text), int.Parse(textBoxKodePegawai.Text), textBoxNamaPegawai.Text, textBoxPassword.Text, dateTimePickerTanggalLahir.Value, textBoxUsername.Text, jabatan);
                    Pegawai.HapusPegawai(p);
                    MessageBox.Show("Data Pegawai berhasil diHapus.", "Informasi");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Hapus data gagal. Pesan Kesalahan : " + ex.Message, "Informasi");
                }
            }
        }

        private void FormHapusPegawai_Load(object sender, EventArgs e)
        {
            listJabatan = Jabatan.BacaData("", "");

            comboBoxJabatan.DataSource = listJabatan;
            comboBoxJabatan.DisplayMember = "NamaJabatan";

            comboBoxJabatan.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxKodePegawai.MaxLength = 11;
            textBoxNamaPegawai.MaxLength = 45;
            textBoxAlamat.MaxLength = 100;
        }

        
    }
}
