using System;
using System.Data.SqlClient;
using StudyToTech.Data;

namespace StudyToTech.Repositories
{
    class UsuarioRepositorio
    {
        private ConexaoDB conexao = new ConexaoDB();

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "INSERT INTO Usuarios (Nome, Email) VALUES (@nome, @email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", usuario.Nome ?? string.Empty);
                    cmd.Parameters.AddWithValue("@email", usuario.Email ?? string.Empty);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Usuário adicionado ao banco com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
            }
        }

        public Usuario BuscarPorId(int id)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return null;
                    
                    string query = "SELECT * FROM Usuarios WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar usuário: {ex.Message}");
                return null;
            }
        }

        public void ListarTodos()
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "SELECT * FROM Usuarios";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]} - Nome: {reader["Nome"]} - Email: {reader["Email"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar usuários: {ex.Message}");
            }
        }
    }
}
