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
    public partial class FormTambahNotaJual : Form
    {
        FormUtama formUtama;
        List<Pelanggan> listPelanggan = new List<Pelanggan>();
        List<Barang> listBarangTerjual = new List<Barang>();
        NotaJual notaJual;

        public FormTambahNotaJual()
        {
            InitializeComponent();
        }

        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.Owner.MdiParent;

            textBoxNoNota.Text = NotaJual.GenerateNota();
            textBoxBarcode.MaxLength = 13;
            textBoxNoNota.Enabled = false;

            dateTimePickerTanggal.Value = DateTime.Now;

            labelPegawai.Text = formUtama.labelKodePegawai.Text;
            labelKodeNama.Text = formUtama.labelNamaPegawai.Text;

            listPelanggan = Pelanggan.BacaDataPelanggan("", "");

            comboBoxPelanggan.DataSource = listPelanggan;
            comboBoxPelanggan.DisplayMember = "Nama";
            comboBoxPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatGrid();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Pelanggan pelangganDipilih = (Pelanggan)comboBoxPelanggan.SelectedItem;

                notaJual = new NotaJual(textBoxNoNota.Text, dateTimePickerTanggal.Value, pelangganDipilih, formUtama.pegawaiLogin);

                List<Barang> barangTerjual = new List<Barang>();

                for (int i = 0; i < dataGridViewTambahNotaJual.Rows.Count; i++)
                {
                    barangTerjual = Barang.BacaData("KodeBarang", dataGridViewTambahNotaJual.Rows[i].Cells["KodeBarang"].Value.ToString());
                    notaJual.TambahNotaJualDetil(barangTerjual[0], int.Parse(dataGridViewTambahNotaJual.Rows[i].Cells["HargaJual"].ToString()), int.Parse(dataGridViewTambahNotaJual.Rows[i].Cells["Jumlah"].ToString()));

                }

                NotaJual.TambahData(notaJual);

                MessageBox.Show("Data nota jual telah disimpan.", "Informasi");

                buttonCetak_Click(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan. Pesan keselahan: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            dataGridViewTambahNotaJual.Columns.Clear();

            dataGridViewTambahNotaJual.Columns.Add("KodeBarang", "Kode");
            dataGridViewTambahNotaJual.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewTambahNotaJual.Columns.Add("HargaJual", "Harga Jual");
            dataGridViewTambahNotaJual.Columns.Add("Jumlah", "Jumlah");
            dataGridViewTambahNotaJual.Columns.Add("SubTotal", "Sub Total");

            dataGridViewTambahNotaJual.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTambahNotaJual.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTambahNotaJual.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTambahNotaJual.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTambahNotaJual.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewTambahNotaJual.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTambahNotaJual.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewTambahNotaJual.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewTambahNotaJual.Columns["HargaJual"].DefaultCellStyle.Format = "#.###";
            dataGridViewTambahNotaJual.Columns["SubTotal"].DefaultCellStyle.Format = "#.###";

            dataGridViewTambahNotaJual.AllowUserToAddRows = false;
            dataGridViewTambahNotaJual.ReadOnly = true;
        }

        private void comboBoxPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPelanggan.SelectedIndex != -1)
            {
                Pelanggan pelangganDipilih = (Pelanggan)comboBoxPelanggan.SelectedItem;
                labelAlamat.Text = pelangganDipilih.Alamat;
            }
            else
            {
                labelAlamat.Text = "";
            }
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length == textBoxBarcode.MaxLength)
            {
                listBarangTerjual = Barang.BacaData("Barcode", textBoxBarcode.Text);

                if (listBarangTerjual.Count > 0)
                {
                    labelKodeDua.Text = listBarangTerjual[0].KodeBarang;
                    labelNamaBarang.Text = listBarangTerjual[0].Nama;
                    labelHarga.Text = listBarangTerjual[0].HargaJual.ToString();
                    textBoxJumlah.Text = "1";
                    textBoxJumlah.Focus();
                }
                else
                {
                    MessageBox.Show("Barang tidak ditemukan");
                    textBoxBarcode.Text = "";
                }
            }

                
        }

        private int HitungGrandTotal()
        {
            int grandTotal = 0;
            for(int i=0; i< dataGridViewTambahNotaJual.Rows.Count; i++)
            {
                int subtotal = int.Parse(dataGridViewTambahNotaJual.Rows[i].Cells["SubTotal"].Value.ToString());
                grandTotal += subtotal;
            }
            return grandTotal;
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);

                dataGridViewTambahNotaJual.Rows.Add(labelKodeDua.Text, labelNamaBarangDua.Text, labelHargaDua.Text, textBoxJumlah.Text,subTotal);

                labelGrand.Text = HitungGrandTotal().ToString("#,###");

                textBoxBarcode.Text = "";
                labelKodeDua.Text = "";
                labelNamaBarangDua.Text = "";
                labelHargaDua.Text = "";
                textBoxJumlah.Text = "";
                textBoxBarcode.Focus();
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            try
            {
                NotaJual.CetakNota("NoNota", textBoxNoNota.Text, "nota_jual.txt", new Font("Courier New", 12));

                MessageBox.Show("Nota Jual telah tercetak");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nota jual gagal dicetak. Pesan kesalahan : " + ex.Message);
            }
        }
    }
}
