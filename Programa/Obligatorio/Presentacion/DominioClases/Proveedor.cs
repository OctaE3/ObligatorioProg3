using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Proveedor
    {
        private int _proveedorCod;
        private string _proveedorNom;
        private string _proveedorRut;

        public int ProveedorCod { get => _proveedorCod; set => _proveedorCod = value; }
        public string ProveedorNom { get => _proveedorNom; set => _proveedorNom = value; }
        public string ProveedorRut { get => _proveedorRut; set => _proveedorRut = value; }

        public override string ToString()
        {
            return this.ProveedorCod + " - " + this.ProveedorNom + " - " + this.ProveedorRut.ToString();
        }

        public Proveedor() { }

        public Proveedor(int pProveedorCod, string pProveedorNom, string pProveedorRut)
        {
            this.ProveedorCod = pProveedorCod;
            this.ProveedorNom = pProveedorNom;
            this.ProveedorRut = pProveedorRut;
        }
    }
}
