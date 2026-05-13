using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class MetaController : Controller
    {
        private List<MetaEstudo> metas = new List<MetaEstudo>();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View(metas);
        }

        public IActionResult Criar()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public IActionResult Criar(string titulo, string descricao, int horasAlvo, DateTime dataLimite)
        {
            try
            {
                var meta = new MetaEstudo 
                { 
                    Titulo = titulo, 
                    Descricao = descricao, 
                    HorasAlvo = horasAlvo,
                    DataLimite = dataLimite,
                    Progresso = 0
                };
                metas.Add(meta);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao criar meta";
                return View();
            }
        }

        public IActionResult AtualizarProgresso(int id, int progresso)
        {
            try
            {
                var meta = metas.FirstOrDefault(m => m.Id == id);
                if (meta != null)
                    meta.Progresso = progresso;
                
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
                metas.RemoveAll(m => m.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
