using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Verificar se usuário está logado
        var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
        if (string.IsNullOrEmpty(usuarioLogado))
        {
            return RedirectToAction("Index", "Login");
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
