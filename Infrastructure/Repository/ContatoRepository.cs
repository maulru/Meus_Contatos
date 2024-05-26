using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ContatoRepository : EFRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Contato> ObterTodos()
        {
            return _context.Contato
                .Include(c => c.Telefones)
                    .ThenInclude(t => t.DDD)
                        .ThenInclude(d => d.Regiao)
                .ToList();
        }

        public Contato ObterInformacoesPorId(int id)
        {
            var contato = _context.Contato
                .Include(c => c.Telefones)
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Contato não localizado");

            return contato;
        }

        public Contato ObterPorId(int id)
        {
            return _context.Contato
                .Include(c => c.Telefones)
                    .ThenInclude(t => t.DDD)
                .FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        ///  Método responsável pelo cadastro e retorno do usuário cadastrado
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public Contato Cadastrar(Contato contato)
        {
            _context.Contato.Add(contato);
            _context.SaveChanges();
            return contato;
        }

    }
}
