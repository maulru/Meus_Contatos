using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DDDRepository : EFRepository<DDD>, IDDDRepository
    {
        public DDDRepository(ApplicationDbContext context) : base(context)
        {
        }

      /*  public DDD ObterListaDDD(int id)
        {
            var ddd = _context.DDD
                .Include(c => c.CodigoDDD)
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("DDD não localizado");

            return ddd;
        }*/
    }
}