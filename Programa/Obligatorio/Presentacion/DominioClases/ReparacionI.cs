using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class ReparacionI
    {
        private int _repCod;
        private int _repAnio;
        private int _mecCod;
        private int _vehiculoCod;
        private DateTime _fchEntrada;
        private string _repDscEntrada;
        private int _kmsEntrada;

        public int RepCod { get => _repCod; set => _repCod = value; }
        public int RepAnio { get => _repAnio; set => _repAnio = value; }
        public int MecCod { get => _mecCod; set => _mecCod = value; }
        public int VehiculoCod { get => _vehiculoCod; set => _vehiculoCod = value; }
        public DateTime FchEntrada { get => _fchEntrada; set => _fchEntrada = value; }
        public string RepDscEntrada { get => _repDscEntrada; set => _repDscEntrada = value; }
        public int KmsEntrada { get => _kmsEntrada; set => _kmsEntrada = value; }

        public override string ToString()
        {
            return this.RepCod + " - " + this.RepAnio + " - " + this.MecCod + " - " + this.VehiculoCod + " - " + this.FchEntrada + " - " + this.RepDscEntrada + " - " + this.KmsEntrada.ToString();
        }

        public ReparacionI() { }

        public ReparacionI(int pRepCod, int pRepAnio, int pMecCod, int pVehiculoCod, DateTime pFchEntrada, string pRepDscEntrada, int pKmsEntrada)
        {
            this.RepCod = pRepCod;
            this.RepAnio = pRepAnio;
            this.MecCod = pMecCod;
            this.VehiculoCod = pVehiculoCod;
            this.FchEntrada = pFchEntrada;
            this.RepDscEntrada = pRepDscEntrada;
            this.KmsEntrada = pKmsEntrada;
        }
    }
}
