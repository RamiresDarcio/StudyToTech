using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class HistoricoController : Controller
    {
        private HistoricoAtividades historico = new HistoricoAtividades();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(historico.ObterHistorico());
        }

        [HttpPost]
        public IActionResult AdicionarAtividade(string descricao, string disciplina)
        {
            try
            {
                historico.RegistrarAtividade(descricao, disciplina);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao adicionar atividade";
                return RedirectToAction("Index");
            }
        }
    }
}
