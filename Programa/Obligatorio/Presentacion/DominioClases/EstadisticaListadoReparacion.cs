using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class EstadisticaListadoReparacion
    {
        private string _cliNom;
        private string _matricula;
        private DateTime _fchEntrada;
        private int _costo;


        public string CliNom { get => _cliNom; set => _cliNom = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public DateTime FchEntrada { get => _fchEntrada; set => _fchEntrada = value; }
        public int Costo { get => _costo; set => _costo = value; }

        public override string ToString()
        {
            return this.CliNom + " " + this.Matricula + " " + this.FchEntrada + " " + this.Costo.ToString();
        }

        public EstadisticaListadoReparacion() { }

        public EstadisticaListadoReparacion(string pCliNom, string pMatricula, DateTime pFchEntrada, int pCosto)
        {
            CliNom = pCliNom;
            Matricula = pMatricula;
            FchEntrada = pFchEntrada;
            Costo = pCosto;
        }

    }
}
