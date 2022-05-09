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
    public partial class FormDaftarBarang : Form
    {
        List<Barang> listBarang = new List<Barang>();
        public FormDaftarBarang()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBarang formTambahBarang = new FormTambahBarang();
            formTambahBarang.Owner = this;
            formTambahBarang.Show();
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Add("KodeBarang", "KodeBarang");
            dataGridViewBarang.Columns.Add("Barcode", "Barcode");
            dataGridViewBarang.Columns.Add("NamaBarang", "NamaBarang");
            dataGridViewBarang.Columns.Add("HargaJual", "HargaJual");
            dataGridViewBarang.Columns.Add("Stok", "Stok");
            dataGridViewBarang.Columns.Add("KodeKategori", "KodeKategori");
            dataGridViewBarang.Columns.Add("NamaKategori", "NamaKategori");

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Stok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "#,###";

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodeKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaKategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void TampilDataGrid()
        {
            if (listBarang.Count > 0)
            {
                //dataGridViewBarang.DataSource = listBarang;
                dataGridViewBarang.Rows.Clear();

                foreach (Barang b in listBarang)
                {
                    //menambahkan data
                    dataGridViewBarang.Rows.Add(b.KodeBarang, b.Barcode, b.Nama, b.HargaJual, b.Stok, b.Kategori.KodeKategori, b.Kategori.Nama);
                }
            }
            else
            {
                dataGridViewBarang.DataSource = null;
            }
        }

        public void FormDaftarBarang_Load(object sender, EventArgs e)
        {
            //lakukan format datagrid yang ada
            FormatDataGrid();

            //menampilkan semua data ditabel
            //gunakan method bacaData()
            listBarang = Barang.BacaData("", "");

            //tampil data pada DataGridView
            TampilDataGrid();

            //menambahkan item ke combobox untuk pencarian
            comboBoxBarang.Items.Add("Kode Barang");
            comboBoxBarang.Items.Add("Nama Barang");
            comboBoxBarang.Items.Add("Barcode");
            comboBoxBarang.Items.Add("Harga Jual");
            comboBoxBarang.Items.Add("Stok");
            comboBoxBarang.Items.Add("Kode Kategori");
            comboBoxBarang.Items.Add("Nama Kategori");

            comboBoxBarang.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxBarang.Text == "Kode Barang")
            {
                kriteria = "B.KodeBarang";
            }
            else if (comboBoxBarang.Text == "Nama Barang")
            {
                kriteria = "B.Nama";
            }
            else if (comboBoxBarang.Text == "Barcode")
            {
                kriteria = "B.Barcode";
            }
            else if (comboBoxBarang.Text == "Harga Jual")
            {
                kriteria = "B.HargaJual";
            }
            else if (comboBoxBarang.Text == "Stok")
            {
                kriteria = "B.Stok";
            }
            else if (comboBoxBarang.Text == "Kode Kategori")
            {
                kriteria = "B.KodeKategori";
            }
            else if (comboBoxBarang.Text == "nama Kategori")
            {
                kriteria = "K.Nama";
            }

            listBarang = Barang.BacaData(kriteria, textBoxBarang.Text);
            TampilDataGrid();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahBarang formUbahBarang = new FormUbahBarang();
            formUbahBarang.Owner = this;
            formUbahBarang.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusBarang formHapusBarang = new FormHapusBarang();
            formHapusBarang.Owner = this;
            formHapusBarang.Show();
        }
    }
}
