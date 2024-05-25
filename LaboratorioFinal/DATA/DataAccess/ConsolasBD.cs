using LaboratorioFinal.DATA.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioFinal.DATA.DataAccess
{
    internal class ConsolasBD
    {
        string connectionString = "server=localhost;database=LaboratorioCRUD;user=root;password=";
        MySqlConnection connection;
        public ConsolasBD()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Insertar(string nombre_consola, string compania, DateTime anio_lanzamiento, string generacion)
        {
            try
            {
                string query = "INSERT INTO catologo_consolas (NombreConsola, Compania, FechaLanzamiento, Generacion) VALUES (@NombreConsola, @Compania, @FechaLanzamiento,  @Generacion)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreConsola", nombre_consola);
                cmd.Parameters.AddWithValue("@Compania", compania);
                cmd.Parameters.AddWithValue("@FechaLanzamiento", anio_lanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void Actualizar(int id, string nombre_consola, string compania, DateTime anio_lanzamiento, string generacion)
        {
            try
            {
                string query = "UPDATE catologo_consolas SET Nombre = @NombreConsola, @Compania, @FechaLanzamiento, @Generacion WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@NombreConsola", nombre_consola);
                cmd.Parameters.AddWithValue("@Compani", compania);
                cmd.Parameters.AddWithValue("@FechaLanzamiento", anio_lanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable LeerTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM catologo_consolas";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los registros: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public DataRow LeerPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM catologo_consolas WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt.Rows[0];
        }
        public void Insertar(Catologo usr)
        {
            try
            {
                string query = "INSERT INTO catologo_consolas (NombreConsola, Compania, FechaLanzamiento, Generacion) VALUES (@NombreConsola, @Compania, @FechaLanzamiento, @Generacion)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreConsola", usr.Nombre_Consola);
                cmd.Parameters.AddWithValue("@Compania", usr.Compania);
                cmd.Parameters.AddWithValue("@FechaLanzamiento", usr.Fecha_Lanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", usr.Generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Catologo> ObtenerTodosLosUsuarios()
        {
            List<Catologo> usuarios = new List<Catologo>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM catologo_consolas";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Catologo usuario = new Catologo
                        (
                            id: reader.GetInt32("ID"),
                            nombre_consola: reader.GetString("NombredConsola"),
                            compania: reader.GetString("Compania"),
                            anio_lanzamiento: reader.GetDateTime("Fecha Lanzamiento"),
                            generacion: reader.GetString("Generacion")
                        );

                        usuarios.Add(usuario);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return usuarios;
        }
        
    }
}
