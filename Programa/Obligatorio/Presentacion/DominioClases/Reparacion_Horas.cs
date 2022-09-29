using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Reparacion_Horas
    {
        private int _repCod;
        private int _repAnio;
        private int _mecanico;
        private int _horas;
        private int _costoHora;

        public int RepCod { get => _repCod; set => _repCod = value; }
        public int RepAnio { get => _repAnio; set => _repAnio = value; }
        public int Mecanico { get => _mecanico; set => _mecanico = value; }
        public int Horas { get => _horas; set => _horas = value; }
        public int CostoHora { get => _costoHora; set => _costoHora = value; }

        public override string ToString()
        {
            return this.RepCod + " - " + this.RepAnio + " - " + this.Mecanico + " - " + this.Horas + " - " + this.CostoHora.ToString();
        }

        public Reparacion_Horas() { }

        public Reparacion_Horas(int pRepCod, int pRepAnio, int pMecanico, int pHoras, int pCostoHora)
        {
            this.RepCod = pRepCod;
            this.RepAnio = pRepAnio;
            this.Mecanico = pMecanico;
            this.Horas = pHoras;
            this.CostoHora = pCostoHora;
        }
    }
}
