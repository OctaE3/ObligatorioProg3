using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Cliente_Vehiculo
    {
        private int _cliCod;
        private int _vehiculoCod;

        public int CliCod { get => _cliCod; set => _cliCod = value; }
        public int VehiculoCod { get => _vehiculoCod; set => _vehiculoCod = value; }

        public Cliente_Vehiculo() { }

        public Cliente_Vehiculo(int pCliCod, int pVehiculoCod)
        {
            this.CliCod = pCliCod;
            this.VehiculoCod = pVehiculoCod;
        }
    }
}
