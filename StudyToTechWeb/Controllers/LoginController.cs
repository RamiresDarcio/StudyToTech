using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string email, string senha)
        {
            try
            {
                // Usar sua classe SistemaLogin existente
                SistemaLogin sistemalogin = new SistemaLogin();
                
                // Validar login (você pode ajustar conforme sua implementação)
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
                {
                    // Simular autenticação (ajuste com sua lógica real)
                    HttpContext.Session.SetString("UsuarioLogado", email);
                    return RedirectToAction("Index", "Home");
                }
                
                ViewBag.Erro = "Email ou senha inválidos";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = "Erro ao fazer login: " + ex.Message;
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
