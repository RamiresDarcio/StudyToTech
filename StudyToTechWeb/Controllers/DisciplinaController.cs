using Microsoft.AspNetCore.Mvc;
using StudyToTechWeb.Models;

namespace StudyToTechWeb.Controllers
{
    public class DisciplinaController : Controller
    {
        private gerenciamento_d gerenciamento = new gerenciamento_d();

        public IActionResult Index()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            var disciplinas = gerenciamento.ListarDisciplinas();
            return View(disciplinas);
        }

        public IActionResult Criar()
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public IActionResult Criar(string nome, string descricao, int cargaHoraria)
        {
            try
            {
                var disciplina = new Disciplina { Nome = nome, Descricao = descricao, CargaHoraria = cargaHoraria };
                gerenciamento.AdicionarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao criar disciplina";
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var usuarioLogado = HttpContext.Session.GetString("UsuarioLogado");
            if (string.IsNullOrEmpty(usuarioLogado))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public IActionResult Editar(int id, string nome, string descricao, int cargaHoraria)
        {
            try
            {
                var disciplina = new Disciplina { Id = id, Nome = nome, Descricao = descricao, CargaHoraria = cargaHoraria };
                gerenciamento.AtualizarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro ao editar disciplina";
                return View();
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                gerenciamento.DeletarDisciplina(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
