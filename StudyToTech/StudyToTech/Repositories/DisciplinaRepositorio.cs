using System;
using System.Data.SqlClient;
using StudyToTech.Data;

namespace StudyToTech.Repositories
{
    class DisciplinaRepositorio
    {
        private ConexaoDB conexao = new ConexaoDB();

        public void Adicionar(Disciplina disciplina, int usuarioId)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "INSERT INTO Disciplinas (UsuarioId, Nome, Descricao) VALUES (@usuarioId, @nome, @descricao)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@nome", disciplina.nome ?? "");
                    cmd.Parameters.AddWithValue("@descricao", disciplina.descricao ?? "");
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Disciplina adicionada ao banco com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar disciplina: {ex.Message}");
            }
        }

        public void ListarPorUsuario(int usuarioId)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "SELECT * FROM Disciplinas WHERE UsuarioId = @usuarioId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]} - Nome: {reader["Nome"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar disciplinas: {ex.Message}");
            }
        }
    }
}
