using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyToTech
{
    public class HistoricoAtividades
    {
        private List<AtividadeHistorico> atividades = new List<AtividadeHistorico>();

        public int TotalAtividades => atividades.Count;

        public int TotalMinutosEstudo => atividades.Where(a => a.Tipo == "Tempo dedicado aos estudos").Sum(a => a.DuracaoMinutos);

        public int TotalMetasConcluidas => atividades.Count(a => a.Tipo == "Meta de estudo concluída");

        public string DisciplinasMaisAcessadas()
        {
            var top = atividades
                .Where(a => !string.IsNullOrWhiteSpace(a.Disciplina))
                .GroupBy(a => a.Disciplina)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => g.Key)
                .ToList();

            return top.Count > 0 ? string.Join(", ", top) : "Nenhuma";
        }

        public void AdicionarAtividade()
        {
            Console.WriteLine("\n===== REGISTRAR ATIVIDADE NO HISTÓRICO =====");
            Console.WriteLine("Selecione o tipo de atividade:");
            Console.WriteLine("1. Meta de estudo concluída");
            Console.WriteLine("2. Tempo dedicado aos estudos");
            Console.WriteLine("3. Anotação criada");
            Console.WriteLine("4. Livro ou material lido");
            Console.WriteLine("5. Videoaula ou conteúdo assistido");
            Console.WriteLine("6. Áudio ou material do professor");
            Console.WriteLine("7. Conteúdo estudado recentemente");
            Console.WriteLine("8. Disciplina acessada");
            Console.Write("Opção: ");
            string tipo = Console.ReadLine();

            Console.WriteLine("Digite a disciplina relacionada (ou deixe em branco):");
            string disciplina = Console.ReadLine() ?? string.Empty;

            int duracao = 0;
            if (tipo == "2")
            {
                Console.WriteLine("Digite o tempo dedicado em minutos:");
                int.TryParse(Console.ReadLine(), out duracao);
            }

            Console.WriteLine("Digite um breve resumo da atividade:");
            string descricao = Console.ReadLine() ?? string.Empty;

            string nomeTipo = tipo switch
            {
                "1" => "Meta de estudo concluída",
                "2" => "Tempo dedicado aos estudos",
                "3" => "Anotação criada",
                "4" => "Livro ou material lido",
                "5" => "Videoaula ou conteúdo assistido",
                "6" => "Áudio ou material do professor",
                "7" => "Conteúdo estudado recentemente",
                "8" => "Disciplina acessada",
                _ => "Atividade geral"
            };

            atividades.Add(new AtividadeHistorico
            {
                DataHora = DateTime.Now,
                Tipo = nomeTipo,
                Disciplina = disciplina,
                DuracaoMinutos = duracao,
                Descricao = descricao
            });

            Console.WriteLine("Atividade registrada no histórico com sucesso!");
        }

        public void MostrarHistorico()
        {
            Console.WriteLine("\n===== HISTÓRICO DE ATIVIDADES =====");

            if (atividades.Count == 0)
            {
                Console.WriteLine("Nenhuma atividade registrada ainda.");
                return;
            }

            foreach (AtividadeHistorico atividade in atividades)
            {
                Console.WriteLine($"[{atividade.DataHora:dd/MM/yyyy HH:mm}] {atividade.Tipo}");
                if (!string.IsNullOrWhiteSpace(atividade.Disciplina))
                {
                    Console.WriteLine("Disciplina: " + atividade.Disciplina);
                }

                if (atividade.DuracaoMinutos > 0)
                {
                    Console.WriteLine("Duração: " + atividade.DuracaoMinutos + " minutos");
                }

                Console.WriteLine("Descrição: " + atividade.Descricao);
                Console.WriteLine();
            }
        }
    }

    public class AtividadeHistorico
    {
        public DateTime DataHora { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Disciplina { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
