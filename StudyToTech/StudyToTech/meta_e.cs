using System;

namespace StudyToTech
{
    public class MetaEstudo
    {
        public string NomeMeta { get; set; } = string.Empty;

        public string Disciplina { get; set; } = "Geral";

        public string TipoMeta { get; set; } = "Diária";

        public string Descricao { get; set; } = string.Empty;

        public int TempoMeta { get; set; }

        public int TempoConcluido { get; set; }

        public bool MetaConcluida { get; set; }

        public string Trofeu { get; set; } = "Nenhum";

        public string Medalha { get; set; } = "Nenhuma";

        public string Nivel { get; set; } = "Iniciante";

        public int ProgressoPercentual => TempoMeta > 0 ? Math.Min(100, TempoConcluido * 100 / TempoMeta) : 0;

        public void CriarMeta()
        {
            Console.WriteLine("\n===== META DE ESTUDO =====");

            Console.WriteLine("Digite o nome da meta:");
            NomeMeta = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a disciplina (ou deixe em branco para geral):");
            string disciplina = Console.ReadLine();
            Disciplina = string.IsNullOrWhiteSpace(disciplina) ? "Geral" : disciplina;

            Console.WriteLine("Escolha o tipo de meta:");
            Console.WriteLine("1. Diária");
            Console.WriteLine("2. Semanal");
            string tipo = Console.ReadLine();
            TipoMeta = tipo == "2" ? "Semanal" : "Diária";

            Console.WriteLine("Escolha o objetivo da meta:");
            Console.WriteLine("1. 30 minutos de estudo");
            Console.WriteLine("2. 1 hora de foco");
            Console.WriteLine("3. 2 horas de revisão");
            Console.WriteLine("4. 5 horas de dedicação");
            Console.WriteLine("5. Meta personalizada");

            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    TempoMeta = 30;
                    Descricao = "30 minutos de estudo";
                    break;
                case "2":
                    TempoMeta = 60;
                    Descricao = "1 hora de foco";
                    break;
                case "3":
                    TempoMeta = 120;
                    Descricao = "2 horas de revisão";
                    break;
                case "4":
                    TempoMeta = 300;
                    Descricao = "5 horas de dedicação";
                    break;
                default:
                    Console.WriteLine("Digite o tempo da meta em minutos:");
                    if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos <= 0)
                    {
                        minutos = 30;
                    }
                    TempoMeta = minutos;
                    Descricao = $"Meta personalizada ({TempoMeta} minutos)";
                    break;
            }

            TempoConcluido = 0;
            MetaConcluida = false;
            Trofeu = "Nenhum";
            Medalha = "Nenhuma";
            Nivel = "Iniciante";

            Console.WriteLine($"Meta '{NomeMeta}' criada: {Descricao} para {Disciplina} ({TipoMeta}).");
        }

        public void RegistrarProgresso(int minutos)
        {
            if (minutos <= 0)
            {
                Console.WriteLine("Insira um tempo válido para registrar o progresso.");
                return;
            }

            TempoConcluido += minutos;
            if (TempoConcluido > TempoMeta)
            {
                TempoConcluido = TempoMeta;
            }

            VerificarMeta();
        }

        public void VerificarMeta()
        {
            if (TempoConcluido >= TempoMeta)
            {
                MetaConcluida = true;
                Trofeu = "Troféu de Disciplina";
                Medalha = "Medalha de Ouro";
                Nivel = "Avançado";
                Console.WriteLine("Meta concluída! Parabéns, você desbloqueou uma conquista!");
            }
            else
            {
                MetaConcluida = false;
                if (ProgressoPercentual >= 75)
                {
                    Medalha = "Medalha de Prata";
                    Nivel = "Intermediário";
                }
                else if (ProgressoPercentual >= 50)
                {
                    Medalha = "Medalha de Bronze";
                    Nivel = "Iniciante";
                }
                else
                {
                    Medalha = "Nenhuma";
                    Nivel = "Iniciante";
                }

                Console.WriteLine("Meta não concluída ainda.");
            }
        }

        public void ExibirMeta()
        {
            Console.WriteLine("\n===== STATUS DA META =====");
            Console.WriteLine("Meta: " + NomeMeta);
            Console.WriteLine("Disciplina: " + Disciplina);
            Console.WriteLine("Tipo: " + TipoMeta);
            Console.WriteLine("Descrição: " + Descricao);
            Console.WriteLine("Tempo da meta: " + TempoMeta + " minutos");
            Console.WriteLine("Tempo concluído: " + TempoConcluido + " minutos");
            Console.WriteLine("Progresso: " + ProgressoPercentual + "%");
            Console.WriteLine("Troféu: " + Trofeu);
            Console.WriteLine("Medalha: " + Medalha);
            Console.WriteLine("Nível: " + Nivel);
        }

        public string ObterConquista()
        {
            if (MetaConcluida)
            {
                return $"{NomeMeta} ({Disciplina}) - {Trofeu} / {Medalha} / Nível {Nivel}";
            }

            return $"{NomeMeta} ({Disciplina}) - {ProgressoPercentual}% concluída - {Medalha}";
        }
    }
}