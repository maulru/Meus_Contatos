using Microsoft.AspNetCore.Mvc;

namespace Meus_Contatos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult AdicionarContato()
        {
            return View();
        }
    }
}
