using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Repuesto
    {
        private string _repuestoCod;
        private string _repuestoDsc;
        private int _repuestoCosto;
        private string _repuestoTipo;
        private int _proveedorCod;

        public string RepuestoCod { get => _repuestoCod; set => _repuestoCod = value; }
        public string RepuestoDsc { get => _repuestoDsc; set => _repuestoDsc = value; }
        public int RepuestoCosto { get => _repuestoCosto; set => _repuestoCosto = value; }
        public string RepuestoTipo { get => _repuestoTipo; set => _repuestoTipo = value; }
        public int ProveedorCod { get => _proveedorCod; set => _proveedorCod = value; }

        public override string ToString()
        {
            return this.RepuestoCod + " " + this.RepuestoDsc + " " + this.RepuestoCosto + " " + this.RepuestoTipo + " " + this.ProveedorCod.ToString();
        }

        public Repuesto() { }

        public Repuesto(string pRepuestoCod, string pRepuestoDsc, int pRepuestoCosto, string pRepuestoTipo, int pProveedorCod)
        {
            this.RepuestoCod = pRepuestoCod;
            this.RepuestoDsc = pRepuestoDsc;
            this.RepuestoCosto = pRepuestoCosto;
            this.RepuestoTipo = pRepuestoTipo;
            this.ProveedorCod = pProveedorCod;
        }
    }
}
