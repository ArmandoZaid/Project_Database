using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armando_ClassJualBeli
{
    public class NotaBeli
    {
        private string noNotaBeli;
        private DateTime tanggal;

        public NotaBeliDetil NotaBeliDetil
        {
            get => default(NotaBeliDetil);
            set
            {
            }
        }

        public Supplier Supplier
        {
            get => default(Supplier);
            set
            {
            }
        }

        public Pegawai Pegawai
        {
            get => default(Pegawai);
            set
            {
            }
        }
    }
}