using System;
using Microsoft.Data.SqlClient; // Aseg�rate de tener la referencia a Microsoft.Data.SqlClient
using FarmaciaTalentoTech.Model.Entidades;
using System.Data;

namespace FarmaciaTalentoTech.Repository.ConexionDB;

public class FarmaciaTalentoTechDB
{
    public string ConnectionString { get; set; }
        = "Server=localhost;Database=FarmaciaTalentoTech;User Id=sa;Password=admin;Encrypt=False;TrustServerCertificate=True;";

    public FarmaciaTalentoTechDB()
    { }

    public FarmaciaTalentoTechDB(string connectionString)
    {
        ConnectionString = connectionString;
    }

    /// <summary>
    /// Crea un nuevo usuario en la base de datos.
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool CrearUsuario(Usuario usuario)
    {
        var conn = new SqlConnection(ConnectionString);
        try
        {
            var cmd = new SqlCommand("usp_creacion_usuario", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@NombreUsuario", usuario.NombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
            cmd.Parameters.Add(new SqlParameter("@Password", usuario.Password));
            cmd.Parameters.Add(new SqlParameter("@IdRole", usuario.IdRol));

            conn.Open();
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0; // Retorna true si se creó el usuario correctamente
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            throw new Exception("Error, comuniquese con el Administrador.", ex);
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

    /// <summary>
    /// Obtiene un usuario de la base de datos por nombre de usuario y contraseña.
    /// </summary>
    /// <param name="nombreUsuario"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Usuario ObtenerUsuario(string nombreUsuario, string password)
    {
        var conn = new SqlConnection(ConnectionString);
        try
        {
            var cmd = new SqlCommand("usp_autenticacion_usuario", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Agregar parametros
            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", nombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            conn.Open();

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var usuario = new Usuario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    NombreUsuario = reader.GetString(reader.GetOrdinal("NombreUsuario")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    IdRol = reader.GetInt32(reader.GetOrdinal("IdRole"))
                };

                return usuario;
            }

            return null; // Si no se encuentra el usuario

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            throw new Exception("Error, comuniquese con el Administrador.", ex);
        }
        finally
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
