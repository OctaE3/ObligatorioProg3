using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class EstadisticaListadoIncompleto
    {
        private string _cliNom;
        private string _matricula;
        private DateTime _fchEntrada;

        public string CliNom { get => _cliNom; set => _cliNom = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public DateTime FchEntrada { get => _fchEntrada; set => _fchEntrada = value; }

        public override string ToString()
        {
            return this.CliNom + " " + this.Matricula + " " + this.FchEntrada.ToString();
        }

        public EstadisticaListadoIncompleto() { }

        public EstadisticaListadoIncompleto(string pCliNom, string pMatricula, DateTime pFchEntrada)
        {
            CliNom = pCliNom;
            Matricula = pMatricula;
            FchEntrada = pFchEntrada;
        }
    }
}
