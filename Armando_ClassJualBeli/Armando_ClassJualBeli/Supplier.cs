using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Armando_ClassJualBeli
{
    public class Supplier
    {
        private string alamat;
        private int kodeSupplier;
        private string nama;

        #region Constructor
        public Supplier(string alamat, int kodeSupplier, string nama)
        {
            this.Alamat = alamat;
            this.KodeSupplier = kodeSupplier;
            this.Nama = nama;
        }
        #endregion

        #region properties
        public string Alamat { get => alamat; set => alamat = value; }
        public int KodeSupplier { get => kodeSupplier; set => kodeSupplier = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region Method

        public static void TambahData(Supplier s)
        {
            string sql = "insert into supplier(KodeSupplier, Nama, Alamat) values ('" + s.KodeSupplier + "','" + s.Nama.Replace("'", "\\'") + "','" + s.Alamat +"')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Supplier s)
        {
            string sql = "update supplier set Nama='" + s.Nama.Replace("'", "\\'") + "', alamat='" + s.Alamat +"'where KodeKategori='" + s.KodeSupplier + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
        
        public static void HapusData(Supplier s)
        {
            string sql = "delete from supplier where KodeSupplier = '" + s.KodeSupplier + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
        #endregion
    }
}