using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DominioClases;

namespace DominioControladora
{
    public class ControladoraDominio
    {
        Controladora_Administrador Controladora_Administrador;
        Controladora_Usuario Controladora_Usuario;
        Controladora_Reparacion Controladora_Reparacion;
        Controladora_Cliente_Vehiculo Controladora_Cliente_Vehiculo;

        public ControladoraDominio()
        {
            Controladora_Administrador = new Controladora_Administrador();
            Controladora_Usuario = new Controladora_Usuario();
            Controladora_Reparacion = new Controladora_Reparacion();
            Controladora_Cliente_Vehiculo = new Controladora_Cliente_Vehiculo();
        }

        #region Repuesto

        public static List<Repuesto> listarRepuesto()
        {
            return Controladora_Administrador.listarRepuesto();
        }

        public static Repuesto buscarRepuesto(string pRepuestoCod)
        {
            return Controladora_Administrador.buscarRepuesto(pRepuestoCod);
        }

        public static bool altaRepuesto(Repuesto pRepuesto)
        {
            return Controladora_Administrador.altaRepuesto(pRepuesto);
        }

        public static bool bajaRepuesto(string pRepuestoCod)
        {
            return Controladora_Administrador.bajaRepuesto(pRepuestoCod);
        }

        public static bool modificarRepuesto(Repuesto pRepuesto)
        {
            return Controladora_Administrador.modificarRepuesto(pRepuesto);
        }

        #endregion

        #region Mecanico

        public static List<Mecanico> listarMecanico()
        {
            return Controladora_Administrador.listarMecanico();
        }

        public static List<Mecanico> listarMecanicoActivo()
        {
            return Controladora_Administrador.listarMecanicoActivo();
        }

        public static Mecanico buscarMecanico(int pMecCod)
        {
            return Controladora_Administrador.buscarMecanico(pMecCod);
        }

        public static bool altaMecanico(Mecanico pMecanico)
        {
            return Controladora_Administrador.altaMecanico(pMecanico);
        }

        public static bool bajaMecanico(int pMecCod)
        {
            return Controladora_Administrador.bajaMecanico(pMecCod);
        }

        public static bool modificarMecanico(Mecanico pMecanico)
        {
            return Controladora_Administrador.modificarMecanico(pMecanico);
        }

        #endregion

        #region Proveedor

        public static List<Proveedor> listarProveedor()
        {
            return Controladora_Administrador.listarProveedor();
        }

        public static Proveedor buscarProveedor(int pProveedorCod)
        {
            return Controladora_Administrador.buscarProveedor(pProveedorCod);
        }

        public static bool altaProveedor(Proveedor pProveedor)
        {
            return Controladora_Administrador.altaProveedor(pProveedor);
        }

        public static bool bajaProveedor(int pProveedorCod)
        {
            return Controladora_Administrador.bajaProveedor(pProveedorCod);
        }

        public static bool modificarProveedor(Proveedor pProveedor)
        {
            return Controladora_Administrador.modificarProveedor(pProveedor);
        }

        #endregion

        #region Cliente
        public static List<Cliente> listarCliente()
        {
            return Controladora_Usuario.listarCliente();
        }

        public static List<Cliente> listarAdmin()
        {
            return Controladora_Usuario.listarAdmin();
        }

        public static List<Cliente> listarNoAdmin()
        {
            return Controladora_Usuario.listarNoAdmin();
        }

        public static Cliente buscarCliente(int pClienteCod)
        {
            return Controladora_Usuario.buscarCliente(pClienteCod);
        }

        public static Cliente buscarUsuarioLogueado(string pCi, string pPass)
        {
            return Controladora_Usuario.buscarUsuarioLogueado(pCi, pPass);
        }

        public static bool altaCliente(Cliente pCliente)
        {
            return Controladora_Usuario.altaCliente(pCliente);
        }

        public static bool bajaCliente(int pClienteCod)
        {
            return Controladora_Usuario.bajaCliente(pClienteCod);
        }

        public static bool modificarCliente(Cliente pCliente)
        {
            return Controladora_Usuario.modificarCliente(pCliente);
        }

        #endregion

        #region Vehiculo

        public static List<Vehiculo> listarVehiculo()
        {
            return Controladora_Usuario.listarVehiculo();
        }

        public static Vehiculo buscarVehiculo(int pVehiculoCod)
        {
            return Controladora_Usuario.buscarVehiculo(pVehiculoCod);
        }

