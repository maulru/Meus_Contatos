using Core.Entity;

namespace Core.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {

        Contato ObterInformacoesPorId(int id);

        Contato Cadastrar(Contato contato);
    }
}
