using Core.Entity;

namespace Core.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        IEnumerable<Contato> ObterTodos();
        Contato ObterInformacoesPorId(int id);
        public Contato ObterPorId(int id);
        Contato Cadastrar(Contato contato);
        IEnumerable<Contato> BuscarContatosPorDDD(string ddd);
        IEnumerable<Contato> BuscarContatosPorRegiao(string regiao);
    }
}
