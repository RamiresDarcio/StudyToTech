using System;
using System.Collections.Generic;

namespace StudyToTech
{
    public class gerenciamento_d
    {
        private List<Disciplina> disciplinas = new List<Disciplina>();

        public void adicionar_disciplina(Disciplina nova_disciplina)
        {
            if (nova_disciplina != null)
            {
                disciplinas.Add(nova_disciplina);
                Console.WriteLine("Disciplina adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: Disciplina inválida.");
            }
        }

        // Listar disciplinas
        public void listar_disciplinas()
        {
            if (disciplinas.Count == 0)
            {
                Console.WriteLine("\nNenhuma disciplina cadastrada ainda.");
                return;
            }

            Console.WriteLine("\n===== LISTA DE DISCIPLINAS =====");

            for (int i = 0; i < disciplinas.Count; i++)
            {
                Console.WriteLine($"\n--- Disciplina {i + 1} ---");
                Console.WriteLine($"Nome: {disciplinas[i].nome}");
                Console.WriteLine($"Categoria: {disciplinas[i].categoria}");
                Console.WriteLine($"Prioridade: {disciplinas[i].nivel_de_prioridade}");
                Console.WriteLine($"Descrição: {disciplinas[i].descricao}");
                Console.WriteLine($"Tempo de estudo: {disciplinas[i].tempo_estudo} horas");
            }
        }

        // Remover disciplina
        public void remover_disciplina()
        {
            if (disciplinas.Count == 0)
            {
                Console.WriteLine("\nNenhuma disciplina cadastrada para remover.");
                return;
            }

            Console.WriteLine("\nDigite o nome da disciplina que deseja remover:");
            string nome = Console.ReadLine();

            Disciplina disciplinaRemover = null;

            foreach (Disciplina d in disciplinas)
            {
                if (d.nome.ToLower() == nome.ToLower())
                {
                    disciplinaRemover = d;
                    break;
                }
            }

            if (disciplinaRemover != null)
            {
                disciplinas.Remove(disciplinaRemover);
                Console.WriteLine("Disciplina removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada.");
            }
        }

        // Obter total de disciplinas
        public int obter_total_disciplinas()
        {
            return disciplinas.Count;
        }

        // Obter lista de disciplinas
        public List<Disciplina> obter_disciplinas()
        {
            return disciplinas;
        }
    }
}