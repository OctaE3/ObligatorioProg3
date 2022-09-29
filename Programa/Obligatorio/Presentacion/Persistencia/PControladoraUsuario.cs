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
    public class PControladoraUsuario : Conexion
    {
        #region ABM Clientes

        public static List<Cliente> ListarCliente()
        {
            List<Cliente> resultado = new List<Cliente>();
            try
            {
                Cliente cliente;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ClientesListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.CliId = int.Parse(reader["CliCod"].ToString());
                        cliente.CliNom = reader["CliNom"].ToString();
                        cliente.CliCi = reader["CliCi"].ToString();
                        cliente.CliTel = reader["CliTel"].ToString();
                        cliente.CliDir = reader["CliDir"].ToString();
                        cliente.CliMail = reader["CliMail"].ToString();
                        cliente.FchRegistro = DateTime.Parse(reader["FchRegistro"].ToString());
                        cliente.CliPass = reader["CliContra"].ToString();
                        cliente.Admin = reader["Admin"].ToString();

                        resultado.Add(cliente);
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

        public static List<Cliente> ListarAdmin()
        {
            List<Cliente> resultado = new List<Cliente>();
            try
            {
                Cliente cliente;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("AdminListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.CliId = int.Parse(reader["CliCod"].ToString());
                        cliente.CliNom = reader["CliNom"].ToString();
                        cliente.CliCi = reader["CliCi"].ToString();
                        cliente.CliTel = reader["CliTel"].ToString();
                        cliente.CliDir = reader["CliDir"].ToString();
                        cliente.CliMail = reader["CliMail"].ToString();
                        cliente.FchRegistro = DateTime.Parse(reader["FchRegistro"].ToString());
                        cliente.CliPass = reader["CliContra"].ToString();
                        cliente.Admin = reader["Admin"].ToString();

                        resultado.Add(cliente);
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

        public static List<Cliente> ListarNoAdmin()
        {
            List<Cliente> resultado = new List<Cliente>();
            try
            {
                Cliente cliente;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("NoAdminListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.CliId = int.Parse(reader["CliCod"].ToString());
                        cliente.CliNom = reader["CliNom"].ToString();
                        cliente.CliCi = reader["CliCi"].ToString();
                        cliente.CliTel = reader["CliTel"].ToString();
                        cliente.CliDir = reader["CliDir"].ToString();
                        cliente.CliMail = reader["CliMail"].ToString();
                        cliente.FchRegistro = DateTime.Parse(reader["FchRegistro"].ToString());
                        cliente.CliPass = reader["CliContra"].ToString();
                        cliente.Admin = reader["Admin"].ToString();

                        resultado.Add(cliente);
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

        public static Cliente BuscarCliente(int pCliId)
        {
            Cliente resultado = new Cliente();
            try
            {
                Cliente cliente;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ClienteBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliId));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.CliId = int.Parse(reader["CliCod"].ToString());
                        cliente.CliNom = reader["CliNom"].ToString();
                        cliente.CliCi = reader["CliCi"].ToString();
                        cliente.CliTel = reader["CliTel"].ToString();
                        cliente.CliDir = reader["CliDir"].ToString();
                        cliente.CliMail = reader["CliMail"].ToString();
                        cliente.FchRegistro = DateTime.Parse(reader["FchRegistro"].ToString());
                        cliente.CliPass = reader["CliContra"].ToString();
                        cliente.Admin = reader["Admin"].ToString();
                        resultado = cliente;
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

        public static Cliente BuscarUsuarioLogueado(string pCi, string pPass)
        {
            Cliente resultado = new Cliente();
            try
            {
                Cliente cliente;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("UsuarioLoginBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliCi", pCi));
                cmd.Parameters.Add(new SqlParameter("@CliContra", pPass));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.CliId = int.Parse(reader["CliCod"].ToString());
                        cliente.CliNom = reader["CliNom"].ToString();
                        cliente.CliCi = reader["CliCi"].ToString();
                        cliente.CliTel = reader["CliTel"].ToString();
                        cliente.CliDir = reader["CliDir"].ToString();
                        cliente.CliMail = reader["CliMail"].ToString();
                        cliente.FchRegistro = DateTime.Parse(reader["FchRegistro"].ToString());
                        cliente.CliPass = reader["CliContra"].ToString();
                        cliente.Admin = reader["Admin"].ToString();
                        resultado = cliente;
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

        public static bool AltaCliente(Cliente pCliente)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ClienteAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliNom", pCliente.CliNom));
                cmd.Parameters.Add(new SqlParameter("@CliCi", pCliente.CliCi));
                cmd.Parameters.Add(new SqlParameter("@CliTel", pCliente.CliTel));
                cmd.Parameters.Add(new SqlParameter("@CliDir", pCliente.CliDir));
                cmd.Parameters.Add(new SqlParameter("@CliMail", pCliente.CliMail));
                cmd.Parameters.Add(new SqlParameter("@FchRegistro", pCliente.FchRegistro));
                cmd.Parameters.Add(new SqlParameter("@CliContra", pCliente.CliPass));
                cmd.Parameters.Add(new SqlParameter("@Admin", pCliente.Admin));

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

        public static bool BajaCliente(int pCliId)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ClienteBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliId));

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

        public static bool ModificarCliente(Cliente pCliente)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ClienteModificar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliente.CliId));
                cmd.Parameters.Add(new SqlParameter("@CliNom", pCliente.CliNom));
                cmd.Parameters.Add(new SqlParameter("@CliCi", pCliente.CliCi));
                cmd.Parameters.Add(new SqlParameter("@CliTel", pCliente.CliTel));
                cmd.Parameters.Add(new SqlParameter("@CliDir", pCliente.CliDir));
                cmd.Parameters.Add(new SqlParameter("@CliMail", pCliente.CliMail));
                cmd.Parameters.Add(new SqlParameter("@FchRegistro", pCliente.FchRegistro));
                cmd.Parameters.Add(new SqlParameter("@CliContra", pCliente.CliPass));
                cmd.Parameters.Add(new SqlParameter("@Admin", pCliente.Admin));

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

        #endregion

        #region ABM Vehiculos

        public static List<Vehiculo> ListarVehiculo()
        {
            List<Vehiculo> resultado = new List<Vehiculo>();
            try
            {
                Vehiculo vehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("VehiculosListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();

                        resultado.Add(vehiculo);
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

        public static Vehiculo BuscarVehiculo(int pVehiculoCod)
        {
            Vehiculo resultado = new Vehiculo();
            try
            {
                Vehiculo vehiculo;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("VehiculoBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pVehiculoCod));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        resultado = vehiculo;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static Vehiculo BuscarVehiculoMatricula(string pMatricula)
        {
            Vehiculo resultado = new Vehiculo();
            try
            {
                Vehiculo vehiculo;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("VehiculoBuscarMatricula", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Matricula", pMatricula));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        resultado = vehiculo;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool AltaVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("vehiculoAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));


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

        public static bool BajaVehiculo(int pVehiculoCod)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("VehiculoBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pVehiculoCod));

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

        public static bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("VehiculoModificar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pVehiculo.VehiculoCod));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));

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

        #endregion

        #region ABM Reservas
        public static List<Reserva> ListarReservas()
        {
            List<Reserva> resultado = new List<Reserva>();
            try
            {
                Reserva reserva;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand cmd = new SqlCommand("ReservasListar", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reserva = new Reserva();
                        reserva.ReservasCod = int.Parse(reader["ReservasCod"].ToString());
                        reserva.ReservaFch = DateTime.Parse(reader["ReservaFch"].ToString());
                        reserva.ReservaDsc = reader["ReservaDsc"].ToString();
                        reserva.CliCod = int.Parse(reader["CliCod"].ToString());
                        reserva.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());

                        resultado.Add(reserva);
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

        public static Reserva BuscarReserva(int pReservasCod)
        {
            Reserva resultado = new Reserva();
            try
            {
                Reserva reserva;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReservaBuscar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ReservasCod", pReservasCod));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reserva = new Reserva();
                        reserva.ReservasCod = int.Parse(reader["ReservasCod"].ToString());
                        reserva.ReservaFch = DateTime.Parse(reader["ReservaFch"].ToString());
                        reserva.ReservaDsc = reader["ReservaDsc"].ToString();
                        reserva.CliCod = int.Parse(reader["CliCod"].ToString());
                        reserva.VehiculoCod = int.Parse(reader["VehiculoCod"].ToString());
                        resultado = reserva;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static bool AltaReserva(Reserva pReserva)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReservaAlta", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ReservaFch", pReserva.ReservaFch));
                cmd.Parameters.Add(new SqlParameter("@ReservaDsc", pReserva.ReservaDsc));
                cmd.Parameters.Add(new SqlParameter("@CliCod", pReserva.CliCod));
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pReserva.VehiculoCod));


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

        public static bool BajaReserva(int pReservasCod)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReservaBaja", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ReservasCod", pReservasCod));

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

        public static bool ModificarReservas(Reserva pReserva)
        {
            bool resultado = false;

            try
            {
                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("ReservaModificar", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ReservasCod", pReserva.ReservasCod));
                cmd.Parameters.Add(new SqlParameter("@ReservaFch", pReserva.ReservaFch));
                cmd.Parameters.Add(new SqlParameter("@ReservaDsc", pReserva.ReservaDsc));
                cmd.Parameters.Add(new SqlParameter("@CliCod", pReserva.CliCod));
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pReserva.VehiculoCod));

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

        #endregion
    }
}
