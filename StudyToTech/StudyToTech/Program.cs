using System;
using System.Collections.Generic;

namespace StudyToTech
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaLogin login = new SistemaLogin();
            login.ExibirTelaLogin();

            Usuario usuario = null;
            gerenciamento_d gerDisc = new gerenciamento_d();
            gerenciamento_t_a gerTarefa = new gerenciamento_t_a();
            List<CalendarioEstudos> eventos = new List<CalendarioEstudos>();
            HistoricoAtividades historico = new HistoricoAtividades();
            PerfilUsuario perfil = null;
            List<MetaEstudo> metas = new List<MetaEstudo>();
            DashboardEstudos dashboard = null;
            SistemaRecomendacao recomendacao = new SistemaRecomendacao();
            AnaliseDesempenho analise = new AnaliseDesempenho();

            while (true)
            {
                Console.WriteLine("\n=== Sistema de Gerenciamento de Estudos ===");
                Console.WriteLine($"Usuário: {login.UsuarioLogado.Nome}");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Criar Perfil");
                Console.WriteLine("3. Cadastrar Disciplina");
                Console.WriteLine("4. Listar Disciplinas");
                Console.WriteLine("5. Cadastrar Tarefa");
                Console.WriteLine("6. Listar Tarefas");
                Console.WriteLine("7. Criar Meta de Estudo");
                Console.WriteLine("8. Registrar Progresso na Meta");
                Console.WriteLine("9. Listar Metas de Estudo");
                Console.WriteLine("10. Ver Conquistas");
                Console.WriteLine("11. Registrar Atividade no Dashboard");
                Console.WriteLine("12. Adicionar Evento ao Calendário");
                Console.WriteLine("13. Adicionar Atividade ao Histórico");
                Console.WriteLine("14. Mostrar Histórico");
                Console.WriteLine("15. Criar Recomendação");
                Console.WriteLine("16. Mostrar Análise de Desempenho");
                Console.WriteLine("17. Ver Perfil");
                Console.WriteLine("18. Ver Resumo do Dashboard");
                Console.WriteLine("19. Compartilhar Progresso");
                Console.WriteLine("20. Editar Perfil");
                Console.WriteLine("21. Deslogar");
                Console.WriteLine("22. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        usuario = new Usuario();
                        usuario.CadastrarUsuario();
                        break;
                    case "2":
                        if (usuario != null)
                        {
                            perfil = new PerfilUsuario();
                            perfil.CriarPerfil();
                        }
                        else
                        {
                            Console.WriteLine("Cadastre um usuário primeiro.");
                        }
                        break;
                    case "3":
                        Disciplina d = new Disciplina();
                        d.cadastrar_disciplina();
                        gerDisc.adicionar_disciplina(d);
                        break;
                    case "4":
                        gerDisc.listar_disciplinas();
                        break;
                    case "5":
                        gerTarefa.AdicionarTarefa();
                        break;
                    case "6":
                        gerTarefa.ListarTarefas();
                        break;
                    case "7":
                        if (usuario != null)
                        {
                            MetaEstudo meta = new MetaEstudo();
                            meta.CriarMeta();
                            metas.Add(meta);
                            if (perfil != null)
                            {
                                perfil.MetaAtual = meta.NomeMeta;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cadastre um usuário primeiro.");
                        }
                        break;
                    case "8":
                        if (usuario != null)
                        {
                            if (metas.Count == 0)
                            {
                                Console.WriteLine("Crie uma meta primeiro.");
                                break;
                            }

                            Console.WriteLine("\n===== REGISTRAR PROGRESSO NA META =====");
                            for (int i = 0; i < metas.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {metas[i].NomeMeta} - {metas[i].Disciplina} - {metas[i].ProgressoPercentual}% concluído");
                            }

                            Console.Write("Escolha a meta (número): ");
                            if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > metas.Count)
                            {
                                Console.WriteLine("Opção inválida.");
                                break;
                            }

                            MetaEstudo metaEscolhida = metas[escolha - 1];
                            Console.WriteLine("Digite o tempo estudado em minutos para adicionar ao progresso:");
                            if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos <= 0)
                            {
                                Console.WriteLine("Valor inválido.");
                                break;
                            }

                            metaEscolhida.RegistrarProgresso(minutos);
                            if (metaEscolhida.MetaConcluida)
                            {
                                Console.WriteLine($"Parabéns! Você concluiu a meta '{metaEscolhida.NomeMeta}' e ganhou: {metaEscolhida.Trofeu}.");
                                if (perfil != null)
                                {
                                    perfil.TotalTrofeus++;
                                    perfil.Conquistas.Add(metaEscolhida.ObterConquista());
                                    perfil.MetaAtual = metaEscolhida.NomeMeta;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Progresso registrado. Meta com {metaEscolhida.ProgressoPercentual}% concluída.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cadastre um usuário primeiro.");
                        }
                        break;
                    case "9":
                        if (metas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma meta cadastrada.");
                            break;
                        }

                        foreach (MetaEstudo m in metas)
                        {
                            m.ExibirMeta();
                        }
                        break;
                    case "10":
                        if (metas.Count == 0)
                        {
                            Console.WriteLine("Nenhuma conquista disponível ainda.");
                            break;
                        }

                        Console.WriteLine("\n===== CONQUISTAS =====");
                        foreach (MetaEstudo m in metas)
                        {
                            Console.WriteLine(m.ObterConquista());
                        }
                        break;
                    case "11":
                        if (usuario != null)
                        {
                            dashboard = new DashboardEstudos();
                            dashboard.RegistrarAtividade();
                            if (perfil != null)
                            {
                                perfil.HorasEstudadas += dashboard.TempoEstudo;
                                perfil.SequenciaDiasEstudando++;
                                perfil.ConteudosEstudados = dashboard.ConteudoEstudado;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cadastre um usuário primeiro.");
                        }
                        break;
                    case "12":
                        CalendarioEstudos c = new CalendarioEstudos();
                        c.AdicionarEvento();
                        eventos.Add(c);
                        break;
                    case "13":
                        historico.AdicionarAtividade();
                        break;
                    case "14":
                        historico.MostrarHistorico();
                        break;
                    case "15":
                        if (perfil != null)
                        {
                            recomendacao.CriarRecomendacao(perfil, metas, historico);
                            recomendacao.MostrarRecomendacao();
                        }
                        else
                        {
                            Console.WriteLine("Crie um perfil primeiro.");
                        }
                        break;
                    case "16":
                        analise.HorasEstudadas = perfil != null ? perfil.HorasEstudadas : (dashboard != null ? dashboard.TempoEstudo : 0);
                        analise.TarefasConcluidas = gerTarefa.ObterTotalTarefas();
                        analise.MetasConcluidas = metas.FindAll(m => m.MetaConcluida).Count;
                        analise.MostrarAnalise();
                        if (perfil != null)
                        {
                            perfil.AtualizarDesempenho(metas, perfil.HorasEstudadas);
                        }
                        break;
                    case "17":
                        if (perfil != null)
                        {
                            perfil.ExibirPerfil();
                        }
                        else
                        {
                            Console.WriteLine("Crie um perfil primeiro.");
                        }
                        break;
                    case "18":
                        if (perfil != null)
                        {
                            perfil.CompartilharProgresso();
                        }
                        else
                        {
                            Console.WriteLine("Crie um perfil primeiro.");
                        }
                        break;
                    case "19":
                        if (perfil != null)
                        {
                            perfil.CriarPerfil();
                        }
                        else
                        {
                            Console.WriteLine("Crie um perfil primeiro.");
                        }
                        break;
                    case "20":
                        if (dashboard != null)
                        {
                            dashboard.ExibirResumo();
                        }
                        else
                        {
                            Console.WriteLine("Registre atividades no dashboard primeiro.");
                        }
                        break;
                    case "21":
                        login.Deslogar();
                        login.ExibirTelaLogin();
                        break;
                    case "22":
                        Console.WriteLine("Encerrando aplicação...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
