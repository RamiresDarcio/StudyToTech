using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class TarefaController : Controller
    {
        private gerenciamento_t_a gerenciamento = new gerenciamento_t_a();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            var tarefas = gerenciamento.ListarTarefas();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public IActionResult Criar(string titulo, string descricao, string disciplina, string prioridade, DateTime prazo)
        {
            try
            {
                var tarefa = new Tarefa 
                { 
                    Titulo = titulo, 
                    Descricao = descricao, 
                    Disciplina = disciplina,
                    Prioridade = prioridade,
                    Prazo = prazo,
                    Status = "Pendente"
                };
                gerenciamento.AdicionarTarefa(tarefa);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao criar tarefa";
                return View();
            }
        }

        public IActionResult Completar(int id)
        {
            try
            {
                gerenciamento.MarcarComoConcluida(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                gerenciamento.DeletarTarefa(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
