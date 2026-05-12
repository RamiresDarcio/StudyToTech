using System;
using System.Data.SqlClient;
using StudyToTech.Data;

namespace StudyToTech.Repositories
{
    class TarefaRepositorio
    {
        private ConexaoDB conexao = new ConexaoDB();

        public void Adicionar(tarefa_a tarefa, int disciplinaId)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "INSERT INTO Tarefas (DisciplinaId, Titulo, Descricao, DataEntrega) VALUES (@disciplinaId, @titulo, @descricao, @dataEntrega)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@disciplinaId", disciplinaId);
                    cmd.Parameters.AddWithValue("@titulo", tarefa.Titulo ?? string.Empty);
                    cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao ?? string.Empty);
                    cmd.Parameters.AddWithValue("@dataEntrega", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Tarefa adicionada ao banco com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar tarefa: {ex.Message}");
            }
        }

        public void ListarPorDisciplina(int disciplinaId)
        {
            try
            {
                using (SqlConnection conn = conexao.ObterConexao())
                {
                    if (conn == null) return;
                    
                    string query = "SELECT * FROM Tarefas WHERE DisciplinaId = @disciplinaId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@disciplinaId", disciplinaId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]} - Título: {reader["Titulo"]} - Status: {reader["Concluida"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar tarefas: {ex.Message}");
            }
        }
    }
}
