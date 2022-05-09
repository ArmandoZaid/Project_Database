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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        List<Pegawai> listPegawai = new List<Pegawai>();

        private void buttonLogin_Click(object sender, EventArgs e)
        {
                try
            {
                if (textBoxUsername.Text != "")
                {
                    Koneksi koneksi = new Koneksi(textBoxServer.Text, "3306", textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);

                    MessageBox.Show("Koneksi berhasil");

                    Koneksi koneksi2 = new Koneksi();

                    koneksi.Connect();
                    koneksi2.Connect();

                    this.Owner.Enabled = true;

                    if(listPegawai.Count > 0)
                    {
                        FormUtama formUtama = (FormUtama)this.Owner;
                        formUtama.labelJabatan.Text = listPegawai[0].Jabatan.NamaJabatan;
                        formUtama.labelKodePegawai.Text = listPegawai[0].KodePegawai.ToString();
                        formUtama.labelNamaPegawai.Text = listPegawai[0].Nama;
                        formUtama.PengaturanHakAksesMenu(listPegawai[0].Jabatan);
                        formUtama.pegawaiLogin = listPegawai[0];
                    }
                    else
                    {
                        MessageBox.Show("Username tidak ditemukan");
                    }
                }
                else
                {
                    MessageBox.Show("Username tidak boleh kosong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal, pesan : " + ex);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = 50 + panelLogin.Height;
        }

        private void linkLabelPengaturan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 50 + panelLogin.Height + panelPengaturan.Height;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text == "" && textBoxDatabase.Text == "")
            {
                MessageBox.Show("Nama Server dan nama database tidak boleh kosong ");
            }
            else
            {
                this.Height = 50 + panelLogin.Height;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
