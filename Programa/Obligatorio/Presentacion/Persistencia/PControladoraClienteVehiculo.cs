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
    public class PControladoraClienteVehiculo : Conexion
    {
        public static List<Cliente_Vehiculo> ListarClienteVehiculo()
        {
            List<Cliente_Vehiculo> resultado = new List<Cliente_Vehiculo>();
            try
            {
                Cliente_Vehiculo cliente_Vehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ClientesVehiculosListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente_Vehiculo = new Cliente_Vehiculo();
                        cliente_Vehiculo.CliCod = int.Parse(reader["CliCod"].ToString());
                        cliente_Vehiculo.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        resultado.Add(cliente_Vehiculo);
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

        public static bool AltaClienteVehiculo(Cliente_Vehiculo pCliente_Vehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ClientesVehiculosAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliente_Vehiculo.CliCod));
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pCliente_Vehiculo.VehiculoCod));

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
    }
}
