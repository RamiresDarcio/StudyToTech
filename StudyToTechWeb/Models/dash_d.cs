using System;

namespace StudyToTechWeb.Models
{
    public class DashboardEstudos
    {
        public string ConteudoEstudado { get; set; }

        public string Disciplina { get; set; }

        public int TempoEstudo { get; set; }

        public string MaterialUtilizado { get; set; }

        public string TipoConteudo { get; set; }

        public string ProgressoEstudo { get; set; }

        // Registrar atividade de estudo
        public void RegistrarAtividade()
        {
            Console.WriteLine("\n===== DASHBOARD DE ESTUDOS =====");

            Console.WriteLine("Digite o conteúdo estudado:");
            ConteudoEstudado = Console.ReadLine();

            Console.WriteLine("Digite a disciplina:");
            Disciplina = Console.ReadLine();

            Console.WriteLine("Digite o tempo de estudo:");
            TempoEstudo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o material utilizado:");
            MaterialUtilizado = Console.ReadLine();

            Console.WriteLine("Digite o tipo de conteúdo:");
            TipoConteudo = Console.ReadLine();

            Console.WriteLine("Digite o progresso do estudo:");
            ProgressoEstudo = Console.ReadLine();

            Console.WriteLine("Atividade registrada com sucesso!");
        }

        // Exibir resumo
        public void ExibirResumo()
        {
            Console.WriteLine("\n===== RESUMO DE ESTUDOS =====");

            Console.WriteLine("Conteúdo estudado: " + ConteudoEstudado);

            Console.WriteLine("Disciplina: " + Disciplina);

            Console.WriteLine("Tempo de estudo: " + TempoEstudo + " horas");

            Console.WriteLine("Material utilizado: " + MaterialUtilizado);

            Console.WriteLine("Tipo de conteúdo: " + TipoConteudo);

            Console.WriteLine("Progresso: " + ProgressoEstudo);
        }
    }
}