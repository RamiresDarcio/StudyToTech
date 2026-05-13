using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class AnaliseController : Controller
    {
        private AnaliseDesempenho analise = new AnaliseDesempenho();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(analise);
        }

        public IActionResult Relatorio()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            var relatorio = analise.GerarRelatorio();
            return View("Index", relatorio);
        }
    }
}
