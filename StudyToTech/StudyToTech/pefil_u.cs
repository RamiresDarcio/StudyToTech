using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyToTech
{
    public class PerfilUsuario
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public string DisciplinaFavorita { get; set; } = string.Empty;
        public string MetaAtual { get; set; } = string.Empty;
        public int TotalTrofeus { get; set; }
        public string AreasInteresse { get; set; } = string.Empty;
        public string ConteudosEstudados { get; set; } = string.Empty;
        public int MetasConcluidas { get; set; }
        public int HorasEstudadas { get; set; }
        public List<string> Conquistas { get; set; } = new List<string>();
        public string EvolucaoDisciplinas { get; set; } = string.Empty;
        public int SequenciaDiasEstudando { get; set; }
        public string ResultadosAtividades { get; set; } = string.Empty;

        public void CriarPerfil()
        {
            Console.WriteLine("\n===== PERFIL =====");

            Console.WriteLine("Digite o nome do usuário:");
            NomeUsuario = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a foto de perfil (URL ou descrição):");
            FotoPerfil = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a disciplina favorita:");
            DisciplinaFavorita = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a meta atual:");
            MetaAtual = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite as áreas de interesse (separadas por vírgula):");
            AreasInteresse = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite conteúdos estudados recentemente:");
            ConteudosEstudados = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite uma breve descrição da evolução nas disciplinas:");
            EvolucaoDisciplinas = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite resultados alcançados em provas e atividades:");
            ResultadosAtividades = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a sequência de dias estudando:");
            if (!int.TryParse(Console.ReadLine(), out int dias))
            {
                dias = 0;
            }
            SequenciaDiasEstudando = dias;

            Console.WriteLine("Digite o total de troféus:");
            if (!int.TryParse(Console.ReadLine(), out int trofeus))
            {
                trofeus = 0;
            }
            TotalTrofeus = trofeus;
        }

        public void AtualizarDesempenho(List<MetaEstudo> metas, int horasEstudadas)
        {
            MetasConcluidas = metas.Count(m => m.MetaConcluida);
            HorasEstudadas = horasEstudadas;
            Conquistas = metas.Where(m => m.MetaConcluida).Select(m => m.ObterConquista()).ToList();
            TotalTrofeus = Conquistas.Count;
        }

        public void ExibirPerfil()
        {
            Console.WriteLine("\n===== PERFIL DO ESTUDANTE =====");
            Console.WriteLine("Usuário: " + NomeUsuario);
            Console.WriteLine("Foto de perfil: " + FotoPerfil);
            Console.WriteLine("Disciplina favorita: " + DisciplinaFavorita);
            Console.WriteLine("Meta atual: " + MetaAtual);
            Console.WriteLine("Áreas de interesse: " + AreasInteresse);
            Console.WriteLine("Conteúdos estudados: " + ConteudosEstudados);
            Console.WriteLine("Evolução nas disciplinas: " + EvolucaoDisciplinas);
            Console.WriteLine("Resultados em provas e atividades: " + ResultadosAtividades);
            Console.WriteLine("Metas concluídas: " + MetasConcluidas);
            Console.WriteLine("Horas dedicadas aos estudos: " + HorasEstudadas);
            Console.WriteLine("Sequência de dias estudando: " + SequenciaDiasEstudando);
            Console.WriteLine("Troféus: " + TotalTrofeus);
            Console.WriteLine("Conquistas: " + (Conquistas.Count > 0 ? string.Join(", ", Conquistas) : "Nenhuma"));
        }

        public void CompartilharProgresso()
        {
            Console.WriteLine("\n===== RESUMO DE PROGRESSO PARA COMPARTILHAMENTO =====");
            Console.WriteLine($"{NomeUsuario} está estudando com foco em {DisciplinaFavorita} e mantendo uma média de {HorasEstudadas} horas de estudo.");
            Console.WriteLine($"Metas concluídas: {MetasConcluidas}, troféus: {TotalTrofeus}, sequência de dias: {SequenciaDiasEstudando}.");
            Console.WriteLine($"Principais áreas de interesse: {AreasInteresse}");
            Console.WriteLine($"Evolução em disciplinas: {EvolucaoDisciplinas}");
            Console.WriteLine($"Resultados recentes: {ResultadosAtividades}");
            Console.WriteLine("Compartilhe este resumo com seus colegas para inspirar uma rotina de estudos produtiva!");
        }
    }
}
