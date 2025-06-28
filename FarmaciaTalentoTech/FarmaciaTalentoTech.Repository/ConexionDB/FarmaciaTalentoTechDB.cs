using System;
using Microsoft.Data.SqlClient; // Aseg�rate de tener la referencia a Microsoft.Data.SqlClient
using FarmaciaTalentoTech.Model.Dto;
using System.Data;
using FarmaciaTalentoTech.Model.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FarmaciaTalentoTech.Repository.ConexionDB;

public class FarmaciaTalentoTechDB : IFarmaciaTalentoTechDB
{
    public string? ConnectionString { get; set; }

    public SqlConnection Connection { get; set; }

    public FarmaciaTalentoTechDB()
    { }

    public FarmaciaTalentoTechDB(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("FarmaciaTalentoTechDBConnection");
        Connection = new SqlConnection(ConnectionString);
    }

    /// <summary>
    /// Crea un nuevo usuario en la base de datos.
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool CrearUsuario(Usuario usuario)
    {
        try
        {
            var cmd = new SqlCommand("usp_creacion_usuario", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@NombreUsuario", usuario.NombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email));
            cmd.Parameters.Add(new SqlParameter("@Password", usuario.Password));
            cmd.Parameters.Add(new SqlParameter("@IdRole", usuario.IdRol));

            Connection.Open();
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
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }


    /// <summary>  
    /// Actualiza la información de un usuario existente en la base de datos.  
    /// </summary>  
    /// <param name="usuario">Objeto de tipo Usuario que contiene los datos actualizados del usuario.</param>  
    /// <returns>True si el usuario fue actualizado correctamente; de lo contrario, false.</returns>  
    /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la conexión o ejecución en la base de datos.</exception>
    public bool ActualizarUsuario(Usuario usuario) {
       
        try {
            var cmd = new SqlCommand("usp_update_usuario", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", usuario.NombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@email", usuario.Email));
            cmd.Parameters.Add(new SqlParameter("@passaword", usuario.Password));
            cmd.Parameters.Add(new SqlParameter("@id_role", usuario.IdRol));

            Connection.Open();
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0; // Retorna true si se actualizó el usuario correctamente
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            throw new Exception("Error, comuniquese con el Administrador.", ex);
        }
        finally
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }


    /// <summary>  
    /// Elimina un usuario de la base de datos por su nombre de usuario.  
    /// </summary>  
    /// <param name="nombreUsuario">Nombre del usuario que se desea eliminar.</param>  
    /// <returns>True si el usuario fue eliminado correctamente; de lo contrario, false.</returns>  
    /// <exception cref="Exception">Lanza una excepción si ocurre un error durante la conexión o ejecución en la base de datos.</exception>
    public bool EliminarUsuario(string nombreUsuario)
    {
        try
        {
            var cmd = new SqlCommand("usp_eliminar_usuario", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", nombreUsuario));

            Connection.Open();
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0; // Retorna true si se eliminó el usuario correctamente
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            throw new Exception("Error, comuniquese con el Administrador.", ex);
        }
        finally
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
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
        try
        {
            var cmd = new SqlCommand("usp_autenticacion_usuario", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            //Agregar parametros
            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", nombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            Connection.Open();

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
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