        public static Vehiculo buscarVehiculoMatricula(string pMatricula)
        {
            return Controladora_Usuario.buscarVehiculoMatricula(pMatricula);
        }

        public static bool altaVehiculo(Vehiculo pVehiculo)
        {
            return Controladora_Usuario.altaVehiculo(pVehiculo);
        }

        public static bool bajaVehiculo(int pVehiculoCod)
        {
            return Controladora_Usuario.bajaVehiculo(pVehiculoCod);
        }

        public static bool modificarVehiculo(Vehiculo pVehiculo)
        {
            return Controladora_Usuario.modificarVehiculo(pVehiculo);
        }

        #endregion

        #region Reserva

        public static List<Reserva> listarReservas()
        {
            return Controladora_Usuario.listarReservas();
        }

        public static Reserva buscarReserva(int pReservasCod)
        {
            return Controladora_Usuario.buscarReserva(pReservasCod);
        }

        public static bool altaReserva(Reserva pReserva)
        {
            return Controladora_Usuario.altaReserva(pReserva);
        }

        public static bool bajaReserva(int pReservasCod)
        {
            return Controladora_Usuario.bajaReserva(pReservasCod);
        }

        public static bool modificarReserva(Reserva pReserva)
        {
            return Controladora_Usuario.modificarReserva(pReserva);
        }

        #endregion

        #region Reparacion

        public static List<Reparacion> listarReparacion()
        {
            return Controladora_Reparacion.listarReparacion();
        }

        public static List<ReparacionI> listarReparacionPendiente()
        {
            return Controladora_Reparacion.listarReparacionPendiente();
        }

        public static List<Reparacion> listarReparacionCompleta()
        {
            return Controladora_Reparacion.listarReparacionCompleta();
        }

        public static Reparacion buscarReparacion(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.buscarReparacion(pRepCod, pRepAnio);
        }

        public static bool altaReparacion(Reparacion pReparacion)
        {
            return Controladora_Reparacion.altaReparacion(pReparacion);
        }

        public static bool bajaReparacion(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.bajaReparacion(pRepCod, pRepAnio);
        }

        public static bool modificarReparacion(Reparacion pReparacion)
        {
            return Controladora_Reparacion.modificarReparacion(pReparacion);
        }

        #endregion

        #region Reparacion Repuesto

        public static List<Reparacion_Repuestos> listarReparacionRepuestos()
        {
            return Controladora_Reparacion.listarReparacionRepuestos();
        }

        public static Reparacion_Repuestos buscarReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.buscarReparacionRepuestos(pRepCod, pRepAnio);
        }

        public static bool altaReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return Controladora_Reparacion.altaReparacionRepuestos(pReparacionRepuestos);
        }

        public static bool bajaReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.bajaReparacionRepuestos(pRepCod, pRepAnio);
        }

        public static bool modificarReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return Controladora_Reparacion.modificarReparacionRepuestos(pReparacionRepuestos);
        }

        #endregion

        #region Reparacion Horas

        public static List<Reparacion_Horas> listarReparacionHoras()
        {
            return Controladora_Reparacion.listarReparacionHoras();
        }

        public static Reparacion_Horas buscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.buscarReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool altaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return Controladora_Reparacion.altaReparacionHoras(pReparacionHoras);
        }

        public static bool bajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return Controladora_Reparacion.bajaReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool modificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return Controladora_Reparacion.modificarReparacionHoras(pReparacionHoras);
        }

        #endregion

        #region Estadisticas
        public static List<EstadisticaListadoReparacion> ListadoReparacionesFinales(DateTime pFchIn, DateTime pFchEnd)
        {
            return Controladora_Administrador.ListadoReparacionesFinales(pFchIn, pFchEnd);
        }
        public static List<EstadisticaListadoIncompleto> ListadoReparacionesPendientes(DateTime pFchIn)
        {
            return Controladora_Administrador.ListadoReparacionesPendientes(pFchIn);
        }
        public static List<EstadisticaMasVendido> ListadoRepuestoVendido()
        {
            return Controladora_Administrador.ListadoRepuestoVendido();
        }
        #endregion

        #region Clientes Vehiculos

        public static List<Cliente_Vehiculo> listaClienteVehiculo()
        {
            return Controladora_Cliente_Vehiculo.listaClienteVehiculo();
        }

        public static bool AltaClienteVehiculo(Cliente_Vehiculo pCliente_Vehiculo)
        {
            return Controladora_Cliente_Vehiculo.AltaClienteVehiculo(pCliente_Vehiculo);
        }

        #endregion
    }
}
