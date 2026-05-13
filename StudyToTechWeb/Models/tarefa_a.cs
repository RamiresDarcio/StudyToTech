using System;

namespace StudyToTechWeb.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Disciplina { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime Prazo { get; set; }
        public int TempoEstudo { get; set; }
        public int TempoRestante { get; set; }

        public void cadastrar_tarefa()
        {
            Console.WriteLine("\n===== CADASTRO DE TAREFA =====");

            Console.WriteLine("Digite o título da tarefa:");
            Titulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição:");
            Descricao = Console.ReadLine();

            Console.WriteLine("Digite a disciplina:");
            Disciplina = Console.ReadLine();

            Console.WriteLine("Digite a prioridade:");
            Prioridade = Console.ReadLine();

            Console.WriteLine("Digite o status:");
            Status = Console.ReadLine();

            Console.WriteLine("Digite o prazo:");
            Prazo = Console.ReadLine();

            Console.WriteLine("Tarefa cadastrada com sucesso!");
        }
    }
}



