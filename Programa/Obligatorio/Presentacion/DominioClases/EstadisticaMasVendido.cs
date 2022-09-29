using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class EstadisticaMasVendido
    {
        private string _repuestoCod;
        private string _repuestoDsc;
        private int _CantidadTot;

        public string RepuestoCod { get => _repuestoCod; set => _repuestoCod = value; }
        public string RepuestoDsc { get => _repuestoDsc; set => _repuestoDsc = value; }
        public int CantidadTot { get => _CantidadTot; set => _CantidadTot = value; }

        public override string ToString()
        {
            return this.RepuestoCod + " " + this.RepuestoDsc + " " + this.CantidadTot.ToString();
        }

        public EstadisticaMasVendido() { }
        public EstadisticaMasVendido(string pRepuestoCod, string pRepuestoDsc, int pCantidadTot)
        {
            RepuestoCod = pRepuestoCod;
            RepuestoDsc = pRepuestoDsc;
            CantidadTot = pCantidadTot;
        }



    }
}
