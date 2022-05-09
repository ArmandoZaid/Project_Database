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
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        List<Pegawai> listPegawai = new List<Pegawai>();

        private void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
            FormatGrid();
            listPegawai = Pegawai.BacaData("", "");
            TampilDataGrid();
            TampilComboBox();
            comboBoxPegawai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void FormatGrid()
        {
            dataGridViewPegawai.Columns.Add("KodePegawai", "Kode Pegawai");
            dataGridViewPegawai.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewPegawai.Columns.Add("TglLahir", "Tgl Lahir");
            dataGridViewPegawai.Columns.Add("Alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("Gaji", "Gaji");
            dataGridViewPegawai.Columns.Add("Username", "Username");
            dataGridViewPegawai.Columns.Add("IdJabatan", "Id Jabatan");
            dataGridViewPegawai.Columns.Add("NamaJabatan", "Nama Jabatan");

            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewPegawai.Columns["Gaji"].DefaultCellStyle.Format = "#,###";

            dataGridViewPegawai.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["TglLahir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Gaji"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["IdJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void TampilDataGrid()
        {
            if (listPegawai.Count > 0)
            {
                dataGridViewPegawai.Rows.Clear();

                foreach (Pegawai p in listPegawai)
                { 
                    dataGridViewPegawai.Rows.Add(p.KodePegawai, p.Nama, p.TanggalLahir.ToShortDateString(), p.Alamat, p.Gaji, p.Username, p.Jabatan.IdJabatan, p.Jabatan.NamaJabatan);
                }
            }
            else
            {
                dataGridViewPegawai.DataSource = null;
            }
        }

        private void textBoxPegawai_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxPegawai.Text == "Kode Pegawai")
            {
                kriteria = "P.KodePegawai";
            }
            else if (comboBoxPegawai.Text == "Nama Pegawai")
            {
                kriteria = "P.Nama";
            }
            else if (comboBoxPegawai.Text == "TglLahir")
            {
                kriteria = "P.TglLahir";
            }
            else if (comboBoxPegawai.Text == "Alamat")
            {
                kriteria = "P.Alamat";
            }
            else if (comboBoxPegawai.Text == "Gaji")
            {
                kriteria = "P.Gaji";
            }
            else if (comboBoxPegawai.Text == "Username")
            {
                kriteria = "P.Username";
            }
            else if (comboBoxPegawai.Text == "IdJabatan")
            {
                kriteria = "P.IdJabatan";
            }
            else if (comboBoxPegawai.Text == "Nama Jabatan")
            {
                kriteria = "J.Nama";
            }
            listPegawai = Pegawai.BacaData(kriteria, textBoxPegawai.Text);
            TampilDataGrid();
        }

        public void TampilComboBox()
        {
            comboBoxPegawai.Items.Add("Kode Pegawai");
            comboBoxPegawai.Items.Add("Nama");
            comboBoxPegawai.Items.Add("Tgl Lahir");
            comboBoxPegawai.Items.Add("Alamat");
            comboBoxPegawai.Items.Add("Gaji");
            comboBoxPegawai.Items.Add("Username");
            comboBoxPegawai.Items.Add("Id Jabatan");
            comboBoxPegawai.Items.Add("Nama Jabatan");
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai formTambahPegawai = new FormTambahPegawai();
            formTambahPegawai.Owner = this;
            formTambahPegawai.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPegawai formUbahPegawai = new FormUbahPegawai();
            formUbahPegawai.Owner = this;
            formUbahPegawai.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPegawai formHapusPegawai = new FormHapusPegawai();
            formHapusPegawai.Owner = this;
            formHapusPegawai.Show();
        }
    }
}
