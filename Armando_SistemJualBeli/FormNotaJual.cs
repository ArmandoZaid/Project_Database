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
    public partial class FormNotaJual : Form
    {
        public FormNotaJual()
        {
            InitializeComponent();
        }

        List<NotaJual> listNotaJual = new List<NotaJual>();

        string kriteria = "";

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaJual formTambahNotaJual = new FormTambahNotaJual();
            formTambahNotaJual.Owner = this;
            formTambahNotaJual.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            
        }

        private void FormNotaJual_Load(object sender, EventArgs e)
        {
            FormatGrid();

            listNotaJual = NotaJual.BacaData("", "");

            TampilDataGrid();
        }

        public void FormatGrid()
        {
            dataGridViewNotaJual.Columns.Clear();

            dataGridViewNotaJual.Columns.Add("NoNota", "No Nota");
            dataGridViewNotaJual.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNotaJual.Columns.Add("KodePelanggan", "Kode Plg");
            dataGridViewNotaJual.Columns.Add("NamaPelanggan", "Nama Pelanggan");
            dataGridViewNotaJual.Columns.Add("AlamatPelanggan", "Alamat Pelanggan");
            dataGridViewNotaJual.Columns.Add("KodePegawai", "Kode Peg");
            dataGridViewNotaJual.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewNotaJual.Columns.Add("KodeBarang", "Kode Brg");
            dataGridViewNotaJual.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNotaJual.Columns.Add("Harga", "Harga");
            dataGridViewNotaJual.Columns.Add("Jumlah", "Jumlah");

            dataGridViewNotaJual.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["KodePelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["AlamatPelanggan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaJual.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNotaJual.Columns["Harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNotaJual.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNotaJual.Columns["Harga"].DefaultCellStyle.Format = "#,###";

            dataGridViewNotaJual.AllowUserToAddRows = false;
            dataGridViewNotaJual.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewNotaJual.Rows.Clear();

            if (listNotaJual.Count > 0)
            {
                foreach (NotaJual n in listNotaJual)
                {
                    foreach (NotaJualDetil njd in n.ListNotaJualDetil)
                    {
                        dataGridViewNotaJual.Rows.Add(n.NoNotaJual, n.Tanggal, n.Pelanggan.KodePelanggan, n.Pelanggan.Nama,
                            n.Pelanggan.Alamat, n.Pegawai.KodePegawai, n.Pegawai.Nama,
                            njd.Barang.KodeBarang, njd.Barang.Nama, njd.Harga, njd.Jumlah);
                    }
                }
            }
            else
            {
                dataGridViewNotaJual.DataSource = null;
            }
        }

        private void textBoxNotaJual_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxNotaJual_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxNotaJual.Text == "No Nota")
            {
                kriteria = "N.NoNota";
            }
            else if (comboBoxNotaJual.Text == "Tanggal")
            {
                kriteria = "N.Tanggal";
            }
            else if (comboBoxNotaJual.Text == "Kode Plg")
            {
                kriteria = "N.KodePelanggan";
            }
            else if (comboBoxNotaJual.Text == "Nama Pelanggan")
            {
                kriteria = "Plg.Nama";
            }
            else if (comboBoxNotaJual.Text == "Alamat Pelanggan")
            {
                kriteria = "Plg.Alamat";
            }
            else if (comboBoxNotaJual.Text == "Kode Peg")
            {
                kriteria = "N.KodePegawai";
            }
            else if (comboBoxNotaJual.Text == "Nama Pegawai")
            {
                kriteria = "Peg.Nama";
            }

            listNotaJual = NotaJual.BacaData(kriteria, textBoxNotaJual.Text);

            TampilDataGrid();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            NotaJual.CetakNota(kriteria, textBoxNotaJual.Text, "daftar_nota_jual.txt", new Font("Courier New", 12));
        }
    }
}
