using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioClases;
using Persistencia;

namespace DominioControladora
{
    public class Controladora_Reparacion
    {
        PControladoraReparacion PControladoraReparacion;

        public Controladora_Reparacion()
        {
            PControladoraReparacion = new PControladoraReparacion();
        }

        #region Reparacion

        public static List<Reparacion> listarReparacion()
        {
            return PControladoraReparacion.ListarReparacion();
        }

        public static List<ReparacionI> listarReparacionPendiente()
        {
            return PControladoraReparacion.ListarReparacionPendiente();
        }

        public static List<Reparacion> listarReparacionCompleta()
        {
            return PControladoraReparacion.ListarReparacionCompleta();
        }

        public static Reparacion buscarReparacion(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BuscarReparacion(pRepCod, pRepAnio);
        }

        public static bool altaReparacion(Reparacion pReparacion)
        {
            return PControladoraReparacion.AltaReparacion(pReparacion);
        }

        public static bool bajaReparacion(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BajaReparacion(pRepCod, pRepAnio);
        }

        public static bool modificarReparacion(Reparacion pReparacion)
        {
            return PControladoraReparacion.ModificarReparacion(pReparacion);
        }

        #endregion

        #region Reparacion Repuesto

        public static List<Reparacion_Repuestos> listarReparacionRepuestos()
        {
            return PControladoraReparacion.ListarReparacionRepuestos();
        }

        public static Reparacion_Repuestos buscarReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BuscarReparacionRepuestos(pRepCod, pRepAnio);
        }

        public static bool altaReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return PControladoraReparacion.AltaReparacionRepuestos(pReparacionRepuestos);
        }

        public static bool bajaReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BajaReparacionRepuestos(pRepCod, pRepAnio);
        }

        public static bool modificarReparacionRepuestos(Reparacion_Repuestos pReparacionRepuestos)
        {
            return PControladoraReparacion.ModificarReparacionRepuestos(pReparacionRepuestos);
        }

        #endregion

        #region Reparacion Horas

        public static List<Reparacion_Horas> listarReparacionHoras()
        {
            return PControladoraReparacion.ListarReparacionHoras();
        }

        public static Reparacion_Horas buscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BuscarReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool altaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladoraReparacion.AltaReparacionHoras(pReparacionHoras);
        }

        public static bool bajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BajaReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool modificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladoraReparacion.ModificarReparacionHoras(pReparacionHoras);
        }

        #endregion
    }
}
