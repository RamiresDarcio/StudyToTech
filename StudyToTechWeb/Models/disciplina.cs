using System;

namespace StudyToTechWeb.Models
{
    public class Disciplina
    {
        public string? nome { get; set; }
        public string? categoria { get; set; }
        public string? nivel_de_prioridade { get; set; }
        public string? descricao { get; set; }
        public int tempo_estudo { get; set; }

        public void cadastrar_disciplina()
        {
            Console.WriteLine("Digite o nome da disciplina");
            nome = Console.ReadLine();
            Console.WriteLine("Digite a categoria da disciplina");
            categoria = Console.ReadLine();
            Console.WriteLine("Digite o nível de prioridade da disciplina");
            nivel_de_prioridade = Console.ReadLine();
            Console.WriteLine("Digite a descrição da disciplina");
            descricao = Console.ReadLine();
            Console.WriteLine("Digite o tempo de estudo da disciplina");
            string? input = Console.ReadLine();
            if (input != null)
                tempo_estudo = int.Parse(input);
        }
    }
}