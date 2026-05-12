using System;
using System.Collections.Generic;

namespace StudyToTech
{
    public class gerenciamento_t_a
    {
        private List<tarefa_a> tarefas = new List<tarefa_a>();

        public void AdicionarTarefa()
        {
            tarefa_a novaTarefa = new tarefa_a();

            novaTarefa.cadastrar_tarefa();

            tarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        // Listar tarefas
        public void ListarTarefas()
        {
            Console.WriteLine("\n===== LISTA DE TAREFAS =====");

            foreach (tarefa_a tarefa in tarefas)
            {
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Disciplina: {tarefa.Disciplina}");
                Console.WriteLine($"Prioridade: {tarefa.Prioridade}");
                Console.WriteLine($"Status: {tarefa.Status}");
                Console.WriteLine($"Prazo: {tarefa.Prazo}");
                Console.WriteLine();
            }
        }

        // Remover tarefa
        public void RemoverTarefa()
        {
            Console.WriteLine("\nDigite o título da tarefa:");

            string titulo = Console.ReadLine();

            tarefa_a tarefaRemover = null;

            foreach (tarefa_a tarefa in tarefas)
            {
                if (tarefa.Titulo == titulo)
                {
                    tarefaRemover = tarefa;
                }
            }

            if (tarefaRemover != null)
            {
                tarefas.Remove(tarefaRemover);

                Console.WriteLine("Tarefa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        public int ObterTotalTarefas()
        {
            return tarefas.Count;
        }
    }
}
