using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioClases;
using Persistencia;

namespace DominioControladora
{
    public class Controladora_Cliente_Vehiculo
    {
        public static bool AltaClienteVehiculo(Cliente_Vehiculo pCliente_Vehiculo)
        {
            return PControladoraClienteVehiculo.AltaClienteVehiculo(pCliente_Vehiculo);
        }

        public static List<Cliente_Vehiculo> listaClienteVehiculo()
        {
            return PControladoraClienteVehiculo.ListarClienteVehiculo();
        }
    }
}
