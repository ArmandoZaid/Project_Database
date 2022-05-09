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
    public partial class FormNotaBeli : Form
    {
        public FormNotaBeli()
        {
            InitializeComponent();
        }

        List<NotaBeli> listNotaBeli = new List<NotaBeli>();

        string kriteria = "";

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNotaBeli formTambahNotaBeli = new FormTambahNotaBeli();
            formTambahNotaBeli.Owner = this;
            formTambahNotaBeli.Show();
        }

        private void FormNotaBeli_Load(object sender, EventArgs e)
        {
            FormatGrid();

            listNotaBeli = NotaBeli.BacaData("", "");

            TampilDataGrid();
        }

        private void comboBoxNotaBeli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void FormatGrid()
        {
            dataGridViewNotaBeli.Columns.Clear();

            dataGridViewNotaBeli.Columns.Add("NoNota", "No Nota");
            dataGridViewNotaBeli.Columns.Add("Tanggal", "Tanggal");
            dataGridViewNotaBeli.Columns.Add("KodeSupplier", "Kode Supplier");
            dataGridViewNotaBeli.Columns.Add("NamaSupplier", "Nama Supplier");
            dataGridViewNotaBeli.Columns.Add("AlamatSupplier", "Alamat Supplier");
            dataGridViewNotaBeli.Columns.Add("KodePegawai", "Kode Peg");
            dataGridViewNotaBeli.Columns.Add("NamaPegawai", "Nama Pegawai");
            dataGridViewNotaBeli.Columns.Add("KodeBarang", "Kode Brg");
            dataGridViewNotaBeli.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewNotaBeli.Columns.Add("Harga", "Harga");
            dataGridViewNotaBeli.Columns.Add("Jumlah", "Jumlah");


            dataGridViewNotaBeli.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["KodeSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["NamaSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["AlamatSupplier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["KodePegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["NamaPegawai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["Harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNotaBeli.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNotaBeli.Columns["Harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewNotaBeli.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewNotaBeli.Columns["Harga"].DefaultCellStyle.Format = "#,###";

            dataGridViewNotaBeli.AllowUserToAddRows = false;
            dataGridViewNotaBeli.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewNotaBeli.Rows.Clear();

            if (listNotaBeli.Count > 0)
            {
                foreach (NotaBeli n in listNotaBeli)
                {
                    foreach (NotaBeliDetil nbd in n.ListNotaBeliDetil)
                    {
                        dataGridViewNotaBeli.Rows.Add(n.NoNotaBeli, n.Tanggal, n.Supplier.KodeSupplier, n.Supplier.Nama,
                            n.Supplier.Alamat, n.Pegawai.KodePegawai, n.Pegawai.Nama,
                            nbd.Barang1.KodeBarang, nbd.Barang1.Nama, nbd.Harga, nbd.Jumlah);
                    }
                }
            }
            else
            {
                dataGridViewNotaBeli.DataSource = null;
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            NotaBeli.CetakNota(kriteria, textBoxNotaBeli.Text, "daftar_nota_jual.txt", new Font("Courier New", 12));
        }
    }
}
