using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armando_ClassJualBeli
{
    public class NotaJual
    {
        private string noNotaJual;
        private DateTime tanggal;

        public NotaJualDetil NotaJualDetil
        {
            get => default(NotaJualDetil);
            set
            {
            }
        }

        public Pelanggan Pelanggan
        {
            get => default(Pelanggan);
            set
            {
            }
        }
    }
}