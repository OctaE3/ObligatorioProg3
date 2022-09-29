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
    public class PControladoraAdministrador : Conexion
    {
        #region Repuesto

        public static List<Repuesto> ListarRepuestos()
        {
            List<Repuesto> resultado = new List<Repuesto>();
            try
            {
                Repuesto repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("RepuestosListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repuesto = new Repuesto();
                        repuesto.RepuestoCod = reader["RepuestoCod"].ToString();
                        repuesto.RepuestoDsc = reader["RepuestoDsc"].ToString();
                        repuesto.RepuestoCosto = int.Parse(reader["RepuestoCosto"].ToString());
                        repuesto.RepuestoTipo = reader["RepuestoTipo"].ToString();
                        repuesto.ProveedorCod = int.Parse(reader["ProveedorCod"].ToString());
                        resultado.Add(repuesto);
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

        public static Repuesto BuscarRepuesto(string pRepuestoCod)
        {
            Repuesto resultado = new Repuesto();
            try
            {
                Repuesto repuesto;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("RepuestoBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuestoCod));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repuesto = new Repuesto();
                        repuesto.RepuestoCod = reader["RepuestoCod"].ToString();
                        repuesto.RepuestoDsc = reader["RepuestoDsc"].ToString();
                        repuesto.RepuestoCosto = int.Parse(reader["RepuestoCosto"].ToString());
                        repuesto.RepuestoTipo = reader["RepuestoTipo"].ToString();
                        repuesto.ProveedorCod = int.Parse(reader["ProveedorCod"].ToString());
                        resultado = repuesto;
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

        public static bool AltaRepuesto(Repuesto pRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("RepuestoAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuesto.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@RepuestoDsc", pRepuesto.RepuestoDsc));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCosto", pRepuesto.RepuestoCosto));
                cmd.Parameters.Add(new SqlParameter("@RepuestoTipo", pRepuesto.RepuestoTipo));
                cmd.Parameters.Add(new SqlParameter("@ProveedorCod", pRepuesto.ProveedorCod));

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

        public static bool BajaRepuesto(string pRepuestoCod)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("RepuestoBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuestoCod));

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

        public static bool ModificarRepuesto(Repuesto pRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("RepuestoModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuesto.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@RepuestoDsc", pRepuesto.RepuestoDsc));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCosto", pRepuesto.RepuestoCosto));
                cmd.Parameters.Add(new SqlParameter("@RepuestoTipo", pRepuesto.RepuestoTipo));
                cmd.Parameters.Add(new SqlParameter("@ProveedoreCod", pRepuesto.ProveedorCod));

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

        #region Mecanico
        public static List<Mecanico> ListarMecanicos()
        {
            List<Mecanico> resultado = new List<Mecanico>();
            try
            {
                Mecanico mecanico;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("MecanicosListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new  Mecanico();
                        mecanico.MecCod = int.Parse(reader["MecCod"].ToString());
                        mecanico.MecNom = reader["MecNom"].ToString();
                        mecanico.MecCi = reader["MecCi"].ToString();
                        mecanico.MecTel = reader["MecTel"].ToString();
                        mecanico.MecFchIng = DateTime.Parse(reader["MecFchIng"].ToString());
                        mecanico.MecValorHora = int.Parse(reader["MecValorHora"].ToString());
                        mecanico.MecActivo = reader["MecActivo"].ToString();
                        resultado.Add(mecanico);
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

        public static List<Mecanico> ListarMecanicosActivos()
        {
            List<Mecanico> resultado = new List<Mecanico>();
            try
            {
                Mecanico mecanico;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("MecanicosListarActivos", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new Mecanico();
                        mecanico.MecCod = int.Parse(reader["MecCod"].ToString());
                        mecanico.MecNom = reader["MecNom"].ToString();
                        mecanico.MecCi = reader["MecCi"].ToString();
                        mecanico.MecTel = reader["MecTel"].ToString();
                        mecanico.MecFchIng = DateTime.Parse(reader["MecFchIng"].ToString());
                        mecanico.MecValorHora = int.Parse(reader["MecValorHora"].ToString());
                        mecanico.MecActivo = reader["MecActivo"].ToString();
                        resultado.Add(mecanico);
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

        public static Mecanico BuscarMecanico(int pMecCod)
        {
            Mecanico resultado = new Mecanico();
            try
            {
                Mecanico mecanico;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("MecanicoBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MecCod", pMecCod));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new Mecanico();
                        mecanico.MecCod = int.Parse(reader["MecCod"].ToString());
                        mecanico.MecNom = reader["MecNom"].ToString();
                        mecanico.MecCi = reader["MecCi"].ToString();
                        mecanico.MecTel = reader["MecTel"].ToString();
                        mecanico.MecFchIng = DateTime.Parse(reader["MecFchIng"].ToString());
                        mecanico.MecValorHora = int.Parse(reader["MecValorHora"].ToString());
                        mecanico.MecActivo = reader["MecActivo"].ToString();
                        resultado = mecanico;
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

        public static bool AltaMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("MecanicoAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MecNom", pMecanico.MecNom));
                cmd.Parameters.Add(new SqlParameter("@MecCi", pMecanico.MecCi));
                cmd.Parameters.Add(new SqlParameter("@MecTel", pMecanico.MecTel));
                cmd.Parameters.Add(new SqlParameter("@MecFchIng", pMecanico.MecFchIng));
                cmd.Parameters.Add(new SqlParameter("@MecValorHora", pMecanico.MecValorHora));
                cmd.Parameters.Add(new SqlParameter("@MecActivo", pMecanico.MecActivo));
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

        public static bool BajaMecanico(int pMecCod)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("MecanicoBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MecCod", pMecCod));

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

        public static bool ModificarMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("MecanicoModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MecCod", pMecanico.MecCod));
                cmd.Parameters.Add(new SqlParameter("@MecNom", pMecanico.MecNom));
                cmd.Parameters.Add(new SqlParameter("@MecCi", pMecanico.MecCi));
                cmd.Parameters.Add(new SqlParameter("@MecTel", pMecanico.MecTel));
                cmd.Parameters.Add(new SqlParameter("@MecFchIng", pMecanico.MecFchIng));
                cmd.Parameters.Add(new SqlParameter("@MecValorHora", pMecanico.MecValorHora));
                cmd.Parameters.Add(new SqlParameter("@MecActivo", pMecanico.MecActivo));

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

        #region Proveedor

        public static List<Proveedor> ListarProveedor()
        {
            List<Proveedor> resultado = new List<Proveedor>();
            try
            {
                Proveedor proveedor;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ProveedoresListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.ProveedorCod = int.Parse(reader["ProveedorCod"].ToString());
                        proveedor.ProveedorNom = reader["ProveedrNom"].ToString();
                        proveedor.ProveedorRut = reader["ProveedorRut"].ToString();
                        resultado.Add(proveedor);
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

        public static Proveedor BuscarProveedor(int pProveedorCod)
        {
            Proveedor resultado = new Proveedor();
            try
            {
                Proveedor proveedor;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ProveedorBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProveedorCod", pProveedorCod));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.ProveedorCod = int.Parse(reader["ProveedorCod"].ToString());
                        proveedor.ProveedorNom = reader["ProveedrNom"].ToString();
                        proveedor.ProveedorRut = reader["ProveedorRut"].ToString();
                        resultado = proveedor;
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

        public static bool AltaProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ProveedorAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProveedorNom", pProveedor.ProveedorNom));
                cmd.Parameters.Add(new SqlParameter("@ProveedorRut", pProveedor.ProveedorRut));
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

        public static bool BajaProveedor(int pProveedorCod)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ProveedorBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProveedorCod", pProveedorCod));

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

        public static bool ModificarProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ProveedorModificar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ProveedorCod", pProveedor.ProveedorCod));
                cmd.Parameters.Add(new SqlParameter("@ProveedrNom", pProveedor.ProveedorNom));
                cmd.Parameters.Add(new SqlParameter("@ProveedorRut", pProveedor.ProveedorRut));

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

        #region Estadisticas
        public static List<EstadisticaListadoReparacion> ListadoReparacionesFinales(DateTime pFchIn, DateTime pFchEnd)
        {
            List<EstadisticaListadoReparacion> resultado = new List<EstadisticaListadoReparacion>();
            try
            {
                EstadisticaListadoReparacion estadisticaListadoReparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListadoReparacionesFinales", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FchIn", pFchIn));
                cmd.Parameters.Add(new SqlParameter("@FchEnd", pFchEnd));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadisticaListadoReparacion = new EstadisticaListadoReparacion();
                        estadisticaListadoReparacion.CliNom = reader["CliNom"].ToString();
                        estadisticaListadoReparacion.Matricula = reader["Matricula"].ToString();
                        estadisticaListadoReparacion.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        estadisticaListadoReparacion.Costo = int.Parse(reader["Costo"].ToString());
                        resultado.Add(estadisticaListadoReparacion);
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

        public static List<EstadisticaListadoIncompleto> ListadoReparacionesPendientes(DateTime pFchIn)
        {
            List<EstadisticaListadoIncompleto> resultado = new List<EstadisticaListadoIncompleto>();
            try
            {
                EstadisticaListadoIncompleto estadisticaListadoIncompleto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListadoReparacionesProceso", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FchIn", pFchIn));
                

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadisticaListadoIncompleto = new EstadisticaListadoIncompleto();
                        estadisticaListadoIncompleto.CliNom = reader["CliNom"].ToString();
                        estadisticaListadoIncompleto.Matricula = reader["Matricula"].ToString();
                        estadisticaListadoIncompleto.FchEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        resultado.Add(estadisticaListadoIncompleto);
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
        public static List<EstadisticaMasVendido> ListadoRepuestoVendido()
        {
            List<EstadisticaMasVendido> resultado = new List<EstadisticaMasVendido>();
            try
            {
                EstadisticaMasVendido estadisticaMasVendido;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ListadoRepuestoMasVendidos", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadisticaMasVendido = new EstadisticaMasVendido();
                        estadisticaMasVendido.RepuestoCod = reader["RepuestoCod"].ToString();
                        estadisticaMasVendido.RepuestoDsc = reader["RepuestoDsc"].ToString();
                        estadisticaMasVendido.CantidadTot = int.Parse(reader["CantidadTot"].ToString());
                        resultado.Add(estadisticaMasVendido);
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



        #endregion

    }
}
