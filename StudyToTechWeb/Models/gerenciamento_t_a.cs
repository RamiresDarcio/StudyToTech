using System;
using System.Collections.Generic;

namespace StudyToTechWeb.Models
{
    public class gerenciamento_t_a
    {
        private List<Tarefa> tarefas = new List<Tarefa>();

        public void AdicionarTarefa(Tarefa tarefa)
        {
            tarefas.Add(tarefa);
        }

        public List<Tarefa> ListarTarefas()
        {
            return tarefas;
        }

        public void DeletarTarefa(int id)
        {
            tarefas.RemoveAll(t => t.Id == id);
        }

        public void MarcarComoConcluida(int id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
                tarefa.Status = "Concluída";
        }

        public int ObterTotalTarefas()
        {
            return tarefas.Count;
        }
    }
}
