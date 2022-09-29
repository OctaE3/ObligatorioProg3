using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominioClases;
using System.Data;
using DominioControladora;

namespace Presentacion.ControladoraPresentacion
{
    public class ControladoraWeb
    {
        DominioControladora.ControladoraDominio ControladoraDominio;

        public ControladoraWeb()
        {
            ControladoraDominio = new DominioControladora.ControladoraDominio();
        }

        #region Cliente

        public List<Cliente> listaNoAdmin()
        {
            return ControladoraDominio.listarNoAdmin();
        }

        public List<Cliente> listaAdmin()
        {
            return ControladoraDominio.listarAdmin();
        }

        public List<Cliente> listaCliente()
        {
            return ControladoraDominio.listarCliente();
        }

        public Cliente buscarCliente(int pClienteCod)
        {
            return ControladoraDominio.buscarCliente(pClienteCod);
        }

        public Cliente buscarUsuarioLogueado(string pCi, string pPass)
        {
            return ControladoraDominio.buscarUsuarioLogueado(pCi, pPass);
        }

        public bool altaCliente(Cliente pCliente)
        {
            return ControladoraDominio.altaCliente(pCliente);
        }

        public bool bajaCliente(int pClienteCod)
        {
            return ControladoraDominio.bajaCliente(pClienteCod);
        }

        public bool modificarCliente(Cliente pCliente)
        {
            return ControladoraDominio.modificarCliente(pCliente);
        }

        #endregion

        #region Vehiculos

        public List<Vehiculo> listaVehiculo()
        {
            return ControladoraDominio.listarVehiculo();
        }

        public Vehiculo buscarVehiculo(int pVehiculoCod)
        {
            return ControladoraDominio.buscarVehiculo(pVehiculoCod);
        }

        public Vehiculo buscarVehiculoMatricula(string pMatricula)
        {
            return ControladoraDominio.buscarVehiculoMatricula(pMatricula);
        }

        public bool altaVehiculo(Vehiculo pVehiculo)
        {
            return ControladoraDominio.altaVehiculo(pVehiculo);
        }

        public bool bajaVehiculo(int pVehiculoCod)
        {
            return ControladoraDominio.bajaVehiculo(pVehiculoCod);
        }

        public bool modificarVehiculo(Vehiculo pVehiculo)
        {
            return ControladoraDominio.modificarVehiculo(pVehiculo);
        }

        #endregion

        #region Repuestos

        public List<Repuesto> listaRepuesto()
        {
            return ControladoraDominio.listarRepuesto();
        }

        public Repuesto buscarRepuesto(string pRepuestoCod)
        {
            return ControladoraDominio.buscarRepuesto(pRepuestoCod);
        }

        public bool altaRepuesto(Repuesto pRepuesto)
        {
            return ControladoraDominio.altaRepuesto(pRepuesto);
        }

        public bool bajaRepuesto(string pRepuestoCod)
        {
            return ControladoraDominio.bajaRepuesto(pRepuestoCod);
        }

        public bool modificarRepuesto(Repuesto pRepuesto)
        {
            return ControladoraDominio.modificarRepuesto(pRepuesto);
        }

        #endregion

        #region Reparacion

        public List<Reparacion> listarReparacion()
        {
            return ControladoraDominio.listarReparacion();
        }

        public List<ReparacionI> listarReparacionPendiente()
        {
            return ControladoraDominio.listarReparacionPendiente();
        }

        public List<Reparacion> listarReparacionCompleta()
        {
            return ControladoraDominio.listarReparacionCompleta();
        }

        public Reparacion buscarReparacion(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.buscarReparacion(pRepCod, pRepAnio);
        }

        public bool altaReparacion(Reparacion pReparacion)
        {
            return ControladoraDominio.altaReparacion(pReparacion);
        }

        public bool bajaReparacion(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.bajaReparacion(pRepCod, pRepAnio);
        }

        public bool modificarReparacion(Reparacion pReparacion)
        {
            return ControladoraDominio.modificarReparacion(pReparacion);
        }

        #endregion

        #region Mecanico

        public List<Mecanico> listaMecanico()
        {
            return ControladoraDominio.listarMecanico();
        }

