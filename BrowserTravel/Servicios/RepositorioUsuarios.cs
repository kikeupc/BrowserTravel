﻿using BrowserTravel.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BrowserTravel.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> BuscarUsuarioPorEmail(string emailNormalizado);
        Task<int> CrearUsuario(Usuario usuario);
    }
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Envía datos de un nuevo usuario a la base de datos para su creación
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public async Task<int> CrearUsuario(Usuario usuario)
        {
            using var connection = new SqlConnection(connectionString);
            var usuarioId = await connection.QuerySingleAsync<int>(@"
            INSERT INTO Usuarios(Email, EmailNormalizado, PasswordHash)
            VALUES(@Email, @EmailNormalizado, @PasswordHash)
            SELECT SCOPE_IDENTITY()", usuario);

            return usuarioId;
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string emailNormalizado)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QuerySingleOrDefaultAsync<Usuario>(
                   "SELECT * FROM Usuarios WHERE EmailNormalizado = @emailNormalizado", new { emailNormalizado });
        }
    }
}
