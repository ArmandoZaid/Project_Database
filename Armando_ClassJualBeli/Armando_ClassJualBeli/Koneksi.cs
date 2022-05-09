using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Armando_ClassJualBeli
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region contrsuctor
        public Koneksi()
        {
            koneksiDB = new MySqlConnection();

            koneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            Connect();
        }

        public Koneksi(string pServer, string pPort, string pDatabase, string pUsername, string pPassword)
        {
            string strCon = "";
            if (pPassword != "")
            {
                strCon = "Server=" + pServer + ";Port=" + pPort + ";Database=" + pDatabase + ";Uid=" + pUsername +
                        ";Pwd=" + pPassword + ";";
            }
            else
            {
                strCon = "Server=" + pServer + ";Port=" + pPort + ";Database=" + pDatabase + ";Uid=" + pUsername + ";";
            }
            this.KoneksiDB = new MySqlConnection();
            this.KoneksiDB.ConnectionString = strCon;
            this.Connect();
            UpdateAppConfig(strCon);
        }

        #endregion

        #region properties
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region methods

        public void UpdateAppConfig(string con)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["namakoneksi"].ConnectionString = con;

            config.Save(ConfigurationSaveMode.Modified, true);

            ConfigurationManager.RefreshSection("connectionStrings");
        }


        public void Connect()
        {
            //jika koneksi sedang terbuka maka tutup terlebih dahulu
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }

            koneksiDB.Open();
        }

        public static void JalankanPerintahDML(string sql)
        {
            Koneksi k = new Koneksi();

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            c.ExecuteNonQuery();
        }
        #endregion
    }
}
