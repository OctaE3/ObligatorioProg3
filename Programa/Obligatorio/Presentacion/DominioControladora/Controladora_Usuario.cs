using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioClases;
using System.Data;
using Persistencia;

namespace DominioControladora
{
    public class Controladora_Usuario
    {
        PControladoraUsuario PControladoraUsuario;

        public Controladora_Usuario()
        {
            PControladoraUsuario = new PControladoraUsuario();
        }

        #region ABM Usuarios
        public static List<Cliente> listarCliente()
        {
            return PControladoraUsuario.ListarCliente();
        }
        public static List<Cliente> listarAdmin()
        {
            return PControladoraUsuario.ListarAdmin();
        }
        public static List<Cliente> listarNoAdmin()
        {
            return PControladoraUsuario.ListarNoAdmin();
        }

        public static Cliente buscarCliente(int pClienteCod)
        {
            return PControladoraUsuario.BuscarCliente(pClienteCod);
        }

        public static Cliente buscarUsuarioLogueado(string pCi, string pPass)
        {
            return PControladoraUsuario.BuscarUsuarioLogueado(pCi, pPass);
        }

        public static bool altaCliente(Cliente pCliente)
        {
            return PControladoraUsuario.AltaCliente(pCliente);
        }

        public static bool bajaCliente(int pClienteCod)
        {
            return PControladoraUsuario.BajaCliente(pClienteCod);
        }

        public static bool modificarCliente(Cliente pCliente)
        {
            return PControladoraUsuario.ModificarCliente(pCliente);
        }

        #endregion

        #region ABM Vehiculos

        public static List<Vehiculo> listarVehiculo()
        {
            return PControladoraUsuario.ListarVehiculo();
        }

        public static Vehiculo buscarVehiculo(int pVehiculoCod)
        {
            return PControladoraUsuario.BuscarVehiculo(pVehiculoCod);
        }

        public static Vehiculo buscarVehiculoMatricula(string pMatricula)
        {
            return PControladoraUsuario.BuscarVehiculoMatricula(pMatricula);
        }

        public static bool altaVehiculo(Vehiculo pVehiculo)
        {
            return PControladoraUsuario.AltaVehiculo(pVehiculo);
        }

        public static bool bajaVehiculo(int pVehiculoCod)
        {
            return PControladoraUsuario.BajaVehiculo(pVehiculoCod);
        }

        public static bool modificarVehiculo(Vehiculo pVehiculo)
        {
            return PControladoraUsuario.ModificarVehiculo(pVehiculo);
        }

        #endregion

        #region ABM Reservas

        public static List<Reserva> listarReservas()
        {
            return PControladoraUsuario.ListarReservas();
        }

        public static Reserva buscarReserva(int pReservasCod)
        {
            return PControladoraUsuario.BuscarReserva(pReservasCod);
        }

        public static bool altaReserva(Reserva pReserva)
        {
            return PControladoraUsuario.AltaReserva(pReserva);
        }

        public static bool bajaReserva(int pReservasCod)
        {
            return PControladoraUsuario.BajaReserva(pReservasCod);
        }

        public static bool modificarReserva(Reserva pReserva)
        {
            return PControladoraUsuario.ModificarReservas(pReserva);
        }

        #endregion
    }
}
