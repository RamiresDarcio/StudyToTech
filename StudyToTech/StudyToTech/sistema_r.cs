using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyToTech
{
    public class SistemaRecomendacao
    {
        public string PlanoEstudo { get; set; } = string.Empty;
        public string TecnicaFoco { get; set; } = string.Empty;
        public string MetodoRevisao { get; set; } = string.Empty;
        public string PeriodoDescanso { get; set; } = string.Empty;
        public string MaterialComplementar { get; set; } = string.Empty;
        public string ConteudoRelacionado { get; set; } = string.Empty;
        public string MensagemMotivacional { get; set; } = string.Empty;
        public List<string> MensagensUsuario { get; set; } = new List<string>();

        public void CriarRecomendacao(PerfilUsuario perfil, List<MetaEstudo> metas, HistoricoAtividades historico)
        {
            if (perfil == null)
            {
                Console.WriteLine("Crie um perfil antes de gerar recomendações.");
                return;
            }

            Console.WriteLine("\n===== GERAR RECOMENDAÇÃO PERSONALIZADA =====");
            Console.WriteLine("Para melhorar ainda mais, digite uma mensagem inspiradora ou deixe em branco:");
            string mensagemUsuario = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(mensagemUsuario))
            {
                MensagensUsuario.Add(mensagemUsuario);
            }

            GerarRecomendacao(perfil, metas, historico);
        }

        public void GerarRecomendacao(PerfilUsuario perfil, List<MetaEstudo> metas, HistoricoAtividades historico)
        {
            int totalEstudo = historico?.TotalMinutosEstudo ?? 0;
            int metasConcluidas = historico?.TotalMetasConcluidas ?? 0;
            string disciplinasTop = historico?.DisciplinasMaisAcessadas() ?? "Nenhuma";
            bool estudoRecente = totalEstudo > 0;
            bool metasEmDia = metas.Any(m => m.MetaConcluida);

            PlanoEstudo = estudoRecente
                ? $"Combine 3 blocos de 50 minutos com intervalos de 10 minutos para otimizar {disciplinasTop}."
                : $"Comece com 25 minutos de foco em {perfil.DisciplinaFavorita} e revise o conteúdo em ciclos curtos.";

            TecnicaFoco = metasEmDia
                ? "Use a técnica Pomodoro e priorize revisões no começo do dia para manter o ritmo."
                : "Tente a técnica de foco 25/5 e evite multitarefa para ganhar consistência.";

            MetodoRevisao = metasConcluidas >= 2
                ? "Faça revisões espaçadas de 1, 3 e 7 dias para fixar o conteúdo."
                : "Revise os pontos principais em intervalos curtos logo após o estudo.";

            PeriodoDescanso = totalEstudo >= 120
                ? "Faça pausas de 15 a 20 minutos a cada 90 minutos de estudo para evitar fadiga."
                : "Inclua um descanso leve de 5 a 10 minutos a cada 30 minutos de estudo.";

            MaterialComplementar = !string.IsNullOrWhiteSpace(perfil.AreasInteresse)
                ? $"Busque vídeos e PDFs sobre {perfil.AreasInteresse.Split(',').First().Trim()} para reforçar sua aprendizagem."
                : "Procure artigos, vídeos e resumos de alta qualidade para apoiar seus estudos.";

            ConteudoRelacionado = !string.IsNullOrWhiteSpace(disciplinasTop)
                ? $"Explore conteúdos relacionados às disciplinas mais acessadas: {disciplinasTop}."
                : "Explore conteúdos relacionados aos temas que você estudou recentemente.";

            MensagemMotivacional = MensagensUsuario.Any()
                ? MensagensUsuario.Last()
                : "Continue o bom trabalho! O descanso equilibrado fortalece seu aprendizado.";
        }

        public void MostrarRecomendacao()
        {
            Console.WriteLine("\n===== SISTEMA DE RECOMENDAÇÕES =====");
            Console.WriteLine("Plano de estudo: " + PlanoEstudo);
            Console.WriteLine("Técnica de foco: " + TecnicaFoco);
            Console.WriteLine("Método de revisão: " + MetodoRevisao);
            Console.WriteLine("Período de descanso: " + PeriodoDescanso);
            Console.WriteLine("Material complementar: " + MaterialComplementar);
            Console.WriteLine("Conteúdo relacionado: " + ConteudoRelacionado);
            Console.WriteLine("Mensagem motivacional: " + MensagemMotivacional);
            if (MensagensUsuario.Count > 0)
            {
                Console.WriteLine("Mensagens de usuários inspiradores:");
                foreach (var msg in MensagensUsuario)
                {
                    Console.WriteLine("- " + msg);
                }
            }
        }
    }
}
