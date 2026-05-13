using System;

namespace StudyToTechWeb.Models
{
    public class Usuario
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        private string? Senha { get; set; }

        public void DefinirSenha(string? senha)
        {
            if (senha == null || senha.Length < 12)
            {
                Console.WriteLine("A senha deve conter no mínimo 12 caracteres");
            }
            else
            {
                Senha = senha;
                Console.WriteLine("Senha definida com sucesso");
            }
        }

        public void CadastrarUsuario()
        {
            Console.WriteLine("Digite seu nome");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite seu sobrenome");
            Sobrenome = Console.ReadLine();
            Console.WriteLine("Digite seu endereço de email");
            Email = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine();
            DefinirSenha(senha);
        }
    }
}