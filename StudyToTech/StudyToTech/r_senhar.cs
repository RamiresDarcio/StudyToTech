using System;

namespace StudyToTech
{
    public class RecuperarSenha
    {
        public bool ValidarEmail(string email, Usuario usuario)
        {
            return !string.IsNullOrWhiteSpace(email) && email == usuario.Email;
        }

        public string ObterNovaSenha()
        {
            while (true)
            {
                Console.WriteLine("Digite sua nova senha (mínimo 12 caracteres):");
                string nova_senha = Console.ReadLine();

                Console.WriteLine("Confirme sua nova senha:");
                string confirmacao_senha = Console.ReadLine();

                if (nova_senha != confirmacao_senha)
                {
                    Console.WriteLine("As senhas não coincidem. Tente novamente.");
                    continue;
                }

                if (nova_senha.Length < 12)
                {
                    Console.WriteLine("Senha deve ter no mínimo 12 caracteres!");
                    continue;
                }

                return nova_senha;
            }
        }

        public void RecuperarSenhaUsuario(Usuario usuario)
        {
            Console.WriteLine("\n=== RECUPERAR SENHA ===");
            Console.WriteLine("Digite seu email para recuperar a senha:");
            string email = Console.ReadLine();

            if (!ValidarEmail(email, usuario))
            {
                Console.WriteLine("Email não encontrado. Verifique e tente novamente.");
                return;
            }

            string nova_senha = ObterNovaSenha();
            usuario.DefinirSenha(nova_senha);
            Console.WriteLine("Senha redefinida com sucesso!\n");
        }
    }
}