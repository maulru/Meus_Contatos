using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Meus_Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public ContatoController(ITelefoneRepository telefoneRepository, IContatoRepository contatoRepository)
        {
            _telefoneRepository = telefoneRepository;
            _contatoRepository = contatoRepository;
        }

        public IActionResult AdicionarContato()
        {
            return View();
        }
        
     /*   [HttpPost]
        public JsonResult ContatosLista()
        {
            int quantidade = 0;

            List<Contato> contatos = (List<Contato>)_contatoRepository.ObterTodos();

            return Json(new { Result = "Ok", Records = contatos, TotalRecordCount = quantidade });
        }*/

        [HttpPost]
        public JsonResult Index(ContatoInput input)
        {
            try
            {
                var contato = new Contato()
                {
                    Nome = input.Nome,
                    Email = input.Email
                };

                Contato contatoID = _contatoRepository.Cadastrar(contato); // Cadastro e obtenção do ID

                var telefone = new Telefone()
                {
                    ContatoId = contatoID.Id,
                    NumeroDDD = input.Ddd,
                    NumeroTelefone = input.Telefone

                };

                _telefoneRepository.Cadastrar(telefone);


            }
            catch (Exception ex)
            {

            }

            return Json(new { Result = "Ok" });
        }


    }
}