        public  List<Mecanico> listarMecanicoActivo()
        {
            return ControladoraDominio.listarMecanicoActivo();
        }
        public Mecanico buscarMecanico(int pMecCod)
        {
            return ControladoraDominio.buscarMecanico(pMecCod);
        }

        public bool altaMecanico(Mecanico pMecanico)
        {
            return ControladoraDominio.altaMecanico(pMecanico);
        }

        public bool bajaMecanico(int pMecCod)
        {
            return ControladoraDominio.bajaMecanico(pMecCod);
        }

        public bool modificarMecanico(Mecanico pMecanico)
        {
            return ControladoraDominio.modificarMecanico(pMecanico);
        }

        #endregion

        #region Reserva

        public List<Reserva> listarReservas()
        {
            return ControladoraDominio.listarReservas();
        }

        public Reserva buscarReserva(int pReservasCod)
        {
            return ControladoraDominio.buscarReserva(pReservasCod);
        }

        public bool altaReserva(Reserva pReserva)
        {
            return ControladoraDominio.altaReserva(pReserva);
        }

        public bool bajaReserva(int pReservasCod)
        {
            return ControladoraDominio.bajaReserva(pReservasCod);
        }

        public bool modificarReserva(Reserva pReserva)
        {
            return ControladoraDominio.modificarReserva(pReserva);
        }

        #endregion

        #region Proveedor

        public List<Proveedor> listarProveedor()
        {
            return ControladoraDominio.listarProveedor();
        }

        public Proveedor buscarProveedor(int pProveedorCod)
        {
            return ControladoraDominio.buscarProveedor(pProveedorCod);
        }

        public bool altaProveedor(Proveedor pProveedor)
        {
            return ControladoraDominio.altaProveedor(pProveedor);
        }

        public bool bajaProveedor(int pProveedorCod)
        {
            return ControladoraDominio.bajaProveedor(pProveedorCod);
        }

        public bool modificarProveedor(Proveedor pProveedor)
        {
            return ControladoraDominio.modificarProveedor(pProveedor);
        }

        #endregion

        #region Reparacion Repuesto

        public List<Reparacion_Repuestos> listarReparacionRepuestos()
        {
            return ControladoraDominio.listarReparacionRepuestos();
        }

        public Reparacion_Repuestos buscarReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.buscarReparacionRepuestos(pRepCod, pRepAnio);
        }

        public bool altaReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return ControladoraDominio.altaReparacionRepuestos(pReparacionRepuestos);
        }

        public bool bajaReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.bajaReparacionRepuestos(pRepCod, pRepAnio);
        }

        public bool modificarReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return ControladoraDominio.modificarReparacionRepuestos(pReparacionRepuestos);
        }

        #endregion

        #region Reparacion Horas

        public List<Reparacion_Horas> listarReparacionHoras()
        {
            return ControladoraDominio.listarReparacionHoras();
        }

        public Reparacion_Horas buscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.buscarReparacionHoras(pRepCod, pRepAnio);
        }

        public bool altaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return ControladoraDominio.altaReparacionHoras(pReparacionHoras);
        }

        public bool bajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return ControladoraDominio.bajaReparacionHoras(pRepCod, pRepAnio);
        }

        public bool modificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return ControladoraDominio.modificarReparacionHoras(pReparacionHoras);
        }

        #endregion

        #region Estadisticas
        public List<EstadisticaListadoReparacion> ListadoReparacionesFinales(DateTime pFchIn, DateTime pFchEnd)
        {
            return ControladoraDominio.ListadoReparacionesFinales(pFchIn, pFchEnd);
        }

        public List<EstadisticaListadoIncompleto> ListadoReparacionesPendientes(DateTime pFchIn)
        {
            return ControladoraDominio.ListadoReparacionesPendientes(pFchIn);
        }

        public List<EstadisticaMasVendido> ListadoRepuestoVendido()
        {
            return ControladoraDominio.ListadoRepuestoVendido();
        }
        #endregion

        #region Clientes Vehiculos

        public  List<Cliente_Vehiculo> listaClienteVehiculo()
        {
            return ControladoraDominio.listaClienteVehiculo();
        }

        public bool AltaClienteVehiculo(Cliente_Vehiculo pCliente_Vehiculo)
        {
            return ControladoraDominio.AltaClienteVehiculo(pCliente_Vehiculo);
        }

        #endregion

    }
}