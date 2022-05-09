using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armando_ClassJualBeli
{
    public class Pelanggan
    {
        private string alamat;
        private int kodePelanggan;
        private string nama;
        private string telepon;

        #region Constructor
        public Pelanggan(string alamat, int kodePelanggan, string nama, string telepon)
        {
            this.Alamat = alamat;
            this.KodePelanggan = kodePelanggan;
            this.Nama = nama;
            this.Telepon = telepon;
        }
        #endregion

        #region Properties
        public string Alamat { get => alamat; set => alamat = value; }
        public int KodePelanggan { get => kodePelanggan; set => kodePelanggan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Telepon { get => telepon; set => telepon = value; }
        #endregion

        #region Methods
        public static void TambahData(Pelanggan p)
        {
            string sql = "insert into pelanggan(KodeSupplier, Nama, Alamat, Telepon) values ('" + p.KodePelanggan + "','" + p.Nama.Replace("'", "\\'") + "','" + p.Alamat + "','" + p.Telepon +"')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Pelanggan p)
        {
            string sql = "update pelanggan set Nama='" + p.Nama.Replace("'", "\\'") + "', alamat='" + p.Alamat + "', telepon='" + p.Telepon +"' where KodeKategori='" + p.KodePelanggan + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Pelanggan p)
        {
            string sql = "delete from pelanggan where KodePelangga = '" + p.KodePelanggan + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion
    }
}