using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RegiaoRepository : EFRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Regiao ObterListaRegiao(int id)
        {
            var regiao = _context.Regiao
                .Include(c => c.Estados)
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Região não localizada");

            return regiao;
        }
    }
}