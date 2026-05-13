using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class DashboardController : Controller
    {
        private DashboardEstudos dashboard = new DashboardEstudos();
        private gerenciamento_t_a tarefaGerenc = new gerenciamento_t_a();
        private gerenciamento_d discGerenc = new gerenciamento_d();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            var dados = new Dictionary<string, object>
            {
                { "TarefasPendentes", tarefaGerenc.ListarTarefas()?.Count ?? 0 },
                { "Disciplinas", discGerenc.ListarDisciplinas()?.Count ?? 0 },
                { "Atividades", dashboard.ObterResumo() }
            };

            return View(dados);
        }

        [HttpPost]
        public IActionResult RegistrarAtividade(string descricao, int tempoEstudo)
        {
            try
            {
                dashboard.RegistrarAtividade(descricao, tempoEstudo);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao registrar atividade";
                return RedirectToAction("Index");
            }
        }
    }
}
