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
    public partial class FormTambahNotaBeli : Form
    {
        public FormTambahNotaBeli()
        {
            InitializeComponent();
        }

        FormUtama formUtama;
        List<Supplier> listSupplier = new List<Supplier>();
        List<Barang> listBarangTerjual = new List<Barang>();
        NotaBeli notaBeli;

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            Supplier supplierDipilih = (Supplier)comboBoxSupplier.SelectedItem;
            notaBeli = new NotaBeli(textBoxNoNota.Text, dateTimePickerTanggal.Value, supplierDipilih, formUtama.pegawaiLogin);

            List<Barang> BarangTerjual = new List<Barang>();
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                string barang = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                int barangHarga = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaJual"].Value.ToString());
                int barangJumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());

                BarangTerjual = Barang.BacaData("KodeBarang", barang);
                notaBeli.TambahNotaBeliDetil(listBarangTerjual[0],barangHarga,barangJumlah);
            }

            NotaBeli.TambahData(notaBeli);
            MessageBox.Show("Data nota beli telah tersimpan.", "Informasi");
        }

        private void FormatGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("KodeBarang", "Kode");
            dataGridViewBarang.Columns.Add("Nama", "Nama Barang");
            dataGridViewBarang.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "SubTotal");

            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewBarang.Columns["HargaJual"].DefaultCellStyle.Format = "#,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "#,###";

            dataGridViewBarang.AllowUserToAddRows = false;
            dataGridViewBarang.ReadOnly = true;
        }

        private void FormTambahNotaBeli_Load(object sender, EventArgs e)
        {
            listSupplier = Supplier.BacaDataSupplier("", "");
            comboBoxSupplier.DataSource = listSupplier;
            comboBoxSupplier.DisplayMember = "Nama";
            comboBoxSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxNoNota.Enabled = false;

            formUtama = (FormUtama)this.Owner.MdiParent;
            labelKodePegawai.Text = formUtama.pegawaiLogin.KodePegawai.ToString();
            labelNamaPegawai.Text = formUtama.pegawaiLogin.Nama;

            textBoxNoNota.Text = NotaJual.GenerateNota();

            dateTimePickerTanggal.Value = DateTime.Now;

            FormatGrid();

            textBoxBarcode.MaxLength = 13;
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSupplier.SelectedIndex != -1)
            {
                Supplier supplierPilih = (Supplier)comboBoxSupplier.SelectedItem;
                labelAlamat.Text = supplierPilih.Alamat;
            }
            else
            {
                labelAlamat.Text = "";
            }
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);
                dataGridViewBarang.Rows.Add(labelKode.Text, labelNama.Text, labelHarga.Text, textBoxJumlah.Text, subTotal);
                labeGrandTotal.Text = HitungGrand().ToString("#,###");
                labelNama.Text = "";
                labelHarga.Text = "";
                textBoxJumlah.Text = "";
                textBoxBarcode.Text = "";
                labelKode.Text = "";
                
                textBoxBarcode.Focus();

            }
        }

        private int HitungGrand()
        {
            int grandTotal = 0;
            for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
            {
                int subTotal = int.Parse(dataGridViewBarang.Rows[i].Cells["subTotal"].Value.ToString());
                grandTotal += subTotal;
            }
            return grandTotal;
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if(textBoxBarcode.Text.Length == textBoxBarcode.MaxLength)
            {
                listBarangTerjual = Barang.BacaData("barcode", textBoxBarcode.Text);

                if (listBarangTerjual.Count > 0)
                {
                    textBoxJumlah.Text = "1";
                    textBoxJumlah.Focus();
                    labelKode.Text = listBarangTerjual[0].KodeBarang;
                    labelNama.Text = listBarangTerjual[0].Nama;
                    labelHarga.Text = listBarangTerjual[0].HargaJual.ToString();
                }
                else
                {
                    MessageBox.Show("Barang dengan barcode tersebut tidak ditemukan");
                }
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            try
            {
                NotaBeli.CetakNota("nonota", textBoxNoNota.Text, "nota_beli.txt", new Font("Courier New", 12));

                MessageBox.Show("Nota Beli berhasil dicetak");
            }
            catch (Exception error)
            {
                MessageBox.Show($"Gagal Mencetak data, Error : {error.Message}");
            }
        }
    }
}
