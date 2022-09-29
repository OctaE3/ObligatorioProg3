using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioClases;
using Persistencia;

namespace DominioControladora
{
    public class Controladora_Administrador
    {
        PControladoraAdministrador PControladoraAdministrador;

        public Controladora_Administrador()
        {
            PControladoraAdministrador = new PControladoraAdministrador();
        }

        #region ABM Repuesto

        public static List<Repuesto> listarRepuesto()
        {
            return PControladoraAdministrador.ListarRepuestos();
        }

        public static Repuesto buscarRepuesto(string pRepuestoCod)
        {
            return PControladoraAdministrador.BuscarRepuesto(pRepuestoCod);
        }

        public static bool altaRepuesto(Repuesto pRepuesto)
        {
            return PControladoraAdministrador.AltaRepuesto(pRepuesto);
        }

        public static bool bajaRepuesto(string pRepuestoCod)
        {
            return PControladoraAdministrador.BajaRepuesto(pRepuestoCod);
        }

        public static bool modificarRepuesto(Repuesto pRepuesto)
        {
            return PControladoraAdministrador.ModificarRepuesto(pRepuesto);
        }

        #endregion

        #region ABM Mecanico
        public static List<Mecanico> listarMecanico()
        {
            return PControladoraAdministrador.ListarMecanicos();
        }

        public static List<Mecanico> listarMecanicoActivo()
        {
            return PControladoraAdministrador.ListarMecanicosActivos();
        }

        public static Mecanico buscarMecanico(int pMecCod)
        {
            return PControladoraAdministrador.BuscarMecanico(pMecCod);
        }

        public static bool altaMecanico(Mecanico pMecanico)
        {
            return PControladoraAdministrador.AltaMecanico(pMecanico);
        }

        public static bool bajaMecanico(int pMecCod)
        {
            return PControladoraAdministrador.BajaMecanico(pMecCod);
        }

        public static bool modificarMecanico(Mecanico pMecanico)
        {
            return PControladoraAdministrador.ModificarMecanico(pMecanico);
        }


        #endregion

        #region ABM Proveedor

        public static List<Proveedor> listarProveedor()
        {
            return PControladoraAdministrador.ListarProveedor();
        }

        public static Proveedor buscarProveedor(int pProveedorCod)
        {
            return PControladoraAdministrador.BuscarProveedor(pProveedorCod);
        }

        public static bool altaProveedor(Proveedor pProveedor)
        {
            return PControladoraAdministrador.AltaProveedor(pProveedor);
        }

        public static bool bajaProveedor(int pProveedorCod)
        {
            return PControladoraAdministrador.BajaProveedor(pProveedorCod);
        }

        public static bool modificarProveedor(Proveedor pProveedor)
        {
            return PControladoraAdministrador.ModificarProveedor(pProveedor);
        }

        #endregion

        #region Estadisticas
        public static List<EstadisticaListadoReparacion> ListadoReparacionesFinales(DateTime pFchIn, DateTime pFchEnd)
        {
            return PControladoraAdministrador.ListadoReparacionesFinales(pFchIn, pFchEnd);
        }
        public static List<EstadisticaListadoIncompleto> ListadoReparacionesPendientes(DateTime pFchIn)
        {
            return PControladoraAdministrador.ListadoReparacionesPendientes(pFchIn);
        }
        public static List<EstadisticaMasVendido> ListadoRepuestoVendido()
        {
            return PControladoraAdministrador.ListadoRepuestoVendido();
        }
        #endregion
    }
}
