using System;
using System.Collections.Generic;

namespace StudyToTechWeb.Models
{
    public class gerenciamento_d
    {
        private List<Disciplina> disciplinas = new List<Disciplina>();
        private int nextId = 1;

        public void AdicionarDisciplina(Disciplina disciplina)
        {
            disciplina.Id = nextId++;
            disciplinas.Add(disciplina);
        }

        public List<Disciplina> ListarDisciplinas()
        {
            return disciplinas;
        }

        public void AtualizarDisciplina(Disciplina disciplina)
        {
            var existente = disciplinas.FirstOrDefault(d => d.Id == disciplina.Id);
            if (existente != null)
            {
                existente.Nome = disciplina.Nome;
                existente.Descricao = disciplina.Descricao;
                existente.CargaHoraria = disciplina.CargaHoraria;
            }
        }

        public void DeletarDisciplina(int id)
        {
            disciplinas.RemoveAll(d => d.Id == id);
        }
    }
}
