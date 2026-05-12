using System;
using System.Data.SqlClient;

namespace StudyToTech.Data
{
    class ConexaoDB
    {
        private string connectionString = "Server=localhost;Database=StudyToTech;User Id=sa;Password=sua_senha;";

        public SqlConnection ObterConexao()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(connectionString);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar no banco de dados: {ex.Message}");
                return null;
            }
        }

        public void DefinirConnectionString(string server, string database, string usuario, string senha)
        {
            connectionString = $"Server={server};Database={database};User Id={usuario};Password={senha};";
        }
    }
}
