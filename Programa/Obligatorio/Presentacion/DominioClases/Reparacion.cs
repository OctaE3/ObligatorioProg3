using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Reparacion
    {
        private int _repCod;
        private int _repAnio;
        private int _mecCod;
        private int _vehiculoCod;
        private DateTime _fchEntrada;
        private DateTime _fchSalida;
        private string _repDscEntrada;
        private string _repDscSalida;
        private int _kmsEntrada;

        public int RepCod { get => _repCod; set => _repCod = value; }
        public int RepAnio { get => _repAnio; set => _repAnio = value; }
        public int MecCod { get => _mecCod; set => _mecCod = value; }
        public int VehiculoCod { get => _vehiculoCod; set => _vehiculoCod = value; }
        public DateTime FchEntrada { get => _fchEntrada; set => _fchEntrada = value; }
        public DateTime FchSalida { get => _fchSalida; set => _fchSalida = value; }
        public string RepDscEntrada { get => _repDscEntrada; set => _repDscEntrada = value; }
        public string RepDscSalida { get => _repDscSalida; set => _repDscSalida = value; }
        public int KmsEntrada { get => _kmsEntrada; set => _kmsEntrada = value; }

        public override string ToString()
        {
            return this.RepCod + " - " + this.RepAnio + " - " + this.MecCod + " - " + this.VehiculoCod + " - " + this.FchEntrada + " - " + this.FchSalida + " - " + this.RepDscEntrada + " - " + this.RepDscSalida + " - " + this.KmsEntrada.ToString();
        }

        public Reparacion() { }

        public Reparacion(int pRepCod, int pRepAnio, int pMecCod, int pVehiculoCod, DateTime pFchEntrada, DateTime pFchSalida, string pRepDscEntrada, string pRepDscSalida, int pKmsEntrada)
        {
            this.RepCod = pRepCod;
            this.RepAnio = pRepAnio;
            this.MecCod = pMecCod;
            this.VehiculoCod = pVehiculoCod;
            this.FchEntrada = pFchEntrada;
            this.FchSalida = pFchSalida;
            this.RepDscEntrada = pRepDscEntrada;
            this.RepDscSalida = pRepDscSalida;
            this.KmsEntrada = pKmsEntrada;
        }
    }
}
