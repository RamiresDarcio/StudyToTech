using System;

namespace StudyToTechWeb.Models
{
    public class CalendarioEstudos
    {
        public string? Data { get; set; }

        public string? Horario { get; set; }

        public string? Atividade { get; set; }

        public string? Disciplina { get; set; }

        public string? TipoEvento { get; set; }

        public string? Observacao { get; set; }

        // Cadastro do evento no calendário
        public void AdicionarEvento()
        {
            Console.WriteLine("\n===== CALENDÁRIO DE ESTUDOS =====");

            Console.WriteLine("Digite a data do evento:");
            Data = Console.ReadLine();

            Console.WriteLine("Digite o horário:");
            Horario = Console.ReadLine();

            Console.WriteLine("Digite a atividade:");
            Atividade = Console.ReadLine();

            Console.WriteLine("Digite a disciplina:");
            Disciplina = Console.ReadLine();

            Console.WriteLine("Digite o tipo do evento:");
            TipoEvento = Console.ReadLine();

            Console.WriteLine("Digite uma observação:");
            Observacao = Console.ReadLine();

            Console.WriteLine("Evento adicionado ao calendário!");
        }

        // Exibir evento
        public void ExibirEvento()
        {
            Console.WriteLine("\n===== EVENTO DO CALENDÁRIO =====");

            Console.WriteLine("Data: " + Data);

            Console.WriteLine("Horário: " + Horario);

            Console.WriteLine("Atividade: " + Atividade);

            Console.WriteLine("Disciplina: " + Disciplina);

            Console.WriteLine("Tipo do evento: " + TipoEvento);

            Console.WriteLine("Observação: " + Observacao);
        }
    }
}