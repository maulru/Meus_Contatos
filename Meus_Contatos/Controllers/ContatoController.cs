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

        /// <summary>
        /// Injeção de dependência
        /// </summary>
        /// <param name="telefoneRepository"></param>
        /// <param name="contatoRepository"></param>
        /// <param name="context"></param>
        public ContatoController(ITelefoneRepository telefoneRepository, IContatoRepository contatoRepository, ApplicationDbContext context)
        {
            _telefoneRepository = telefoneRepository;
            _contatoRepository = contatoRepository;
            _context = context;
        }

        /// <summary>
        /// Retornar View
        /// </summary>
        /// <returns></returns>
        public IActionResult AdicionarContato()
        {
            return View();
        }

        /// <summary>
        /// Método para adicionar contato
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Action Result para Edição de contato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para editar Contato
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para retornar contatos de acordo com o filtro de Região e/ou DDD
        /// </summary>
        /// <param name="regiao"></param>
        /// <param name="ddd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ContatosFiltrados(string regiao, string ddd)
        {
            var query = _context.Contato.Include(c => c.Telefones).ThenInclude(t => t.DDD).ThenInclude(r=> r.Regiao).AsQueryable();

            if (!string.IsNullOrEmpty(regiao))
            {
                query = query.Where(c => c.Telefones.Any(t => t.DDD.Regiao.Nome.Contains(regiao)));
            }

            if (!string.IsNullOrEmpty(ddd))
            {
                query = query.Where(c => c.Telefones.Any(t => t.DDD.Codigo == ddd));
            }

            var contatos = query.ToList();

            return Json(new { success = true, data = contatos, totalContatos = contatos.Count });
        }

        /// <summary>
        /// Método para carregar o modal na tela de cadastro de usuário
        /// </summary>
        /// <returns></returns>
        public IActionResult LoadUserCreatedModal() //ActionResult para exibir o ModalDialog
        {
            return PartialView("Components/UserCreatedModal");
        }

        /// <summary>
        /// Método para carregar o modal na tela de edição de usuário
        /// </summary>
        /// <returns></returns>
        public IActionResult LoadUserChangedModal() //ActionResult para exibir o ModalDialog
        {
            return PartialView("Components/UserChangedModal");
        }

    }
}
