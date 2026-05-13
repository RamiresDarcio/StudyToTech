using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class CalendarioController : Controller
    {
        private List<CalendarioEstudos> eventos = new List<CalendarioEstudos>();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(eventos);
        }

        [HttpPost]
        public IActionResult AdicionarEvento(string titulo, string descricao, DateTime data)
        {
            try
            {
                var evento = new CalendarioEstudos 
                { 
                    Titulo = titulo, 
                    Descricao = descricao, 
                    Data = data
                };
                eventos.Add(evento);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao adicionar evento";
                return RedirectToAction("Index");
            }
        }
    }
}
