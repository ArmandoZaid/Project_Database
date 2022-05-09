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
    public partial class FormUtama : Form
    {
        public Pegawai pegawaiLogin;

        public FormUtama()
        {
            InitializeComponent();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            this.Enabled = false;

            FormLogin formLogin = new FormLogin();
            formLogin.Owner = this;
            formLogin.Show();
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarKategori"];

            if (form == null)
            {
                FormDaftarKategori formKategori = new FormDaftarKategori();
                formKategori.MdiParent = this;
                formKategori.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBarang"];

            if (form == null)
            {
                FormDaftarBarang formDaftarBarang = new FormDaftarBarang();
                formDaftarBarang.MdiParent = this;
                formDaftarBarang.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPegawai"];

            if (form == null)
            {
                FormDaftarPegawai formDaftarPegawai = new FormDaftarPegawai();
                formDaftarPegawai.MdiParent = this;
                formDaftarPegawai.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPelanggan"];

            if (form == null)
            {
                FormDaftarPelanggan formDaftarPelanggan = new FormDaftarPelanggan();
                formDaftarPelanggan.MdiParent = this;
                formDaftarPelanggan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSupplier"];

            if (form == null)
            {
                FormDaftarSupplier formDaftarSupplier = new FormDaftarSupplier();
                formDaftarSupplier.MdiParent = this;
                formDaftarSupplier.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormNotaJual"];

            if (form == null)
            {
                FormNotaJual formNotaJual = new FormNotaJual();
                formNotaJual.MdiParent = this;
                formNotaJual.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormNotaBeli"];

            if (form == null)
            {
                FormNotaBeli formNotaBeli = new FormNotaBeli();
                formNotaBeli.MdiParent = this;
                formNotaBeli.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        public void PengaturanHakAksesMenu (Jabatan J)
        {
            if(J.IdJabatan == "J1")
            {
                pembelianToolStripMenuItem.Visible = true;
                pembelianToolStripMenuItemLaporan.Visible = true;
                masterToolStripMenuItem.Visible = false;
                laporanToolStripMenuItem.Visible = false;
                penjualanToolStripMenuItem.Visible = false;
                penjualanToolStripMenuItemLaporan.Visible = false;
            }
            else if(J.IdJabatan == "J2")
            {
                penjualanToolStripMenuItem.Visible = true;
                penjualanToolStripMenuItemLaporan.Visible = true;
                masterToolStripMenuItem.Visible = false;
                masterToolStripMenuItemLaporan.Visible = false;
                pembelianToolStripMenuItem.Visible = false;
                pembelianToolStripMenuItemLaporan.Visible = false;
            }
            else if(J.IdJabatan == "J3")
            {
                penjualanToolStripMenuItem.Visible = true;
                penjualanToolStripMenuItemLaporan.Visible = true;
                masterToolStripMenuItem.Visible = true;
                masterToolStripMenuItemLaporan.Visible = true;
                pembelianToolStripMenuItem.Visible = true;
                pembelianToolStripMenuItemLaporan.Visible = true;
            }
        }
    }
}
