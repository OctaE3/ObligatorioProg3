using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioClases;

namespace Persistencia
{
    public class PControladoraReparacion : Conexion
    {
        #region Reparacion

        public static List<Reparacion> ListarReparacion()
        {
            List<Reparacion> resultado = new List<Reparacion>();
            try
            {
                Reparacion reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new Reparacion();
                        reparacion.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion.MecCod = int.Parse(reader["MecCod"].ToString());
                        reparacion.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        reparacion.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacion.FchSalida = DateTime.Parse(reader["FchSalida"].ToString());
                        reparacion.RepDscEntrada = reader["RepDscEntrada"].ToString();
                        reparacion.RepDscSalida = reader["ReoDscSalida"].ToString();
                        reparacion.KmsEntrada = int.Parse(reader["KmsEntrada"].ToString());
                        
                        resultado.Add(reparacion);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return resultado;
        }

        public static List<ReparacionI> ListarReparacionPendiente()
        {
            List<ReparacionI> resultado = new List<ReparacionI>();
            try
            {
                ReparacionI reparacionI;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionListarPendiente", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacionI = new ReparacionI();
                        reparacionI.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacionI.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacionI.MecCod = int.Parse(reader["MecCod"].ToString());
                        reparacionI.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        reparacionI.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacionI.RepDscEntrada = reader["RepDscEntrada"].ToString();
                        reparacionI.KmsEntrada = int.Parse(reader["KmsEntrada"].ToString());

                        resultado.Add(reparacionI);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return resultado;
        }

        public static List<Reparacion> ListarReparacionCompleta()
        {
            List<Reparacion> resultado = new List<Reparacion>();
            try
            {
                Reparacion reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionListarCompleta", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new Reparacion();
                        reparacion.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion.MecCod = int.Parse(reader["MecCod"].ToString());
                        reparacion.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        reparacion.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacion.FchSalida = DateTime.Parse(reader["FchSalida"].ToString());
                        reparacion.RepDscEntrada = reader["RepDscEntrada"].ToString();
                        reparacion.RepDscSalida = reader["ReoDscSalida"].ToString();
                        reparacion.KmsEntrada = int.Parse(reader["KmsEntrada"].ToString());

                        resultado.Add(reparacion);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return resultado;
        }

        public static Reparacion BuscarReparacion(int pRepCod, int pRepAnio)
        {
            Reparacion resultado = new Reparacion();
            try
            {
                Reparacion reparacion;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new Reparacion();
                        reparacion.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion.MecCod = int.Parse(reader["MecCod"].ToString());
                        reparacion.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        reparacion.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacion.FchSalida = DateTime.Parse(reader["FchSalida"].ToString());
                        reparacion.RepDscEntrada = reader["RepDscEntrada"].ToString();
                        reparacion.RepDscSalida = reader["ReoDscSalida"].ToString();
                        reparacion.KmsEntrada = int.Parse(reader["KmsEntrada"].ToString());
                        resultado = reparacion;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AltaReparacion(Reparacion pReparacion)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pReparacion.VehiculoCod));
                cmd.Parameters.Add(new SqlParameter("@FchEntrada", pReparacion.FchEntrada));
                cmd.Parameters.Add(new SqlParameter("@FchSalida", pReparacion.FchSalida));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion.MecCod));
                cmd.Parameters.Add(new SqlParameter("@RepDscEntrada", pReparacion.RepDscEntrada));
                cmd.Parameters.Add(new SqlParameter("@ReoDscSalida", pReparacion.RepDscSalida));
                cmd.Parameters.Add(new SqlParameter("@KmsEntrada", pReparacion.KmsEntrada));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool BajaReparacion(int pRepCod, int pRepAnio)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool ModificarReparacion(Reparacion pReparacion)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion.RepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pReparacion.VehiculoCod));
                cmd.Parameters.Add(new SqlParameter("@FchEntrada", pReparacion.FchEntrada));
                cmd.Parameters.Add(new SqlParameter("@FchSalida", pReparacion.FchSalida));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion.MecCod));
                cmd.Parameters.Add(new SqlParameter("@RepDscEntrada", pReparacion.RepDscEntrada));
                cmd.Parameters.Add(new SqlParameter("@ReoDscSalida", pReparacion.RepDscSalida));
                cmd.Parameters.Add(new SqlParameter("@KmsEntrada", pReparacion.KmsEntrada));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        #endregion

        #region Reparacion Repuestos

        public static List<Reparacion_Repuestos> ListarReparacionRepuestos()
        {
            List<Reparacion_Repuestos> resultado = new List<Reparacion_Repuestos>();
            try
            {
                Reparacion_Repuestos reparacion_Repuestos;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionRepuestosListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_Repuestos = new Reparacion_Repuestos();
                        reparacion_Repuestos.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion_Repuestos.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_Repuestos.RepuestoCod = reader["RepuestoCod"].ToString();
                        reparacion_Repuestos.Cantidad = int.Parse(reader["Cantidad"].ToString());
                        reparacion_Repuestos.CostoUnitario = int.Parse(reader["CostoUnitario"].ToString());
                        resultado.Add(reparacion_Repuestos);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return resultado;
        }

        public static Reparacion_Repuestos BuscarReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            Reparacion_Repuestos resultado = new Reparacion_Repuestos();
            try
            {
                Reparacion_Repuestos reparacion_Repuestos;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionRepuestosBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_Repuestos = new Reparacion_Repuestos();
                        reparacion_Repuestos.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion_Repuestos.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_Repuestos.RepuestoCod = reader["RepuestoCod"].ToString();
                        reparacion_Repuestos.Cantidad = int.Parse(reader["Cantidad"].ToString());
                        reparacion_Repuestos.CostoUnitario = int.Parse(reader["CostoUnitario"].ToString());
                        resultado = reparacion_Repuestos;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AltaReparacionRepuestos(Reparacion_Repuestos pReparacion_Repuestos)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionRepuestosAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion_Repuestos.RepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion_Repuestos.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pReparacion_Repuestos.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@Cantidad", pReparacion_Repuestos.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@CostoUnitario", pReparacion_Repuestos.CostoUnitario));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool BajaReparacionRepuestos(int pRepCod, int pRepAnio)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionRepuestosBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool ModificarReparacionRepuestos(Reparacion_Repuestos pReparacion_Repuestos)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionRepuestosModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion_Repuestos.RepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion_Repuestos.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pReparacion_Repuestos.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@Cantidad", pReparacion_Repuestos.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@CostoUnitario", pReparacion_Repuestos.CostoUnitario));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        #endregion

        #region Reparacion Horas

        public static List<Reparacion_Horas> ListarReparacionHoras()
        {
            List<Reparacion_Horas> resultado = new List<Reparacion_Horas>();
            try
            {
                Reparacion_Horas reparacion_Horas;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionHorasListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_Horas = new Reparacion_Horas();
                        reparacion_Horas.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion_Horas.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_Horas.Mecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion_Horas.Horas = int.Parse(reader["Horas"].ToString());
                        reparacion_Horas.CostoHora = int.Parse(reader["CostoHora"].ToString());
                        resultado.Add(reparacion_Horas);
                    }
                }
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return resultado;
        }

        public static Reparacion_Horas BuscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            Reparacion_Horas resultado = new Reparacion_Horas();
            try
            {
                Reparacion_Horas reparacion_Horas;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionHorasBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_Horas = new Reparacion_Horas();
                        reparacion_Horas.RepCod = int.Parse(reader["RepCod"].ToString());
                        reparacion_Horas.RepAnio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_Horas.Mecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion_Horas.Horas = int.Parse(reader["Horas"].ToString());
                        reparacion_Horas.CostoHora = int.Parse(reader["CostoHora"].ToString());
                        resultado = reparacion_Horas;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static bool AltaReparacionHoras(Reparacion_Horas pReparacion_Horas)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionHorasAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion_Horas.RepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion_Horas.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion_Horas.Mecanico));
                cmd.Parameters.Add(new SqlParameter("@Horas", pReparacion_Horas.Horas));
                cmd.Parameters.Add(new SqlParameter("@CostoHora", pReparacion_Horas.CostoHora));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool BajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReparacionHorasBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSql.State == ConnectionState.Open)
                {
                    conexionSql.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool ModificarReparacionHoras(Reparacion_Horas pReparacion_Horas)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReparacionHorasModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion_Horas.RepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion_Horas.RepAnio));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion_Horas.Mecanico));
                cmd.Parameters.Add(new SqlParameter("@Horas", pReparacion_Horas.Horas));
                cmd.Parameters.Add(new SqlParameter("@CostoHora", pReparacion_Horas.CostoHora));

                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        #endregion
    }
}
