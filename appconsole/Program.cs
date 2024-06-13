// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.Data.SqlClient;

public class Alumno
{
    public int Codigo { get; set; }
    public string Nombres { get; set; }
    public string Carrera { get; set; }
    public string Domicilio { get; set; }

    public static void InsertarAlumno(Alumno alumno, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("InsertarAlumno", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Codigo", alumno.Codigo);
            command.Parameters.AddWithValue("@Nombres", alumno.Nombres);
            command.Parameters.AddWithValue("@Carrera", alumno.Carrera);
            command.Parameters.AddWithValue("@Domicilio", alumno.Domicilio);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Alumno insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el alumno: " + ex.Message);
            }
        }
    }
    
    public static void BuscarAlumno(int codigo, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("ObtenerAlumnos", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["codigo"] == codigo)
                    {
                        Console.WriteLine($"Codigo: {reader["codigo"]}, Nombres: {reader["nombres"]}, Carrera: {reader["carrera"]}, Domicilio: {reader["domicilio"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el alumno: " + ex.Message);
            }
        }
    }

    public static void ModificarAlumno(Alumno alumno, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("ActualizarAlumno", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Codigo", alumno.Codigo);
            command.Parameters.AddWithValue("@Nombres", alumno.Nombres);
            command.Parameters.AddWithValue("@Carrera", alumno.Carrera);
            command.Parameters.AddWithValue("@Domicilio", alumno.Domicilio);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Alumno modificado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el alumno: " + ex.Message);
            }
        }
    }

    public static void EliminarAlumno(int codigo, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("EliminarAlumno", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Codigo", codigo);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Alumno eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el alumno: " + ex.Message);
            }
        }
    }
    
}


class Program{
    static void Main(string[] args){
         string connectionString = "Server=DESKTOP-FO7H8J2\\SQLEXPRESS;Database=prueba_2;integrated security=true";
        /*
        // Crear un nuevo alumno
        Alumno nuevoAlumno = new Alumno { Codigo = 7, Nombres = "Juan Perez", Carrera = "Ingeniería", Domicilio = "Calle Falsa 123" };
        Alumno.InsertarAlumno(nuevoAlumno, connectionString);
        */
        // Buscar un alumno
        Alumno.BuscarAlumno(7, connectionString);

        // Modificar un alumno
        Alumno alumnoModificado = new Alumno { Codigo = 7, Nombres = "Juan Modificado", Carrera = "Ingeniería Modificada", Domicilio = "Calle 123 Modificada" };
        Alumno.ModificarAlumno(alumnoModificado, connectionString);
        Alumno.BuscarAlumno(7, connectionString);

        // Eliminar un alumno
        Alumno.EliminarAlumno(7, connectionString);


    }
}
