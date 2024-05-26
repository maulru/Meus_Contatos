using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meus_Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly ApplicationDbContext _context;


        public ContatoController(ITelefoneRepository telefoneRepository, IContatoRepository contatoRepository, ApplicationDbContext context)
        {
            _telefoneRepository = telefoneRepository;
            _contatoRepository = contatoRepository;
            _context = context;
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
        public JsonResult AdicionarContato(ContatoInput input)
        {
            try
            {

                // Obtenção do DDD a partir do código fornecido
                var ddd = _context.DDD.FirstOrDefault(d => d.Codigo == input.NumeroDDD);

                if (ddd == null)
                {
                    return Json(new { success = false, message = "DDD inválido." });
                }

                // Criação do contato
                var contato = new Contato()
                {
                    Nome = input.Nome,
                    Email = input.Email
                };

                _contatoRepository.Cadastrar(contato); // Cadastro do contato

                // Criação do telefone
                var telefone = new Telefone()
                {
                    ContatoId = contato.Id,
                    DDDId = ddd.Id,
                    NumeroTelefone = input.NumeroTelefone
                };

                _telefoneRepository.Cadastrar(telefone); // Cadastro do telefone

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult EditarContato(int id)
        {
            var contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return NotFound();
            }

            var telefone = contato.Telefones.FirstOrDefault();
            var input = new ContatoInput
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email,
                NumeroDDD = telefone?.DDD?.Codigo,
                NumeroTelefone = telefone?.NumeroTelefone
            };

            return View(input);
        }

        [HttpPost]
        public JsonResult EditarContato(ContatoInput input)
        {
            try
            {
                var contato = _contatoRepository.ObterPorId(input.Id);
                if (contato == null)
                {
                    return Json(new { success = false, message = "Contato não encontrado." });
                }

                var ddd = _context.DDD.FirstOrDefault(d => d.Codigo == input.NumeroDDD);
                if (ddd == null)
                {
                    return Json(new { success = false, message = "DDD inválido." });
                }

                contato.Nome = input.Nome;
                contato.Email = input.Email;
                _contatoRepository.Alterar(contato);

                var telefone = contato.Telefones.FirstOrDefault();
                if (telefone != null)
                {
                    telefone.DDDId = ddd.Id;
                    telefone.NumeroTelefone = input.NumeroTelefone;
                    _telefoneRepository.Alterar(telefone);
                }
                else
                {
                    telefone = new Telefone()
                    {
                        ContatoId = contato.Id,
                        DDDId = ddd.Id,
                        NumeroTelefone = input.NumeroTelefone
                    };
                    _telefoneRepository.Cadastrar(telefone);
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        public IActionResult LoadUserCreatedModal() //ActionResult para exibir o ModalDialog
        {
            return PartialView("Components/UserCreatedModal");
        }

    }
}
