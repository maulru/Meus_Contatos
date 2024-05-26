using Core.Repository;
using Meus_Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Meus_Contatos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public HomeController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            var contatos = _contatoRepository.ObterTodos();
            return View(contatos);
        }

        [HttpPost]
        public JsonResult ExcluirContato(int id)
        {
            try
            {
                _contatoRepository.Deletar(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
