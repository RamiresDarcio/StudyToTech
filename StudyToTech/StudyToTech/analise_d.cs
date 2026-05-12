using System;

namespace StudyToTech
{
    public class AnaliseDesempenho
    {
        public int HorasEstudadas { get; set; }

        public int TarefasConcluidas { get; set; }

        public int MetasConcluidas { get; set; }

        public void MostrarAnalise()
        {
            Console.WriteLine("\n===== ANÁLISE =====");

            Console.WriteLine("Horas estudadas: " + HorasEstudadas);

            Console.WriteLine("Tarefas concluídas: " + TarefasConcluidas);

            Console.WriteLine("Metas concluídas: " + MetasConcluidas);

            if (HorasEstudadas >= 10)
            {
                Console.WriteLine("Excelente desempenho!");
            }
            else
            {
                Console.WriteLine("Continue estudando.");
            }
        }
    }
}