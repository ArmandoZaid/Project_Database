using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Armando_ClassJualBeli
{
    public class Kategori
    {
        private string kodeKategori;
        private string nama;

        public Kategori(string kodeKategori, string nama)
        {
            this.KodeKategori = kodeKategori;
            this.Nama = nama;
        }

        public string KodeKategori { get => kodeKategori; set => kodeKategori = value; }
        public string Nama { get => nama; set => nama = value; }

        public static void TambahData(Kategori k)
        {
            string sql = "insert into kategori(KodeKategori, Nama) values ('" + k.KodeKategori + "','" + k.Nama.Replace("'", "\\'") + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Kategori k)
        {
            string sql = "update kategori set Nama='" + k.Nama.Replace("'", "\\'") + "' where KodeKategori='" + k.KodeKategori + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Kategori k)
        {
            string sql = "delete from kategori where KodeKategori = '" + k.KodeKategori + "'";

            Koneksi.JalankanPerintahDML(sql);
        }
    }
}