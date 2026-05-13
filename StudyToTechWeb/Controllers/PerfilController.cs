using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class PerfilController : Controller
    {
        private PerfilUsuario perfil = new PerfilUsuario();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(perfil);
        }

        public IActionResult Editar()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(perfil);
        }

        [HttpPost]
        public IActionResult Editar(string nome, string email, string curso, int semestre)
        {
            try
            {
                perfil.Nome = nome;
                perfil.Email = email;
                perfil.Curso = curso;
                perfil.Semestre = semestre;
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao atualizar perfil";
                return View();
            }
        }
    }
}
