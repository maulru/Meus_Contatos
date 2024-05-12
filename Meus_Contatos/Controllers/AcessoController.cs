using Microsoft.AspNetCore.Mvc;

namespace Meus_Contatos.Controllers
{
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            return Ok("Acesso autorizado");
        }
    }
}
