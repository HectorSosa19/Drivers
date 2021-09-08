using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
using CapaNegocio;
namespace CapaDatos
{

    public class D_Choferes
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Choferes_Base_de_datos_.Properties.Settings.Servicio_Autobus3ConnectionString"].ConnectionString);
        public List<E_Choferes> ListarChoferes(String buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarChoferes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Buscar", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_Choferes> Listar = new List<E_Choferes>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_Choferes
                {
                    IdChoferes = leerFilas.GetInt32(0),
                    Codigo = leerFilas.GetString(1),
                    IdRutas = leerFilas.GetInt32(2),
                    IdAutobus = leerFilas.GetInt32(3),
                    Estado = leerFilas.GetString(4),
                    Nombre = leerFilas.GetString(5),
                    Apellido = leerFilas.GetString(6),
                    Fecha_de_nacimiento = leerFilas.GetDateTime(7),
                    Cedula = leerFilas.GetString(8),
                });
            }
            
            
            conexion.Close();
            leerFilas.Close();
            return Listar;


        }
        public List<E_Choferes> ListarAutobuses(String buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarAutobuses", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Buscar", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_Choferes> Listar = new List<E_Choferes>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_Choferes
                {
                    IdAutobus = leerFilas.GetInt32(0),
                    Codigo = leerFilas.GetString(1),
                    IdChoferes=leerFilas.GetInt32(2),
                    Estado = leerFilas.GetString(3),
                    Marca = leerFilas.GetString(4),
                    Modelo = leerFilas.GetString(5),
                    Color = leerFilas.GetString(6),
                    Placa = leerFilas.GetString(7),
                    Año = leerFilas.GetInt32(8),
                });
            }

            conexion.Close();
            leerFilas.Close();
            return Listar;
        }
        

          

        public List<E_Choferes> ListarRuta(String buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarRutas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Buscar", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_Choferes> Listar = new List<E_Choferes>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_Choferes
                {

                    IdRutas = leerFilas.GetInt32(0),
                    Codigo = leerFilas.GetString(1),
                    Nombre_de_ruta = leerFilas.GetString(2),
                });
            }

            conexion.Close();
            leerFilas.Close();
            return Listar;
        }
        public void InsertarChoferes(E_Choferes Choferes)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_InsertarChoferes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@IdRutas", Choferes.IdRutas);
                Console.WriteLine(Choferes.IdRutas);
                cmd.Parameters.AddWithValue("@IdAutobus", Choferes.IdAutobus);
                cmd.Parameters.AddWithValue("@Estado", Choferes.Estado);
                cmd.Parameters.AddWithValue("@Nombre", Choferes.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", Choferes.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", Choferes.Fecha_de_nacimiento);
                cmd.Parameters.AddWithValue("@Cedula", Choferes.Cedula);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e ){
                Console.WriteLine(e.ToString());
            } finally
            {
                
                conexion.Close();
            }

        }
        public void InsertarAutobuses(E_Choferes Autobus)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarAutobuses", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdChoferes", Autobus.IdChoferes);
            cmd.Parameters.AddWithValue("@Estado", Autobus.Estado);
            cmd.Parameters.AddWithValue("@Marca", Autobus.Marca);
            cmd.Parameters.AddWithValue("@Modelo", Autobus.Modelo);
            cmd.Parameters.AddWithValue("@Color", Autobus.Color);
            cmd.Parameters.AddWithValue("@Placa", Autobus.Placa);
            cmd.Parameters.AddWithValue("@Año", Autobus.Año);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void InsertarRutas(E_Choferes Ruta)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarRutas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdRutas", Ruta.Nombre_de_ruta);
            cmd.Parameters.AddWithValue("@Nombre_de_ruta", Ruta.Nombre_de_ruta);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarChoferes(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarChoferes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdChoferes", Choferes.IdChoferes);
            cmd.Parameters.AddWithValue("@IdRutas", Choferes.IdRutas);
            cmd.Parameters.AddWithValue("@IdAutobus", Choferes.IdAutobus);
            cmd.Parameters.AddWithValue("@Estado", Choferes.Estado);
            cmd.Parameters.AddWithValue("@Nombre", Choferes.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", Choferes.Apellido);
            cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", Choferes.Fecha_de_nacimiento);
            cmd.Parameters.AddWithValue("@Cedula", Choferes.Cedula);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarAutobuses(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarAutobuses", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdAutobus", Choferes.IdAutobus);
            cmd.Parameters.AddWithValue("@Estado", Choferes.Estado);
            cmd.Parameters.AddWithValue("@Marca", Choferes.Marca);
            cmd.Parameters.AddWithValue("@Modelo", Choferes.Modelo);
            cmd.Parameters.AddWithValue("@Color", Choferes.Color);
            cmd.Parameters.AddWithValue("@Placa", Choferes.Placa);
            cmd.Parameters.AddWithValue("@Año", Choferes.Año);
    
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EditarRutas(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarRutas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdRutas", Choferes.IdRutas);
            cmd.Parameters.AddWithValue("@Nombre_de_ruta", Choferes.Nombre_de_ruta);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarChoferes(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarChoferes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdChoferes", Choferes.IdChoferes);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarAutobuses(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarAutobuses", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdAutobus", Choferes.IdAutobus);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void EliminarRutas(E_Choferes Choferes)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarRutas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IdRutas", Choferes.IdRutas);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}