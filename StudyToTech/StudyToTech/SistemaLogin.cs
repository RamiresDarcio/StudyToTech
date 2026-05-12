using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyToTech
{
    public class SistemaLogin
    {
        private List<UsuarioRegistrado> usuariosRegistrados = new List<UsuarioRegistrado>();
        public UsuarioRegistrado UsuarioLogado { get; set; }

        public SistemaLogin()
        {
            // Adiciona um usuário de teste
            usuariosRegistrados.Add(new UsuarioRegistrado
            {
                Email = "teste@email.com",
                Senha = HasharSenha("teste123"),
                Nome = "Usuário Teste"
            });
        }

        public void ExibirTelaLogin()
        {
            bool autenticado = false;

            while (!autenticado)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║   BEM-VINDO AO STUDYTOTECH 2026    ║");
                Console.WriteLine("║      Sistema de Gerenciamento de     ║");
                Console.WriteLine("║              Estudos                 ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.WriteLine("\n1. Fazer Login");
                Console.WriteLine("2. Criar Nova Conta");
                Console.WriteLine("3. Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        autenticado = RealizarLogin();
                        break;
                    case "2":
                        CriarNovaConta();
                        break;
                    case "3":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public bool RealizarLogin()
        {
            Console.Clear();
            Console.WriteLine("\n===== LOGIN =====\n");

            Console.WriteLine("Digite seu email:");
            string email = Console.ReadLine();

            Console.WriteLine("Digite sua senha:");
            string senha = Console.ReadLine();

            UsuarioRegistrado usuario = usuariosRegistrados.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                Console.WriteLine("\nEmail não encontrado. Pressione Enter para voltar...");
                Console.ReadLine();
                return false;
            }

            if (VerificarSenha(senha, usuario.Senha))
            {
                UsuarioLogado = usuario;
                Console.WriteLine($"\n✓ Bem-vindo, {usuario.Nome}!");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("\nSenha incorreta. Pressione Enter para voltar...");
                Console.ReadLine();
                return false;
            }
        }

        public void CriarNovaConta()
        {
            Console.Clear();
            Console.WriteLine("\n===== CRIAR NOVA CONTA =====\n");

            Console.WriteLine("Digite seu nome completo:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite seu email:");
            string email = Console.ReadLine();

            if (usuariosRegistrados.Any(u => u.Email == email))
            {
                Console.WriteLine("\nEmail já cadastrado. Pressione Enter para voltar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Digite uma senha (mínimo 8 caracteres):");
            string senha = Console.ReadLine();

            if (senha.Length < 8)
            {
                Console.WriteLine("\nSenha deve ter no mínimo 8 caracteres. Pressione Enter para voltar...");
                Console.ReadLine();
                return;
            }

            usuariosRegistrados.Add(new UsuarioRegistrado
            {
                Nome = nome,
                Email = email,
                Senha = HasharSenha(senha)
            });

            Console.WriteLine("\n✓ Conta criada com sucesso!");
            Console.WriteLine("Agora faça login com suas credenciais. Pressione Enter...");
            Console.ReadLine();
        }

        private string HasharSenha(string senha)
        {
            // Implementação simples de hash (em produção, usar bcrypt ou similar)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha + "SALT_SEGURO"));
        }

        private bool VerificarSenha(string senhaDigitada, string senhaArmazenada)
        {
            string senhaHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senhaDigitada + "SALT_SEGURO"));
            return senhaHash == senhaArmazenada;
        }

        public void Deslogar()
        {
            UsuarioLogado = null;
            Console.WriteLine("\n✓ Deslogado com sucesso!");
            Console.WriteLine("Pressione Enter para voltar ao login...");
            Console.ReadLine();
        }
    }

    public class UsuarioRegistrado
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
