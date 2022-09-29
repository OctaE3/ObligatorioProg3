using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Reparacion_Repuestos
    {
        private int _repCod;
        private int _repAnio;
        private string _repuestoCod;
        private int _cantidad;
        private int _costoUnitario;

        public int RepCod { get => _repCod; set => _repCod = value; }
        public int RepAnio { get => _repAnio; set => _repAnio = value; }
        public string RepuestoCod { get => _repuestoCod; set => _repuestoCod = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public int CostoUnitario { get => _costoUnitario; set => _costoUnitario = value; }

        public override string ToString()
        {
            return this.RepCod + " - " + this.RepAnio + " - " + this.RepuestoCod + " - " + this.Cantidad + " - " + this.CostoUnitario.ToString();
        }

        public Reparacion_Repuestos() { }

        public Reparacion_Repuestos(int pRepCod, int pRepAnio, string pRepuestoCod, int pCantidad, int pCostoUnitario)
        {
            this.RepCod = pRepCod;
            this.RepAnio = pRepAnio;
            this.RepuestoCod = pRepuestoCod;
            this.Cantidad = pCantidad;
            this.CostoUnitario = pCostoUnitario;
        }
    }
}
